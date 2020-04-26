﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSounds : MonoBehaviour
{
    private AudioSource source;

    public AudioClip[] clips;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        int randomNumber = Random.Range(0, clips.Length);
        source.clip = clips[randomNumber];
        source.Play();
    }
}
