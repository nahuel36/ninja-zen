using UnityEngine;
using System.Collections;


public enum DIFFICULTY
    {
    EASY,
    MEDIUM,
    HARD
    };



public sealed class LevelManager : MonoBehaviour {

    public static LevelManager Instance;

    public delegate void gameEvent();
    public static event gameEvent looseGame;

    public DIFFICULTY selectedDifficulty;
    public int ActualScore;
    public int HighScore;
    public int lifes = 3;

    public character karateka;
    public bool loosedGame;

	// Use this for initialization
	void Start () {
        loosedGame = false;
        Instance = this;
        ActualScore = 0;
        HighScore = PlayerPrefs.GetInt("MaxScore");
    }

    public void hurtKarateka(int hurtAmount) {
        if (loosedGame) return;

        lifes -= hurtAmount;
        karateka.Hurt();

        if (lifes < 1) { 
            looseGame();
            loosedGame = true;
        }
    }

    public void KaratekaKickExplode(string Direction)
    {
        karateka.KickExplode(Direction);
    }


    public bool isHighScore() {
        return (HighScore < ActualScore);
    }

    public void AddScore(int ScoreAmount)
    {
        ActualScore += ScoreAmount;
        if(HighScore < ActualScore)
        {
            HighScore = ActualScore;
            PlayerPrefs.SetInt("MaxScore", ActualScore);
            
        }
    }

    public void RestartLevel() {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void GoToMenu() {
        Application.LoadLevel("intro");
    }
	
}
