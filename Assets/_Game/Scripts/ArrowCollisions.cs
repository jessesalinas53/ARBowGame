using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollisions : MonoBehaviour
{
    public AudioSource hitAudio;
    public ParticleSystem hitParticles;


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Target>() != null)
        {
            var value = collision.gameObject.GetComponent<Target>().Value;

            GameManager.Instance.Score += value;

            hitAudio.Play();
            hitParticles.Play();
            GetComponent<Collider>().enabled = false;
            Destroy(gameObject, 1f);
        }
        else
        {
            Destroy(gameObject, 3f);
        }
    }
}
