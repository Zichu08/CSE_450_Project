using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace scene_2
{
    public class SpeedPowerup : MonoBehaviour
    {
        public static float secondsActive = 7.5f;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector2(-9.02f, -6.85f + Mathf.Sin(Time.realtimeSinceStartup) * 0.25f);
        }

        public float GetSecondsActive()
        {
            return secondsActive;
        }
    }
}
