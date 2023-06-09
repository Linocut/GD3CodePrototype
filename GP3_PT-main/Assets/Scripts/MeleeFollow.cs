using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeFollow : MonoBehaviour
{
    //enums are state specific 
    private enum AIState
    {
        Passive,
        Hostile

    }
    private AIState aiState;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    //global variables have  under it, but locals dont its just another organizational tactic 
    public bool canSeePlayer;
    public bool isChasingPlayer;
    public bool IAmWaiting;
    public bool randomWaitTime;
    public bool randomWander;
    public bool alwaysMoving;
    public bool fleeFromPlayer;

    [SerializeField]
    //serialized feilds allow you to see the following in the inspector 
    [Range(1, 7)] private int waittime;
    //range is a slider to modify things in inspector

    [SerializeField]
    private float speed;
    private float timeSinceSeenPlayer;
    //time to lose the player

    [SerializeField]
    [Range(0, 500)] private float walkRadius;
    //movement circle

    public float FoVRadius;
    //vision system 

    [Range(0, 360)] public float FoVAngle;

    

    public float proximityRadius;
    [Range(0, 360)] public float proximityAngle;


    [SerializeField]
    private Transform[] waypoints;
    //this was an array of physical locations of points

    private int nextWayPoint = 0;

    [HideInInspector]
    public GameObject player;
    private Renderer enemyColor;
    //change for visual feedback
    private NavMeshAgent navMeshAgent; 



    // Start is called before the first frame update
    void Start()
    {
        enemyColor = GetComponent<Renderer>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
    }


    IEnumerator RandomWaitTimer()
    {
        if (alwaysMoving == false && randomWaitTime == true)
        {
            waittime = Random.Range(1, 5);
            navMeshAgent.speed = 0;
            yield return new WaitForSeconds(waittime);
        }
        else if (alwaysMoving == false && randomWaitTime == false)
        {
            navMeshAgent.speed = 0;
            yield return new WaitForSeconds(waittime);

        }
        navMeshAgent.speed = speed;
        IAmWaiting = false;

    }

    public Vector3 RandomNavMeshLocation()
    {
        //setting it to zero at the beginning will allow it to not be transformed additively each time 
        Vector3 finalPosition = Vector3.zero;
        //the sphere is as big as your walk radius - imaginary sphere 
        Vector3 randomPosition = Random.insideUnitSphere * walkRadius;
        //we are adding that location to transform position
        randomPosition += transform.position;
        if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit , walkRadius, 1))
        {
            finalPosition = hit.position; 
        }
        return finalPosition; 
    }

    private void Wander()
    {
        if (navMeshAgent != null && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && IAmWaiting == false)
        {
            navMeshAgent.SetDestination(RandomNavMeshLocation());
            IAmWaiting = true;
            StartCoroutine(RandomWaitTimer());
        }
    }

    void GoToNextPoint()
    {
        if(waypoints.Length == 0)
        {
            return;
        }
        navMeshAgent.destination = waypoints[nextWayPoint].position;
        //percent sign asks that you go back to the beginning when youre at the length 
        nextWayPoint = (nextWayPoint + 1) % waypoints.Length;
        IAmWaiting = true;
        StartCoroutine(RandomWaitTimer());
    }
    private void FieldOfViewCheck()
    {
        //make an array of range checks colliders which is made from the circle radius, take the fov angle, then ;look for the target player mask 
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, FoVRadius, targetMask);
        //the if statement is a null check for the raycast 
        if ( rangeChecks.Length != 0)
        {
            //tells them the first range in target layer is the player 
            Transform target = rangeChecks[0].transform;
            //look towards the player 
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            //we divide by 2 to make the angle cone, is this thing actually in the fov 
            if (Vector3.Angle(transform.forward,directionToTarget) < FoVAngle / 2)
            {
                //calculate distance between player and the ai 
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                //if the raycast isnt obstructued, you can see the player !
                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true; 
                }
                // if the raycast is obstructued, you cant see the player : ( 
                else
                {
                    canSeePlayer = false;
                }
            }
            //inverse of the if we can actually see the player in the fov 
            else
            {
                canSeePlayer = false;
            }
        }
        //if range check is 0, no collision? no player, cant see it
        else if (canSeePlayer == false)
        {
            //you cant see the player i swear
            canSeePlayer = false;
            //time from before where you go by evey second until you never lose player 
            timeSinceSeenPlayer += Time.deltaTime; 
            if ( timeSinceSeenPlayer >= 2f)
            {
                //if it has been 2 second since youve seen the player, you cant see them, chase them, so go be hostile, then 0 the time we have seen player again 
                canSeePlayer = false;
                isChasingPlayer = false;
                aiState = AIState.Passive;
                timeSinceSeenPlayer = 0;
            }
        }
    }
    private void ProximityCheck()
    {
        //raycast in all directions, this makes the Ai know you're there
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, proximityRadius, targetMask);
        //the if statement is a null check for the raycast 
        if (rangeChecks.Length != 0)
        {
            //tells them the first range in target layer is the player 
            Transform target = rangeChecks[0].transform;
            //look towards the player 
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            //we divide by 2 to make the angle cone, is this thing actually in the fov 
            if (Vector3.Angle(transform.forward, directionToTarget) < proximityAngle / 2)
            {
                //calculate distance between player and the ai 
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                //if the raycast isnt obstructued, you can see the player !
                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                }
                // if the raycast is obstructued, you cant see the player : ( 
                else
                {
                    canSeePlayer = false;
                }
            }
            //inverse of the if we can actually see the player in the fov 
            else
            {
                canSeePlayer = false;
            }
        }
        //if range check is 0, no collision? no player, cant see it
        else if (canSeePlayer == false)
        {
            //you cant see the player i swear
            canSeePlayer = false;
            //time from before where you go by evey second until you never lose player 
            timeSinceSeenPlayer += Time.deltaTime;
            if (timeSinceSeenPlayer >= 2f)
            {
                //if it has been 2 second since youve seen the player, you cant see them, chase them, so go be hostile, then 0 the time we have seen player again 
                canSeePlayer = false;
                isChasingPlayer = false;
                aiState = AIState.Passive;
                timeSinceSeenPlayer = 0;
            }
        }

    }
    // The nmect function checks for the player, not on every frame
    private IEnumerator CheckForPlayer()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        while (true)
        {
            //run the scan every point 2 seconds
            yield return wait;
            FieldOfViewCheck();
        }
    }
    private void ChasePlayer()
    {
        isChasingPlayer = true;
        navMeshAgent.destination = player.transform.position;
        if(canSeePlayer == true)
        {
            enemyColor.material.color = Color.red;
        }
        else
        {
            enemyColor.material.color = Color.magenta;
        }
        FieldOfViewCheck();
    }
    public void FleeFromPlayer()
    {
        // the times one is a requirement to put in the function
        Vector3 runTo = transform.position + ((transform.position - player.transform.position) * 1);
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < walkRadius)
        {
            navMeshAgent.SetDestination(runTo);
        }
    }



    // Update is called once per frame
    private void Update()
    {
        switch (aiState)
        {
            case AIState.Passive:
                enemyColor.material.color = Color.yellow; 
                if ( randomWander == true)
                {
                    
                    Wander();
                    if ( canSeePlayer == true)
                    {
                        //for some reason can see player is never true

                        enemyColor.material.color = Color.green;
                        aiState = AIState.Hostile;
                    }
                }
                else
                {
                    if(navMeshAgent.remainingDistance < 2f && canSeePlayer == false)
                    {
                        GoToNextPoint();
                    }
                    if (canSeePlayer == true)
                    {
                        aiState = AIState.Hostile;
                    }
                }
                break;
            case AIState.Hostile:
                if (fleeFromPlayer == true)
                {
                    FleeFromPlayer();
                    navMeshAgent.speed = 30;
                    enemyColor.material.color = Color.green;
                }
                else
                {
                    ChasePlayer();
                    navMeshAgent.speed = 10;
                }
                if (canSeePlayer == false)
                {
                    FieldOfViewCheck();
                }
                break; 




        }
        FieldOfViewCheck();
        ProximityCheck();



    }
}
