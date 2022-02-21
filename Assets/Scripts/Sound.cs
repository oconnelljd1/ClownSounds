using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundController
{
    public class Sound : MonoBehaviour
    {
        [SerializeField]private AudioSource source;
        private float killTime = 0f;
        private float currentTime = 0f;
        public bool Playing => source.isPlaying;

        public void Init(AudioClip clip, float kTime = 0f)
        {
            currentTime = 0;
            killTime = kTime;
            source.clip = clip;
            source.Play();
        }

        public void Tick()
        {
            if(Playing)return;

            currentTime += Time.deltaTime;
            if(currentTime > killTime)
                Destroy(gameObject);
        }
    }
}
