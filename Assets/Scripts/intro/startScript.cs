using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class startScript : MonoBehaviour
{
    InputAction accept;
    InputAction credits;
    [SerializeField] float splashTime = 3;
    [SerializeField] Animator menuAnimator;
    bool pressedstart = false;
    public void Start()
    {
        pressedstart = false;
        accept = InputSystem.actions.FindAction("Accept");
        credits = InputSystem.actions.FindAction("Other");
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
        if (credits.WasPressedThisFrame())
        {
            pressedstart = true;
            GoToCredits();
        }
    }

    public void pressedStart()
    {
        SceneManager.LoadScene("game");
    }

    public void GoToCredits() 
    {
        SceneManager.LoadScene("credits");
    }
	
}
