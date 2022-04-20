using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollisions : MonoBehaviour
{
    GameObject gameController;
    BowController bowController;

    public AudioSource hitAudio;
    public ParticleSystem hitParticles;

    private void Start()
    {
        gameController = GameObject.Find("GameController");
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Target")
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            hitAudio.Play();
            hitParticles.Play();
            Destroy(gameObject, 1f);
        }
        else if (collision.gameObject.name == "Ground")
        {
            Debug.Log("Hit Ground");
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            Destroy(gameObject, .8f);
        }

        if (collision.gameObject.name == "Bullseye")
        {
            Debug.Log("Hit Bullseye");
            gameController.GetComponent<Score>().AddScore(75);
        }

        if (collision.gameObject.name == "Ring 1")
        {
            Debug.Log("Hit Ring 1");
            gameController.GetComponent<Score>().AddScore(40);
        }

        if (collision.gameObject.name == "Ring 2")
        {
            Debug.Log("Hit Ring 2");
            gameController.GetComponent<Score>().AddScore(25);
        }

        if (collision.gameObject.name == "Ring 3")
        {
            Debug.Log("Hit Ring 3");
            gameController.GetComponent<Score>().AddScore(15);
        }

        if (collision.gameObject.name == "Ring 4")
        {
            Debug.Log("Hit Ring 4");
            gameController.GetComponent<Score>().AddScore(10);
        }
    }
}
