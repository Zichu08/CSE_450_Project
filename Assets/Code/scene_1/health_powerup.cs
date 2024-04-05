using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace scene_1
{
    public class Health_Powerup : MonoBehaviour
    {
        public static float secondsActive = 5f;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector2(-11.6f, 2.51f + Mathf.Sin(Time.realtimeSinceStartup) * 0.25f);
        }

        public float GetSecondsActive()
        {
            return secondsActive;
        }
    }

}
