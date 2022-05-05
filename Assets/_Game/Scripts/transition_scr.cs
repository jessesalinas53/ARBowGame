using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transition_scr : MonoBehaviour
{

    public float speed;

    public bool up;

    Vector3 bottom;
    Vector3 top;

    bool atTop;
    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name != "MainMenu")
        {
            speed = 7500;
        }

        atTop = true;
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "MenuScene" || GameObject.Find("cvs_Menu") != null)
        {
            bottom = new Vector3(0, -2215, 0);
            top = new Vector3(0, 2800, 0);

            if (gameObject.GetComponent<RectTransform>().localPosition == top)
            {
                atTop = true;
                speed = 0;
                gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0, 2800, 0);
            }

            if (gameObject.GetComponent<RectTransform>().localPosition == bottom)
            {
                atTop = false;
                speed = 0;
                gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0, -2500, 0);
            }

            if (atTop == true)
            {
                gameObject.GetComponent<RectTransform>().localPosition = Vector3.MoveTowards(gameObject.GetComponent<RectTransform>().localPosition, bottom, Time.deltaTime * speed);
            }
            if (atTop == false)
            {
                gameObject.GetComponent<RectTransform>().localPosition = Vector3.MoveTowards(gameObject.GetComponent<RectTransform>().localPosition, top, Time.deltaTime * speed);
            }
        }


        if (GameObject.Find("cvs_Game") != null)
        {
            if (up == true)
            {
                gameObject.GetComponent<RectTransform>().localPosition = new Vector3(gameObject.GetComponent<RectTransform>().localPosition.x, gameObject.GetComponent<RectTransform>().localPosition.y + 25, gameObject.GetComponent<RectTransform>().localPosition.z);
            }

            if (up == false)
            {
                gameObject.GetComponent<RectTransform>().localPosition = new Vector3(gameObject.GetComponent<RectTransform>().localPosition.x, gameObject.GetComponent<RectTransform>().localPosition.y - 25, gameObject.GetComponent<RectTransform>().localPosition.z);
            }
        }
    }
}
