using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottomController : MonoBehaviour
{
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
        transform.position = new Vector2(startXPos + Mathf.Sin(Time.realtimeSinceStartup) * 2f, startYPos);
    }
}
