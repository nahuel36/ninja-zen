using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

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

    [SerializeField] Character karateka;
    public bool loosedGame;
    private InputAction accept;
    private InputAction goToMenu;
    // Use this for initialization
    void Start () {
        loosedGame = false;
        Instance = this;
        ActualScore = 0;
        HighScore = PlayerPrefs.GetInt("MaxScore");
        accept = InputSystem.actions.FindAction("Accept");
        goToMenu = InputSystem.actions.FindAction("Other");
    }
    void Update () 
    {
        if (loosedGame && accept.WasPressedThisFrame())
        { 
            RestartLevel();
        }
        if (loosedGame && goToMenu.WasPressedThisFrame())
        {
            GoToMenu();
        }
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu() {
        SceneManager.LoadScene("intro");
    }
	
}
