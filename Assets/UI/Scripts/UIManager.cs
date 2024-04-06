using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text winCoinText;
    [SerializeField] private TMP_Text loseCoinText;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseMenuBox;
    [SerializeField] private GameObject optiosMenu;
    [SerializeField] private GameObject winGameMenu;
    [SerializeField] private GameObject loseGameMenu;

    public void UpdateTimer(float time)
    {
        timerText.text = time.ToString();
    }

    public void UpdateCoinCount(int coins)
    {
        coinText.text = coins.ToString();
    }

    public void PauseGame(bool isPause)
    {
        pauseMenu.SetActive(isPause);
        pauseMenuBox.SetActive(isPause);

        if (!isPause) optiosMenu.SetActive(false);
    }

    public void WinGame(int score)
    {
        winGameMenu.SetActive(true);
        winCoinText.text = score.ToString();
    }

    public void GameOver(int score)
    {
        loseGameMenu.SetActive(true);
        loseCoinText.text = score.ToString();
    }
}
