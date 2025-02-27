using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState { MainMenu, Playing, Paused, GameOver }
    public GameState CurrentState { get; private set; }

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }
    }

    private void Start() { ChangeState(GameState.MainMenu); }

    public void ChangeState(GameState newState)
    {
        CurrentState = newState;
        switch (newState)
        {
            case GameState.MainMenu:
                AudioManager.Instance.PlayMusic("MenuMusic");
                UIManager.Instance.ShowMainMenu(true);
                break;
            case GameState.Playing:
                AudioManager.Instance.PlayMusic("GameMusic");
                UIManager.Instance.ShowMainMenu(false);
                break;
            case GameState.Paused:
                Time.timeScale = 0;
                UIManager.Instance.ShowPauseMenu(true);
                break;
            case GameState.GameOver:
                UIManager.Instance.ShowGameOverMenu(true);
                break;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
        ChangeState(GameState.Playing);
    }

    public void PauseGame()
    {
        ChangeState(GameState.Paused);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        ChangeState(GameState.Playing);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        ChangeState(GameState.MainMenu);
    }
}
