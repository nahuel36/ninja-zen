using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class startScript : MonoBehaviour
{
    InputAction accept;
    [SerializeField] float splashTime = 3;
    [SerializeField] Animator menuAnimator;
    bool pressedstart = false;
    public void Start()
    {
        pressedstart = false;
        accept = InputSystem.actions.FindAction("Accept");
        // Resources.LoadAll("backgrounds");
    }

    public void Update()
    {
        if (Time.timeSinceLevelLoad < splashTime || pressedstart) return;

        if (accept.WasPressedThisFrame())
        { 
            pressedstart = true;
            menuAnimator.SetTrigger("start");
        }
    }

    public void pressedStart()
    {
        SceneManager.LoadScene("game");
    }


	
}
