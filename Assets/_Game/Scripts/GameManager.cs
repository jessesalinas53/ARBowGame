using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    [SerializeField] public int Score = 0;
    [SerializeField] public int HighScore = 0;

    [SerializeField] private int _currentScene = 0;
    public int CurrentScene => _currentScene;

    [SerializeField] private GameObject _menuCanvas = null;
    [SerializeField] private GameObject _gameCanvas = null;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip _backgroundGameAudio = null;

    private Timer _timer;
    private ScoreCounter _scoreCounter;
    private TouchInput _touchInput;

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;

        if (!Instance)
        {
            Debug.Log("This: " + this.gameObject.name);
            Instance = this;
        }
        else
        {
            Debug.Log("Destroyed: " + this.gameObject.name);
            Destroy(gameObject);
        }

        _timer = GetComponent<Timer>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _touchInput = GetComponent<TouchInput>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _currentScene = scene.buildIndex;

        if (_currentScene == 1)
        {
            //AudioManager.Instance.Play3DSound(_backgroundGameAudio);
            _menuCanvas.SetActive(false);
            _gameCanvas.SetActive(true);
            _timer.timerIsRunning = true;
            _touchInput.enabled = true;
        }
        else
        {
            AudioManager.Instance.Play3DSound(_backgroundGameAudio);
            Instance.HighScore = PlayerPrefs.GetInt("High Score");
            Instance.Score = 0;
            _scoreCounter.OnGameLoad();
            _timer.timerIsRunning = false;
            _touchInput.enabled = false;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        //StartCoroutine(load(1));
        //GameObject.Find("transition_obj").GetComponent<transition_scr>().speed = 7500;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
        //StartCoroutine(load(0));
        //GameObject.Find("transition_obj").GetComponent<transition_scr>().speed = 7500;
    }

    IEnumerator load(int scene_num)
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(scene_num);
    }

    public void GameOver()
    {
        _menuCanvas.SetActive(true);
        _gameCanvas.SetActive(false);
        _touchInput.enabled = false;
        
        FindObjectOfType<Webcam>().StopWebCam();

        _scoreCounter.UpdateScoreText();
    }
}
