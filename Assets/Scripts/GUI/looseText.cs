using UnityEngine;
using System.Collections;

public class looseText : MonoBehaviour {
   
	void Start () {
        LevelManager.looseGame += showText;
    }

    public void showText() {
        if(this != null && this.transform != null)
            GetComponent<Animator>().enabled = true;
    }

}
