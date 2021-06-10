using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public Canvas PreGame;
    public Canvas HUD;
    public Canvas Paused;
    public Canvas GameOver;

    private void Start()
    {
        GameManager.Instance.onGameStateChange += gameStateChange;
        HideAllCanvases();

    }

    private void gameStateChange(GameManager.GameState from, GameManager.GameState to)
    {
        if (from == GameManager.GameState.PreGame && to == GameManager.GameState.Playing)
        {
            PreGame.enabled = false;
            Paused.enabled = false;
            HUD.enabled = true;
        }
        if (from == GameManager.GameState.Playing && to == GameManager.GameState.Paused)
        {
            //PreGame.enabled = false;
            Paused.enabled = true;
            HUD.enabled = false;
        }
        if (from == GameManager.GameState.Paused && to == GameManager.GameState.Playing)
        {
            //PreGame.enabled = false;
            Paused.enabled = false;
            HUD.enabled = true;
        }
        if (from == GameManager.GameState.Playing && to == GameManager.GameState.GameOver)
        {
            PreGame.enabled = false;
            Paused.enabled = false;
            HUD.enabled = false;
            GameOver.enabled = true;
        }
    }

    void HideAllCanvases()
    {
        PreGame.enabled = true;
        HUD.enabled = false;
        Paused.enabled = false;
        GameOver.enabled = false;
    }

    public void startButtonOnClick()
    {
        GameManager.Instance.StartGame();
    }

    public void resumeButtonOnClick()
    {
        GameManager.Instance.ResumeGame();
    }

    public void restartButtonOnClick()
    {
        GameManager.Instance.RestartGame();
    }

    private void OnDestroy()
    {

        GameManager.Instance.onGameStateChange -= gameStateChange;
    }
}
