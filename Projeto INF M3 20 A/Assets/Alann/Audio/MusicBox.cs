using UnityEngine.Audio;
using UnityEngine;
using System;

public class MusicBox : MonoBehaviour
{
    public static MusicBox instance { get; private set; }

    public Sound[] sounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyObject(gameObject);
        }

        foreach( Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audio;
            s.source.volume = s.audioVolume;
            s.source.pitch = s.audioPitch;
            s.source.loop = s.audioloop;

        }
    }

    void Start()
    {
        Play("StarlightZone");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.audioName == name);
        s.source.Play();
    }


}
