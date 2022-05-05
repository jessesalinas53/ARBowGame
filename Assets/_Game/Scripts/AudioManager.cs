using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance = null;

    private AudioSource _audioSource;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            _audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Play3DSound(AudioClip clip, AudioSource source = null)
    {
        if (!source)
        {
            if (!_audioSource.isPlaying)
            {
                _audioSource.clip = clip;
                _audioSource.Play();
            }
        }
        else
        {
            source.clip = clip;
            source.Play();
        }
    }

    public void PlayOneShot(AudioClip clip, AudioSource source = null)
    {
        if (!source)
        {
            if (!_audioSource.isPlaying)
            {
                _audioSource.PlayOneShot(clip);
            }
        }
        else
        {
            source.PlayOneShot(clip);
        }
    }
}
