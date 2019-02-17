using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

public class InputSync : MonoBehaviour 
{
    public Text ShowText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void TExt(){

    }

    public void SyncToText()
    {
		ShowText.text = gameObject.GetComponent<Slider> ().value.ToString ();
        // Debug.Log(gameObject.GetComponent<Slider> ().value.ToString ());
	}
}
