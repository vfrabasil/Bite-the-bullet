using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioClip impactOnShield;
    public AudioClip impactOnPlanet;
    public static float volume=0.5f;

    private AudioSource audioSource;

    void Start()
    {
        //impactOnShield = Resources.Load<AudioClip>("Sounds\\impactOnShield");
        //impactOnPlanet = Resources.Load<AudioClip>("Sounds\\impactOnPlanet");
        audioSource = GetComponent<AudioSource>();        


    }

    public void PlaySound(string clip)
    {
        switch (clip) {
            case "impactOnShield":
                audioSource.PlayOneShot(impactOnShield);
                break;
            case "impactOnPlanet":
                audioSource.PlayOneShot(impactOnPlanet);
                break;
        }
    }

}
