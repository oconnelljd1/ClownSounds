using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundController
{
    public class SoundController : MonoBehaviour
    {
        public static SoundController Instance;
        [SerializeField] private GameObject soundPrefab;
        [SerializeField] private float killTime = 60f;
        [SerializeField] private int soundPool = 10;

        private List<Sound> sounds;
        private PlayMode playMode = PlayMode.Single;

        private 
        // Start is called before the first frame update
        void Awake()
        {
            if(Instance)
                Destroy(gameObject);
            
            Instance = this;

            sounds = new List<Sound>();
            for(int i = 0; i < soundPool; i++)
            {
                SpawnSound();
            }
        }

        // Update is called once per frame
        void Update()
        {
            if(sounds.Count > soundPool)
            {
                for(int i = sounds.Count -1; i > -1; i--)
                {
                    sounds[i].Tick();
                    if(!sounds[i])
                    {
                        sounds.RemoveAt(i);
                    }
                }
            }
        }

        public void PlaySound(AudioClip clip)
        {
            switch(playMode)
            {
                case PlayMode.Single:
                    PlaySingleSound(clip);
                    break;
                case PlayMode.Multiple:
                    PlayMultipleSounds(clip);
                    break;
                case PlayMode.Unlimited:
                    PlayUnlimitedSounds(clip);
                    break;
                default:
                    Debug.Log("Unhandled Play Mode");
                    break;
            }
        }

        public void SetMode(PlayMode mode)
        {
            playMode = mode;
        }

        private void PlaySingleSound(AudioClip clip)
        {
            sounds[0].Init(clip);
        }

        private void PlayMultipleSounds(AudioClip clip)
        {
            Debug.Log("Multiple Mode not implemented");
        }

        private void PlayUnlimitedSounds(AudioClip clip)
        {
            Sound toPlay = null;
            foreach(Sound sound in sounds)
            {
                if(sound.Playing) continue;

                toPlay = sound;
            }
            
            if(toPlay == null) toPlay = SpawnSound();

            toPlay.Init(clip, killTime);
        }

        private Sound SpawnSound()
        {
            Sound sound = Instantiate(soundPrefab, transform).GetComponent<Sound>();
            sounds.Add(sound);
            return sound;
        }
    }

    public enum PlayMode
    {
        None,
        Single,
        Multiple,
        Unlimited
    }
}