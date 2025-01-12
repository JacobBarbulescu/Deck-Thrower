using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//A class used to represent an Audio Source
[System.Serializable]
public class Audio
{
    //A name used to refer to the audioSource
    public string name;

    //The actual audio clip to be used
    public AudioClip clip;

    //The volume of the audioSource
    [Range(0f, 1f)]
    public float volume = 1f;

    //The pitch of the audioSource
    [Range(.1f, 3f)]
    public float pitch = 1f;

    public bool loop;

    //The audioSource (used to actually have Unity play audio)
    [HideInInspector]
    public AudioSource source;
}
