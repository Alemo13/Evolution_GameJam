using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Scene Loading")]
    [SerializeField] private Animator loadingScreenAnimator;

    private int score = 0;
    private int playerEvolution = 0;
    private float timeRemaining;
    private GameObject player;
    private EvolutionHandler evolutionHandler;
    private PlayerMovement playerMovement;

    private UIManager uiManager;

    public static GameManager Instance;

    public float gampleyTime;

    private bool isPause;
    private bool isPlaying = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

    }

    private void Update()
    {
        PauseGame();
    }

    public void UpdateScore(int scoreValue)
    {
        score += scoreValue;
        
        uiManager.UpdateCoinCount(score);

        if(playerEvolution != 0 && score < 50)
        {
            playerEvolution = 0;
            evolutionHandler.SetEvolution(0);
            //Play evolution Sound
        }
        else if (playerEvolution != 1 && (50 < score && score < 100))
        {
            playerEvolution = 1;
            evolutionHandler.SetEvolution(1);
            //Play evolution Sound
        }
        else if (playerEvolution != 2 && (100 < score && score < 150))
        {
            playerEvolution = 2;
            evolutionHandler.SetEvolution(2);
            //Play evolution Sound
        }
        else if (playerEvolution != 3 && (150 < score && score < 200))
        {
            playerEvolution = 3;
            evolutionHandler.SetEvolution(3);
            //Play evolution Sound
        }
    }

    [ContextMenu("Inicialice")]
    public void InitializeGame()
    {
        StopAllCoroutines();

        isPlaying = true;

        //Debug.Log("si esta jugando? " + isPlaying);

        score = 0;
        playerEvolution = 0;
        player = GameObject.Find("Slime");

        if (player != null)
        {
            playerMovement = player.GetComponent<PlayerMovement>();
            evolutionHandler = player.GetComponent<EvolutionHandler>();
        }
        else { Debug.Log("Player not found"); }

        uiManager = FindAnyObjectByType<UIManager>();
        if (uiManager == null) Debug.Log("No se encontro el UI manager rey");

        StartCoroutine(GameplayCountDown());
    }

    private IEnumerator GameplayCountDown()
    {
        timeRemaining = gampleyTime;
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1.0f);
            timeRemaining--;
            uiManager.UpdateTimer(timeRemaining);
        }

        if(timeRemaining <= 0)
        {
            GameLose();
        }
    }

    public void LoadGameScene(int buildIndex)
    {
        StartCoroutine(LoadLevelCoroutine(buildIndex));
    }

    private IEnumerator LoadLevelCoroutine(int buildIndex)
    {
        //loadingScreenAnimator.SetTrigger("End");
        yield return new WaitForSecondsRealtime(0.3f);
        SceneManager.LoadSceneAsync(buildIndex);
        //loadingScreenAnimator.SetTrigger("Start");

        ResumeTime();

        if (buildIndex == 1)
        {
            yield return new WaitForSeconds(0.3f);
            Debug.Log("");
            GameManager.Instance.InitializeGame();
        }
    }

    public void PauseGame()
    {
        if (isPlaying && Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                isPause = false;
                Time.timeScale = 1.0f;

            }
            else 
            { 
                isPause = true;
                Time.timeScale = 0.0f;
            }

            //Debug.Log("Si entro? " + isPause);

            uiManager.PauseGame(isPause);
            playerMovement.PausePlayerMovement(isPause);
        }
    }

    public void ResumeTime()
    {
        Time.timeScale = 1.0f;
    }

    [ContextMenu("Gano mi rey")]
    public void GameWin()
    {
        isPlaying = false;
        playerMovement.StopPlayer();
        uiManager.WinGame(score);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void GameLose()
    {
        isPlaying = false;
        playerMovement.StopPlayer();
        uiManager.GameOver(score);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
