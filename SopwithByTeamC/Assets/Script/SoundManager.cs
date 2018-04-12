using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioClip soundFarExplosion1;
    public AudioClip soundFarExplosion2;
    public AudioClip soundNearExplosion1;
    AudioSource myAudio;

    public static SoundManager instance;

    void Awake()
    {
        if (SoundManager.instance == null)
            SoundManager.instance = this;
    }

	// Use this for initialization
	void Start () {
        myAudio = GetComponent<AudioSource>();
    }
    public void PlaySoundFarExplosion1()
    {
        myAudio.PlayOneShot(soundFarExplosion1);
    }
    public void PlaySoundFarExplosion2()
    {
        myAudio.PlayOneShot(soundFarExplosion2);
    }
    public void PlaySoundNearExplosion1()
    {
        myAudio.PlayOneShot(soundNearExplosion1);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
