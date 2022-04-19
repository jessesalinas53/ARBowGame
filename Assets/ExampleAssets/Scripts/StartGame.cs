using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public GameObject startPanel;

    public void StartButton()
    {
        startPanel.SetActive(false);
    }
}
