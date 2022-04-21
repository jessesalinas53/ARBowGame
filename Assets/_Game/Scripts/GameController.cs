using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetTimeScale(0);
    }

    public void SetTimeScale(int scale)
    {
        Time.timeScale = scale;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(0);
    }
}
