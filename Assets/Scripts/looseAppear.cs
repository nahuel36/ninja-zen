using UnityEngine;
using System.Collections;

public class looseAppear : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        LevelManager.looseGame += show;

	}
	
	// Update is called once per frame
	void show() {
        if(this != null && this.transform != null)
        { 

        Transform child = this.transform.GetChild(0);
        child.gameObject.SetActive(true);
        }
    }
}
