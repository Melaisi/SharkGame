using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public UnityAction<GameState, GameState> onGameStateChange;
    public UnityAction onHealthChange;
    public UnityAction onScoreChange;
    public enum GameState { PreGame, Playing, Paused, GameOver }
    public GameState gameState;
    public GameState previousGameState;



    public int health;
    public int Health { get { return health; } set { if (value >= 0 && value <= 3) { health = value; onHealthChange?.Invoke(); } } }

    public int score;
    public int Score { get { return score; } set { if (value >= 0) { score = value; onScoreChange?.Invoke(); } } }


    public KeyCode pauseKey = KeyCode.Escape;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            gameState = GameState.PreGame;
            Health = 3;

            DontDestroyOnLoad(this);
        }
    }



    void Update()
    {
        
        if (Input.GetKeyDown(pauseKey))
        {
            Debug.Log("Pause key pressed");
            if (gameState == GameState.Playing)
            {
                Debug.Log("Pause the game");
                ChangeState(GameState.Paused);
            }
            else if (gameState == GameState.Paused)
            {
                Debug.Log("Resume the game");
                ChangeState(GameState.Playing);
            }
        }
    }
    public void ChangeState(GameState to)
    {
        previousGameState = gameState;
        gameState = to;

        onGameStateChange += (GameState a, GameState b) => { Debug.Log("game state change from " + previousGameState.ToString() + "to " + gameState.ToString()); };
        onGameStateChange(previousGameState, gameState);

    }

    public void StartGame()
    {
        Debug.Log("called by button through the ui manager to start the game");
        ChangeState(GameState.Playing);
    }

    public void RestartGame()
    {
        gameState = GameState.PreGame;
        health = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void ResumeGame()
    {
        Debug.Log("Resume the game");
        ChangeState(GameState.Playing);
    }

    public void increaseHealth()
    {
        if (Health < 3)
        {
            Health++;
        }
    }

    public void increaseScore()
    {
        score++;

    }
    public void decreaseHealth()
    {
        Health--;
        if (Health == 0)
        {
            ChangeState(GameState.GameOver);
        }
    }
}
