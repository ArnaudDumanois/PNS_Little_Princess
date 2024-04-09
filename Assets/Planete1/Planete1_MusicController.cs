using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planete1_MusicController : MonoBehaviour
{
    
    public AudioClip startMusic;
    public AudioClip teleportMusic;
    
    public AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayStartMusic();
    }
    
    public void PlayStartMusic()
    {
        audioSource.clip = startMusic;
        audioSource.Play();
    }
    
    public void PlayTeleportMusic()
    {
        audioSource.clip = teleportMusic;
        audioSource.Play();
    }

}
