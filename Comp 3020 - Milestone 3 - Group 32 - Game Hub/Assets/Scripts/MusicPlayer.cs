using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer instance;

    private AudioSource bgms;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            bgms = this.GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    public void PlayMusic()
    {
        if (!bgms.isPlaying)
        {
            bgms.Play();
        }
    }

    public void StopMusic()
    {
        bgms.Stop();
    }
}
