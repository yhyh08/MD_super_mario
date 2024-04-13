using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource sfxPlayer;

    void Start()
    {
        sfxPlayer = gameObject.GetComponent<AudioSource>();
    }

    public void PlaySoundFX(AudioClip audio)
    {
        sfxPlayer.PlayOneShot(audio);
    }
}
