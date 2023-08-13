﻿using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The audio manager
/// </summary>
public static class AudioManager
{
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    /// <summary>
    /// Gets whether or not the audio manager has been initialized
    /// </summary>
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
        audioClips.Add(AudioClipName.MenuButtonClick,               Resources.Load<AudioClip>("Audios/MenuButtonClick"));
        audioClips.Add(AudioClipName.BallSpawn,                     Resources.Load<AudioClip>("Audios/BallSpawn"));
        audioClips.Add(AudioClipName.BallCollision,                 Resources.Load<AudioClip>("Audios/BallCollision"));
        audioClips.Add(AudioClipName.BallLost,                      Resources.Load<AudioClip>("Audios/BallLost"));
        audioClips.Add(AudioClipName.FreezerEffectActivated,        Resources.Load<AudioClip>("Audios/FreezerEffectActivated"));
        audioClips.Add(AudioClipName.FreezerEffectDeactivated,      Resources.Load<AudioClip>("Audios/FreezerEffectDeactivated"));
        audioClips.Add(AudioClipName.SpeedupEffectActivated,        Resources.Load<AudioClip>("Audios/SpeedupEffectActivated"));
        audioClips.Add(AudioClipName.SpeedupEffectDeactivated,      Resources.Load<AudioClip>("Audios/SpeedupEffectDeactivated"));
        audioClips.Add(AudioClipName.GameLost,                      Resources.Load<AudioClip>("Audios/GameLost"));
    }

    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}
