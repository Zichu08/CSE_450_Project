using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    public static game_manager instance;
    public Character[] p1_characters;
    public Character[] p2_characters;
    public Character selected_p1;
    public Character selected_p2;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (p1_characters.Length > 0 && selected_p1 == null)
        {
            selected_p1 = p1_characters[0];
        }
        if (p2_characters.Length > 0 && selected_p2 == null)
        {
            selected_p2 =  p2_characters[0];
        }
    }

    public void SetP1(Character character)
    {
        selected_p1 = character;
    }

    public void SetP2(Character character)
    {
        selected_p2 = character;
    }
}
