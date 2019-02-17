using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

public class PointCloudVisiuale : MonoBehaviour 
{
    private bool visosdas ;

    public GameObject mainCamera;
    public GameObject lidarCamera;
    public GameObject pointCloud;

    void Awake(){
        
        visosdas =false;
        pointCloud.SetActive(visosdas);

    }

    void OnDestroy()
    {

    }

    public void ToggleManst(){
        
		if (!visosdas)
        {
           	mainCamera.GetComponent<Camera>().rect = new Rect(0, 0, 1, 1);
        }
        else
        {
            mainCamera.GetComponent<Camera>().rect = new Rect(0, 0, 0.5f, 1);
            // 显示点云

        }
        pointCloud.SetActive(visosdas);
        mainCamera.GetComponent<Camera>().enabled = true;
        visosdas = !visosdas;
        // Debug.Log(visosdas);

    }
}