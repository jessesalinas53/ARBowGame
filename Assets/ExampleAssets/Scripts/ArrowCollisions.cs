using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollisions : MonoBehaviour
{
    GameObject gameController;

    private void Start()
    {
        gameController = GameObject.Find("GameController");
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Bullseye")
        {
            Debug.Log("Hit Bullseye");
            gameController.GetComponent<Score>().AddScore(75);
            //add particles
            //add sound
            Destroy(gameObject);
        }

        if (collision.gameObject.name == "Ring 1")
        {
            Debug.Log("Hit Ring 1");
            gameController.GetComponent<Score>().AddScore(40);
            Destroy(gameObject);
        }

        if (collision.gameObject.name == "Ring 2")
        {
            Debug.Log("Hit Ring 2");
            gameController.GetComponent<Score>().AddScore(25);
            Destroy(gameObject);
        }

        if (collision.gameObject.name == "Ring 3")
        {
            Debug.Log("Hit Ring 3");
            gameController.GetComponent<Score>().AddScore(15);
            Destroy(gameObject);
        }

        if (collision.gameObject.name == "Ring 4")
        {
            Debug.Log("Hit Ring 4");
            gameController.GetComponent<Score>().AddScore(10);
            Destroy(gameObject);
        }

        if (collision.gameObject.name == "Ground")
        {
            Debug.Log("Hit Ground");
            Destroy(gameObject);
        }
    }
}
