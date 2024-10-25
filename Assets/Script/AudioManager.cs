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
    public AudioClip gameMusic;
    public AudioClip boilingWaterSfx;
    public AudioClip cracklingFireSfx;
    public AudioClip poppingBubblesSfx;
    public AudioClip flowingWaterSfx;
    public AudioClip toiletFlushSfx;
    public AudioClip fireRefuelSfx;
    public AudioClip fireBlowSfx;
    public AudioClip leverActivationSfx;
    public AudioClip victorySfx;
    public AudioClip failSfx;

    public List<AudioClip> randomWaterSfxSounds = new List<AudioClip>();
    public List<AudioClip> randomValveSfxSounds = new List<AudioClip>();
    
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
    
    //void Start()
    //{
    //    musicAudioSource.clip = gameMusic;
    //    musicAudioSource.Play();
    //}
    
    public void PlaySfxOneShot(AudioClip sfxToPlay)
    {
        sfxAudioSource.PlayOneShot(sfxToPlay);
    }

    public void PlayRandomSfx(List<AudioClip> randomSfxList)
    {
        AudioClip randomSfxToPlay = randomSfxList[Random.Range(0, randomSfxList.Count)];
        
        sfxAudioSource.PlayOneShot(randomSfxToPlay);
    }
}
