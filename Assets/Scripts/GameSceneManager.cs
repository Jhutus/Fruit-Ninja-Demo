using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    void Start()
    {
         if (GameManager.Instance == null)
        {
            Debug.LogError("No se encontró el AudioManager en la escena.");
            return;
        }
    }

    // Update is called once per frame
    public void PausedGame (){
        GameManager.Instance.PauseGame();
    }

    public void ResumeGame(){
        GameManager.Instance.ResumeGame();
    }

    public void EndGame(){
        GameManager.Instance.ReturnToMainMenu();
    }

    public void StartGame(){
        GameManager.Instance.StartGame();
    }
}
