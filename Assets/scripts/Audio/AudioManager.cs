using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The audio manager
/// </summary>
public static class AudioManager
{
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips = new Dictionary<AudioClipName, AudioClip>();


    //gets whether or not its been initialized
    public static bool Initialized
    {
        get { return initialized; }
    }
    /// <summary>
    /// Initializes the audio manager
    /// </summary>
    /// <param name="source">audio source</param>
    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;
        audioClips.Add(AudioClipName.AsteroidHit,
               Resources.Load<AudioClip>("hit"));
        audioClips.Add(AudioClipName.PlayerDeath,
            Resources.Load<AudioClip>("die"));
        audioClips.Add(AudioClipName.PlayerShot,
            Resources.Load<AudioClip>("shoot"));
        audioClips.Add(AudioClipName.MainMenuSong, 
            Resources.Load<AudioClip>("MainMenuSong"));
        audioClips.Add(AudioClipName.FalconFlyBy,
            Resources.Load<AudioClip>("MilleniumFalconFlyby"));
        audioClips.Add(AudioClipName.BigExplosion,
            Resources.Load<AudioClip>("BigExplosion"));
        audioClips.Add(AudioClipName.Lightspeed,
            Resources.Load<AudioClip>("Lightspeed"));
        audioClips.Add(AudioClipName.HyperdriveTrouble,
            Resources.Load<AudioClip>("HyperdriveTrouble"));
        audioClips.Add(AudioClipName.R2happy,
            Resources.Load<AudioClip>("R2happy"));
    }

    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }

    public static void StopClip()
    {
        audioSource.Stop();
    }
  
}
