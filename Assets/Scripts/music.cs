using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 public class music : MonoBehaviour
{
    private AudioSource _audioSource;
    private static music musicInstance;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        if (musicInstance == null)
        {
            musicInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _audioSource = GetComponent<AudioSource>();
        PlayMusic();
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
