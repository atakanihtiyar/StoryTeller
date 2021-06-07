using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Singleton
    public static GameController Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    public GameState state;

    private void Start()
    {
        state = GameState.Play;
    }

    private void Update()
    {
        if (state == GameState.End)
        {
            EndGame();
        }
        if (state == GameState.Play)
        {
            PlayGame();
        }
    }

    public void EndGame()
    {
        if (Input.anyKeyDown)
        {
            Application.Quit();
        }
    }

    public void PlayGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Mouse1))
        {
            EndGame();
        }
    }
}

public enum GameState { Play, End }