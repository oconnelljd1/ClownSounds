using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SoundController
{
    public class SoundButton : MonoBehaviour
    {

        [SerializeField] private Button button;
        [SerializeField] private AudioClip clip;
        // Start is called before the first frame update
        void Awake()
        {
           button.onClick.AddListener(PlaySound);
        }

        void Destroy()
        {
            button.onClick.RemoveListener(PlaySound);
        }

        public void PlaySound()
        {
            SoundController.Instance.PlaySound(clip);
        }
    }
}