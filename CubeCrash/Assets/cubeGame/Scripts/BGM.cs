using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour {

	AudioSource audioComp;

	public static BGM instance;

	// Use this for initialization
	void Start () {


		instance = this;
		audioComp = GameObject.Find ("BGM").GetComponent<AudioSource> ();
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
