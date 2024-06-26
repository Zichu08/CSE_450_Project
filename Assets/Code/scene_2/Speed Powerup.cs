using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace scene_2
{
    public class SpeedPowerup : MonoBehaviour
    {
        public static float secondsActive = 7.5f;

        private float startXPos;
        private float startYPos;

        // Start is called before the first frame update
        void Start()
        {
            startXPos = transform.position.x;
            startYPos = transform.position.y;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector2(startXPos, startYPos + Mathf.Sin(Time.realtimeSinceStartup) * 0.25f);
        }

        public float GetSecondsActive()
        {
            return secondsActive;
        }
    }
}
