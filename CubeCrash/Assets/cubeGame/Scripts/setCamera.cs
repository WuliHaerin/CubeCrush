using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setCamera : MonoBehaviour {

	Canvas canCompt;
	 
	// Use this for initialization
	void Start () {
		canCompt = GetComponent<Canvas> ();
		canCompt.rootCanvas.worldCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
