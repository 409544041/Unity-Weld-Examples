﻿using UnityEngine;
using System.Collections;
using UnityUI.Binding;
using System.ComponentModel;
using System;
using UnityEngine.UI;

[Binding]
public class ValidationViewModel : MonoBehaviour, INotifyPropertyChanged
{
    private float sliderValue = 2.5f;

    [Binding]
    public float SliderValue
    {
        get
        {
            return sliderValue;
        }
        set
        {
            if (sliderValue == value)
            {
                return; // No change.
            }

            sliderValue = value;
            SliderValueStr = value.ToString();

            rotatingCube.transform.localEulerAngles = new Vector3(0f, sliderValue, 0f);

            OnPropertyChanged("SliderValue");
        }
    }

    private string sliderValueStr = "2.5";

    /// <summary>
    /// Tracks when the text value is valid.
    /// </summary>
    private bool sliderValueStrValid = true;

    /// <summary>
    /// Cube that rotates based on the sliders
    /// </summary>
    private GameObject rotatingCube;

    [Binding]
    public string SliderValueStr
    {
        get
        {
            return sliderValueStr;
        }
        set
        {
            if (sliderValueStr == value)
            {
                return; // No change.
            }

            sliderValueStr = value;

            try
            {
                SliderValue = float.Parse(value);
                sliderValueStrValid = true;
            }
            catch (FormatException)
            {
                sliderValueStrValid = false;
            }

            OnPropertyChanged("SliderValueStr");
            OnPropertyChanged("SliderValueStrValid");
        }
    }

    [Binding]
    public bool SliderValueStrValid
    {
        get
        {
            return sliderValueStrValid;
        }
    }

    /// <summary>
    /// Event to raise when a property's value has changed.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    // Use this for initialization
    void Start()
    {
        rotatingCube = GameObject.Find("Cube");
        rotatingCube.transform.localEulerAngles = new Vector3(0f, sliderValue, 0f); //todo: Need a vector adaptor.
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
