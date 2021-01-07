using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource soundtrack;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        soundtrack = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (soundtrack.isPlaying) return;
        soundtrack.Play();
    }

    public void StopMusic()
    {
        soundtrack.Stop();
    }
}
