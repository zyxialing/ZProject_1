﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMono : MonoBehaviour
{
    public float speed = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward* speed, Space.World);
    }
}
