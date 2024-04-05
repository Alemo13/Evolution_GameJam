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

    public static GameManager Instance;

    public float gampleyTime;

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

    public void UpdateScore(int scoreValue)
    {
        score += scoreValue;
        
        //Update ui score

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

        score = 0;
        playerEvolution = 0;
        player = GameObject.Find("Slime");

        if (player != null)
        {
            playerMovement = player.GetComponent<PlayerMovement>();
            evolutionHandler = player.GetComponent<EvolutionHandler>();
        }
        else { Debug.Log("Player not found"); }

        StartCoroutine(GameplayCountDown());
    }

    private IEnumerator GameplayCountDown()
    {
        timeRemaining = gampleyTime;
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(0.2f);
            timeRemaining--;
            //Update ui timer
        }

        if(timeRemaining <= 0)
        {
            //Player lose
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
        if (buildIndex == 1)
        {
            yield return new WaitForSeconds(0.3f);
            GameManager.Instance.InitializeGame();
        }
    }

    public void GamePause()
    {

    }

    public void GameResume()
    {

    }

    public void GameWin()
    {

    }

    public void GameLose()
    {

    }
}
