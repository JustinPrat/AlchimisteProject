using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource sfxAudioSource;
    
    [Space]
    [Header("References")]
    public static AudioManager Instance;
    [SerializeField] private GameObject musicSourceObj;
    [SerializeField] private GameObject sfxSourceObj;
    
    [Space]
    [Header("Audio Clips")]
    [SerializeField] private AudioClip gameMusic;
    [SerializeField] private AudioClip boilingWaterSfx;
    [SerializeField] private AudioClip cracklingFireSfx;
    [SerializeField] private AudioClip poppingBubblesSfx;
    [SerializeField] private AudioClip flowingWaterSfx;
    [SerializeField] private AudioClip toiletFlushSfx;
    [SerializeField] private AudioClip fireRefuelSfx;
    [SerializeField] private AudioClip fireBlowSfx;
    [SerializeField] private AudioClip leverActivationSfx;
    [SerializeField] private AudioClip victorySfx;
    [SerializeField] private AudioClip failSfx;
    
    [SerializeField] List<AudioClip> randomWaterSfxSounds = new List<AudioClip>();
    [SerializeField] List<AudioClip> randomValveSfxSounds = new List<AudioClip>();
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        musicSourceObj = GameObject.FindGameObjectWithTag("MusicSource");
        sfxSourceObj = GameObject.FindGameObjectWithTag("SfxSource");
        musicAudioSource = musicSourceObj.GetComponent<AudioSource>();
        sfxAudioSource = sfxSourceObj.GetComponent<AudioSource>();
    }
    
    void Start()
    {
        musicAudioSource.clip = gameMusic;
        musicAudioSource.Play();
    }
    
    void PlaySfxOneShot(AudioClip sfxToPlay)
    {
        sfxAudioSource.PlayOneShot(sfxToPlay);
    }

    void PlayRandomSfx(List<AudioClip> randomSfxList)
    {
        AudioClip randomSfxToPlay = randomSfxList[Random.Range(0, randomSfxList.Count)];
        
        sfxAudioSource.PlayOneShot(randomSfxToPlay);
    }
}
