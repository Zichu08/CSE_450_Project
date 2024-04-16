using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformBottomController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(-2.64f + Mathf.Sin(Time.realtimeSinceStartup) * 2f, -7.19f);
    }
}
