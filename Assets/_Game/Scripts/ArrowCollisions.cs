using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollisions : MonoBehaviour
{
    private Score score;

    public AudioSource hitAudio;
    public ParticleSystem hitParticles;

    private void Start()
    {
        score = FindObjectOfType<Score>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Target>() != null)
        {
            var value = collision.gameObject.GetComponent<Target>().Value;

            if (score != null)
            {
                score.AddScore(value);
            }

            hitAudio.Play();
            hitParticles.Play();
            GetComponent<Collider>().enabled = false;
            Destroy(gameObject, 1f);
        }
    }
}
