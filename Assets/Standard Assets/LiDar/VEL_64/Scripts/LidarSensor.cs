/*
* MIT License
* 
* Copyright (c) 2017 Philip Tibom, Jonathan Jansson, Rickard Laurenius, 
* Tobias Alldén, Martin Chemander, Sherry Davar
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE.
*/
using System;
using System.Collections;
using System.IO;
using UnityEngine.EventSystems;
using System.Collections.Generic;

using UnityEngine;

// 使用Google Protobuf
using Google.Protobuf;
using LiDarMsg;
using UnityStandardAssets.Vehicles.Car;
/// <summary>
/// Author: Philip Tibom
/// Simulates the lidar sensor by using ray casting.
/// </summary>
public class LidarSensor:MonoBehaviour
{
    private float lastUpdate = 0;

    private List<Laser> lasers;
    private float horizontalAngle = 0;

    public int numberOfLasers = 2;
    public float rotationSpeedHz = 1.0f;
    public float rotationAnglePerStep = 45.0f;
    public float rayDistance = 100f;
    public float upperFOV = 30f;
    public float lowerFOV = 30f;
    public float offset = 0.001f;
    public float upperNormal = 30f;
    public float lowerNormal = 30f;
    public static event NewPoints OnScanned;
    public delegate void NewPoints(float time, LinkedList<SphericalCoordinate> data);

    public delegate void NewHitPointsTrans(float time, LiDarData hitPoint);
    public static event NewHitPointsTrans HitPointsTrans;
    LinkedList<SphericalCoordinate> hits;

    public float lapTime = 0;

    private static bool isPlaying = false;

    public GameObject pointCloudObject;
    private float previousUpdate;

    private float lastLapTime;

    public GameObject lineDrawerPrefab;

    // 添加扫描区间角度
    
    private float BeginDegree = -90;    //  扫描180度
    private float EndDegree = 90;    //  扫描180度
    LiDarData hitPoints;
    LiDarData hitPointsStore;
    private  int lineId = 0;
    // private static bool pointsIsOK = false;

    // public static bool CheckStatus(){
    //     return pointsIsOK;
    // }
    // public static void ClearStatus(){
    //     pointsIsOK = false;
    // }

    // Use this for initialization
    private void Start()
    {
        lastLapTime = 0;
        // 界面控制
        // LidarMenu.OnPassValuesToC += UpdateSettings;
        // PlayButton.OnPlayToggled += PauseSensor;
        hits = new LinkedList<SphericalCoordinate>();
        hitPoints = new LiDarData();
        hitPointsStore = new  LiDarData();
        InitiateLasers();

        // 添加事件
        CarController.onLaserScanEvent += LaserScan;
    }

    void OnDestroy()
    {
        CarController.onLaserScanEvent -= LaserScan;
        // LidarMenu.OnPassValuesToLidarSensor -= UpdateSettings;
        // PlayButton.OnPlayToggled -= PauseSensor;
    }

    public void UpdateSettings(int numberOfLasers, float rotationSpeedHz, float rotationAnglePerStep, float rayDistance, float upperFOV,
        float lowerFOV, float offset, float upperNormal, float lowerNormal)
    {
        this.numberOfLasers = numberOfLasers;
        this.rotationSpeedHz = rotationSpeedHz;
        this.rotationAnglePerStep = rotationAnglePerStep;
        this.rayDistance = rayDistance;
        this.upperFOV = upperFOV;
        this.lowerFOV = lowerFOV;
        this.offset = offset;
        this.upperNormal = upperNormal;
        this.lowerNormal = lowerNormal;

        InitiateLasers();
    }
    // 镭射点云初始化
    // 初始化项目是角度速度

    private void InitiateLasers()
    {
        // Initialize number of lasers, based on user selection.
        if (lasers != null)
        {
            foreach (Laser l in lasers)
            {
                Destroy(l.GetRenderLine().gameObject);
            }
        }

        lasers = new List<Laser>();

        float upperTotalAngle = upperFOV / 2;
        float lowerTotalAngle = lowerFOV / 2;
        float upperAngle = upperFOV / (numberOfLasers / 2);
        float lowerAngle = lowerFOV / (numberOfLasers / 2);
        offset = (offset / 100) / 2; // Convert offset to centimeters.
        for (int i = 0; i < numberOfLasers; i++)
        {
            GameObject lineDrawer = Instantiate(lineDrawerPrefab);
            lineDrawer.transform.parent = gameObject.transform; // Set parent of drawer to this gameObject.
            if (i < numberOfLasers / 2)
            {
                lasers.Add(new Laser(gameObject, lowerTotalAngle + lowerNormal, rayDistance, -offset, lineDrawer, i));

                lowerTotalAngle -= lowerAngle;
            }
            else
            {
                lasers.Add(new Laser(gameObject, upperTotalAngle - upperNormal, rayDistance, offset, lineDrawer, i));
                upperTotalAngle -= upperAngle;
            }
        }

        // isPlaying = true;
    }

    public static void PauseSensor(bool simulationModeOn)
    {
        // if (!simulationModeOn)
        // {
            isPlaying = simulationModeOn;
            Debug.Log("paly" +  isPlaying);
        // }
    }

    // Update is called once per frame
    private void Update()
    {
        // For debugging, shows visible ray in real time.
        /*
        foreach (Laser laser in lasers)
        {
            laser.DebugDrawRay();
        }
        */
    }
    /**
    * 扫描点云
    */
    public LiDarData LaserScan(){
               
        LiDarData phitPoints = new  LiDarData();
        // 手动控制扫描点云数据
        // 计算旋转角度
        // rotationAnglePerStep = 0;
        float phorizontalAngle = 0;
        int lineId = 0;
        for(int step = 0;step < 120;step++){
            // 进行旋转
            // rotationAnglePerStep
            transform.Rotate(0, rotationAnglePerStep, 0);
            phorizontalAngle += rotationAnglePerStep;

            LiDarLine line = new LiDarLine();
            line.LineID = lineId++;

            int laserid = 0;
            foreach (Laser laser in lasers)
            {
                RaycastHit hit = laser.ShootRay();
                float distance = hit.distance;
                if (distance != 0) // Didn't hit anything, don't add to list.
                {
                    float verticalAngle = laser.GetVerticalAngle();
                    LiDarMsg.Laser laserVal = new LiDarMsg.Laser();
                    laserVal.LaId = laserid++;
                    laserVal.Radius = distance;
                    laserVal.Pitch = verticalAngle;
                    laserVal.Yaw = phorizontalAngle;

                    line.LaserData.Add(laserVal);
                }
            }
            phitPoints.LineData.Add(line);
        }
        return phitPoints;
    }
    
    private void FixedUpdate()
    {
        hits = new LinkedList<SphericalCoordinate>();
        hitPoints = new LiDarData();
        // Do nothing, if the simulator is paused.
        if (!isPlaying)
        {
            return;
        }
        // return;

        // Check if number of steps is greater than possible calculations by unity.
        float numberOfStepsNeededInOneLap = 360 / Mathf.Abs(rotationAnglePerStep);
        float numberOfStepsPossible = 1 / Time.fixedDeltaTime / 5;
        float precalculateIterations = 1;
        // Check if we need to precalculate steps.
        if (numberOfStepsNeededInOneLap > numberOfStepsPossible)
        {
            precalculateIterations = (int)(numberOfStepsNeededInOneLap / numberOfStepsPossible);
            if (360 % precalculateIterations != 0)
            {
                precalculateIterations += 360 % precalculateIterations;
            }
        }

        // Check if it is time to step. Example: 2hz = 2 rotations in a second.
        if (Time.fixedTime - lastUpdate > (1 / (numberOfStepsNeededInOneLap) / rotationSpeedHz) * precalculateIterations)
        {
            // Update current execution time.
            lastUpdate = Time.fixedTime;
            
            for (int i = 0; i < precalculateIterations; i++)
            {
                // Perform rotation.
                transform.Rotate(0, rotationAnglePerStep, 0);
                // 进行旋转
                horizontalAngle += rotationAnglePerStep; // Keep track of our current rotation.
                if (horizontalAngle >= 360)
                {
                    horizontalAngle -= 360;
                    //GameObject.Find("RotSpeedText").GetComponent<Text>().text =  "" + (1/(Time.fixedTime - lastLapTime));
                    lastLapTime = Time.fixedTime;
                    
                    
                    HitPointsTrans(lastLapTime,hitPointsStore);
                    hitPointsStore = new  LiDarData();
                    lineId = 0;
                }

                LiDarLine line = new LiDarLine();
                line.LineID = lineId++;

                // Execute lasers.
                int laserid = 0;
                foreach (Laser laser in lasers)
                {
                    
                    RaycastHit hit = laser.ShootRay();
                    float distance = hit.distance;
                    if (distance != 0) // Didn't hit anything, don't add to list.
                    {
                        float verticalAngle = laser.GetVerticalAngle();
                        LiDarMsg.Laser laserVal = new LiDarMsg.Laser();
                        laserVal.LaId = laserid++;
                        laserVal.Radius = distance;
                        laserVal.Pitch = verticalAngle;
                        laserVal.Yaw = horizontalAngle;

                        line.LaserData.Add(laserVal);
                        hits.AddLast(new SphericalCoordinate(distance, verticalAngle, horizontalAngle, hit.point, laser.GetLaserId()));
                    }
                }
                hitPoints.LineData.Add(line);
            }
            hitPointsStore.LineData.AddRange(hitPoints.LineData);
            
            // Notify listeners that the lidar sensor have scanned points. 
            if (OnScanned != null  && pointCloudObject != null && pointCloudObject.activeInHierarchy)
            {
                OnScanned(lastLapTime, hits);
            }

        }
    }
    private void FixedUpdate_back()
    {
        hits = new LinkedList<SphericalCoordinate>();
        // Do nothing, if the simulator is paused.
        if (!isPlaying)
        {
            return;
        }
        // return;

        // Check if number of steps is greater than possible calculations by unity.
        float numberOfStepsNeededInOneLap = 360 / Mathf.Abs(rotationAnglePerStep);
        float numberOfStepsPossible = 1 / Time.fixedDeltaTime / 5;
        float precalculateIterations = 1;
        // Check if we need to precalculate steps.
        if (numberOfStepsNeededInOneLap > numberOfStepsPossible)
        {
            precalculateIterations = (int)(numberOfStepsNeededInOneLap / numberOfStepsPossible);
            if (360 % precalculateIterations != 0)
            {
                precalculateIterations += 360 % precalculateIterations;
            }
        }

        // Check if it is time to step. Example: 2hz = 2 rotations in a second.
        if (Time.fixedTime - lastUpdate > (1 / (numberOfStepsNeededInOneLap) / rotationSpeedHz) * precalculateIterations)
        {
            // Update current execution time.
            lastUpdate = Time.fixedTime;

            for (int i = 0; i < precalculateIterations; i++)
            {
                // Perform rotation.
                transform.Rotate(0, rotationAnglePerStep, 0);
                horizontalAngle += rotationAnglePerStep; // Keep track of our current rotation.
                if (horizontalAngle >= 360)
                {
                    horizontalAngle -= 360;
                    //GameObject.Find("RotSpeedText").GetComponent<Text>().text =  "" + (1/(Time.fixedTime - lastLapTime));
                    lastLapTime = Time.fixedTime;
                    

                }


                // Execute lasers.
                foreach (Laser laser in lasers)
                {
                    RaycastHit hit = laser.ShootRay();
                    float distance = hit.distance;
                    if (distance != 0) // Didn't hit anything, don't add to list.
                    {
                        float verticalAngle = laser.GetVerticalAngle();
                        hits.AddLast(new SphericalCoordinate(distance, verticalAngle, horizontalAngle, hit.point, laser.GetLaserId()));
                    }
                }
            }


            // Notify listeners that the lidar sensor have scanned points. 
            if (OnScanned != null  && pointCloudObject != null && pointCloudObject.activeInHierarchy)
            {
                OnScanned(lastLapTime, hits);
            }

        }
    }
}
