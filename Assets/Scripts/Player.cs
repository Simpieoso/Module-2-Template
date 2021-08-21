﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject diedText;
    public int health = 100;

    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            diedText.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
