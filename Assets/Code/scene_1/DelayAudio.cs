using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace scene_1
{
    public class DelayAudio : MonoBehaviour
    {
        public AudioSource audioSource;
        public float delay;

        void Start()
        {
            Invoke("PlayDelayed", delay);
        }

        void PlayDelayed()
        {
            audioSource.Play();
        }
    }
}