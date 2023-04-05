using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionStun : MonoBehaviour
{
    public float collisionStunTime;
    void OnCollisionEnter(Collision collider)
    {
        Debug.Log("Collision");
        EnemyStun enemyStun = collider.transform.GetComponent<EnemyStun>();
        if (enemyStun != null)
        {
            Debug.Log("collision to enemy ");
            enemyStun.StunCollider(collisionStunTime);

        }

    }

    


}
