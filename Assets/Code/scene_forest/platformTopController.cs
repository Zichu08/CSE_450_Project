using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformTopController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(-10.4f + Mathf.Sin(-Time.realtimeSinceStartup) * 3.5f, -0.6800005f);
    }
}
