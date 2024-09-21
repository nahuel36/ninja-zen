using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class startScript : MonoBehaviour
{

/*
    public void Start()
    {
       // Resources.LoadAll("backgrounds");
    }
    */
    public void pressedStart()
    {
        SceneManager.LoadScene("game");
    }


	
}
