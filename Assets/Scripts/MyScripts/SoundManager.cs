using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.MyScripts
{
    public class SoundManager : MonoSingleton<SoundManager>
    {
        [SerializeField] private AudioClip clip;

        [SerializeField] private int audioSourceCount = 5;

        [SerializeField] private Vector2 pitchMinMax = new Vector2(1.75f, 2.8f);

        private List<AudioSource> sourcesList = new List<AudioSource>();


        private void Awake()
        {
            InitializeAudioSources();
        }

        private void InitializeAudioSources()
        {
            for (int i = 0; i < audioSourceCount; i++)
            {
                sourcesList.Add(gameObject.AddComponent<AudioSource>());
            }
        }

        private void OnEnable()
        {
            EventManager.PlaynSpawnSound += PlaySpawnSound;
        }

        private void OnDisable()
        {
            EventManager.PlaynSpawnSound -= PlaySpawnSound;
        }

        private void PlaySpawnSound()
        {
            var allPlaying = true;

            foreach (var audioSource in sourcesList)
            {
                if (audioSource.isPlaying) continue;
                
                audioSource.pitch = Random.Range(pitchMinMax.x, pitchMinMax.y);
                audioSource.PlayOneShot(clip);
                allPlaying = false;
            }

            if (allPlaying)
            {
               var tempSource = gameObject.AddComponent<AudioSource>();
               tempSource.pitch = Random.Range(pitchMinMax.x, pitchMinMax.y);
               tempSource.PlayOneShot(clip);
            }
        } 
    }
}
