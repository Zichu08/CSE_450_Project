using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    public static string powerupID = "BULLET_POWERUP";
    public static float secondsActive = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(-2.63f, -5.99f + Mathf.Sin(Time.realtimeSinceStartup) * 0.25f);
    }

    public float GetSecondsActive()
    {
        return secondsActive;
    }

    public string GetPowerupID()
    {
        return powerupID;
    }
}
