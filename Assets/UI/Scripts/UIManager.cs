using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private TMP_Text timerText;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseMenuBox;
    [SerializeField] private GameObject optiosMenu;

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
}
