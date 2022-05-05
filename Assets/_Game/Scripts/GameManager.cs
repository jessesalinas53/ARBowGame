using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    [SerializeField] private GameObject _restartPanel = null;
    [SerializeField] private GameObject _gameCanvas = null;

    private Timer _timer;
    private Score _score;
    private TouchInput _touchInput;

    private void Awake()
    {
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
        _score = GetComponent<Score>();
        _touchInput = GetComponent<TouchInput>();
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);

        if (scene.buildIndex == 1)
        {
            _timer.timerIsRunning = true;
            _touchInput.enabled = true;
        }
        else
        {
            _timer.timerIsRunning = false;
            _touchInput.enabled = false;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        _restartPanel.SetActive(true);
        _gameCanvas.SetActive(false);
        _touchInput.enabled = false;
    }
}
