using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class stateText : MonoBehaviour {

    public Text ScoreText;
    public Text MasScoreText;
    public GameObject[] LifesText;



    // Update is called once per frame
    void Update () {

        if (LevelManager.Instance.lifes >= 0)
        {
            ScoreText.text = LevelManager.Instance.ActualScore.ToString();
            MasScoreText.text = LevelManager.Instance.HighScore.ToString();
            for (int i=0; i<LifesText.Length;i++)
            {
                if (LevelManager.Instance.lifes > i)
                    LifesText[i].SetActive(true);
                else
                    LifesText[i].SetActive(false);
            }
        }
        
    }
}
