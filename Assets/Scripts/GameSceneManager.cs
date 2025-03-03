using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject pauseButton;
    void Start()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("No se encontró el AudioManager en la escena.");
            return;
        }
        GameManager.OnGameStateChanged += HandleGameStateChanged;
    }

    private void OnDestroy()
    {
        // Desuscribirse para evitar errores cuando se recargue la escena
        GameManager.OnGameStateChanged -= HandleGameStateChanged;
    }

    // Update is called once per frame
    public void PausedGame()
    {
        GameManager.Instance.PauseGame();
    }

    public void ResumeGame()
    {
        GameManager.Instance.ResumeGame();
    }

    public void EndGame()
    {
        GameManager.Instance.ReturnToMainMenu();
    }

    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }

    void HandleGameStateChanged(GameManager.GameState newState)
    {
        if (gameOverPanel != null)
        {
            // Activa el panel solo si el estado es GameOver
            gameOverPanel.SetActive(newState == GameManager.GameState.GameOver);

        }
        if (pauseButton != null)
        {
            // Desactiva el botón solo si el estado es GameOver
            pauseButton.SetActive(newState != GameManager.GameState.GameOver);
        }
    }

}
