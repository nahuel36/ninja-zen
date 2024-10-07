using UnityEngine;

public class HorizontalOrientation : MonoBehaviour
{
    [SerializeField] GameObject WarnUI;

    private void Start()
    {
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (WarnUI.activeInHierarchy == false && Screen.width < Screen.height)
        {
            WarnUI.SetActive(true);
        }
        if (WarnUI.activeInHierarchy == true && Screen.width > Screen.height)
        {
            WarnUI.SetActive(false);
        }
    }
}
