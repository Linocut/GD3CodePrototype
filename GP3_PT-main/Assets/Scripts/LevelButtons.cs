using UnityEngine.SceneManagement;
using UnityEngine;


public class LevelButtons : MonoBehaviour
{
    
    public void Level1()
    {
        SceneManager.LoadScene("Level1_Test");

    }
    public void Level2()
    {
        SceneManager.LoadScene("Level2_Test");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Level3_Test");

    }



}
