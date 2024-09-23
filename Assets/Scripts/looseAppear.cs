using UnityEngine;
using System.Collections;

public class looseAppear : MonoBehaviour {

    [SerializeField] PlaySound looseSound;
    [SerializeField] GameObject gameMusic;

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

            looseSound.Play();
            gameMusic.GetComponentInParent<Animator>().enabled = false;
            gameMusic.SetActive(false);
        }
    }
}
