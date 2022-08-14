using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : GenericSingleton<SoundManager>
{
    
    public SoundType[] sounds;

    public AudioSource SFXMusic;
    public AudioSource BgMusic;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PlayBgMusic(SoundName.BgMusic);
    }

    public void PlaySFX(SoundName sound)
    {
        AudioClip clip = getAudioClip(sound);
        if(clip != null)
        {
            SFXMusic.PlayOneShot(clip);
        }
        else
        {
            return;
        }

    }

    public void PlayBgMusic(SoundName sound)
    {
        AudioClip clip = getAudioClip(sound);
        if (clip != null)
        {
            BgMusic.clip = clip;
            BgMusic.Play();
        }
        else
        {
            return;
        }

    }

    public AudioClip getAudioClip (SoundName name)
    {
        SoundType SoundName = Array.Find(sounds, item => item.soundName == name);
        if(SoundName != null)
        {
            return SoundName.audioClip;
        }
        else
        {
            return null;
        }
    }


}

[Serializable]
public class SoundType
{
    public  AudioClip audioClip;
    public SoundName soundName;
}
public enum SoundName
{
    redFoodConsume,
    greenFoodConsume,
    Death,
    BgMusic,
    ButtonClick
}
