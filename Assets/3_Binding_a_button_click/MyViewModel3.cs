﻿using UnityEngine;
using System.Collections;
using UnityUI.Binding;
using System;

[Binding]
public class MyViewModel3 : MonoBehaviour
{
    private float cubeRotation = 0f;

    [Binding]
    public void RotateCube()
    {
        cubeRotation = cubeRotation + 10f;
    }

    void Update ()
    {
        var cube = GameObject.Find("Cube");
        cube.transform.localEulerAngles = new Vector3(0f, cubeRotation, 0f);
	}
}
