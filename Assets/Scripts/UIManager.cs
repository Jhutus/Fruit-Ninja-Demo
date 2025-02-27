using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public GameObject mainMenu, pauseMenu, gameOverMenu;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }

    public void ShowMainMenu(bool show) { mainMenu.SetActive(show); }
    public void ShowPauseMenu(bool show) { pauseMenu.SetActive(show); }
    public void ShowGameOverMenu(bool show) { gameOverMenu.SetActive(show); }
}
