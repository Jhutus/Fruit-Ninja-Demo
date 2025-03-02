using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int score = 0;
    public event Action<int> OnScoreUpdated; // Evento para notificar cambios

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(score<0){
            EndGame();
        }
    }
    public void AddScore(int amount)
    {
        score += amount;
        OnScoreUpdated?.Invoke(score); // Notifica a la UI que el puntaje cambió 
    }

    public int GetScore()
    {
        return score;
    }

    public void RestartScore()
    {
        score = 0;
    }

    private void EndGame()
    {
        GameManager.Instance.GameOver();
    }
}