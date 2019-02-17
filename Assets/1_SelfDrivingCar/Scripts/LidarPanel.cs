using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using SocketIO;
using UnityStandardAssets.Vehicles.Car;
using System;
using System.Security.AccessControl;

public class LidarPanel : MonoBehaviour
{
        //Defines the initial value of the lidar sensor and the settings in the lidar menu
    public float numberOfLasersVal = 64f;
    public float rotationSpeedHzVal = 1f;
    public float rotationAnglePerStepVal = 0.9f;
    public float rayDistanceVal = 200f;
    public float upperFOVVal = 10.5f;
    public float lowerFOVVal = 16f;
    public float offsetVal = 7.24f;
    public float upperNormalVal = -3.3f;
    public float lowerNormalVal = 16.87f;

    // public Slider numberOfLasers;
    // public Slider rotationSpeedHz;
    // public Slider rotationAnglePerStep;
    // public Slider rayDistance;
    // public Slider upperFOV;
    // public Slider lowerFOV;
    // public Slider offset;
    // public Slider upperNormal;
    // public Slider lowerNormal;

    void Awake(){

    }
    void OnDestroy()
    {

    }
    void Start(){

    }
}