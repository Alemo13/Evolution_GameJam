using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Scene Loading")]
    [SerializeField] private Animator _loadingScreenAnimator;

    public static GameManager Instance;

    private int _currentLevel;
    public int CurrentLevel => _currentLevel;

    public int score;

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

    }

    public void LoadGameScene(int buildIndex)
    {
        score = 0;
        _loadingScreenAnimator.SetBool("Show", true);
        Slider progressSlider = _loadingScreenAnimator.GetComponentInChildren<Slider>();
        progressSlider.value = 0.0f;
        StartCoroutine(LoadingBar(progressSlider, buildIndex));
    }

    private IEnumerator LoadingBar(Slider slider, int buildIndex)
    {
        yield return new WaitForSeconds(0.5f);
        slider.value += Random.Range(0.1f, 0.4f);
        if (slider.value < 0.9f) StartCoroutine(LoadingBar(slider, buildIndex));
        else
        {
            SceneManager.LoadScene(buildIndex);
            _loadingScreenAnimator.SetBool("Show", false);
        }
    }
}
