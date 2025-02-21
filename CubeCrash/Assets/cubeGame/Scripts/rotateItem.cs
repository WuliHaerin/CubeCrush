using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateItem : MonoBehaviour {


	public float speed = 30;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	void FixedUpdate()
	{
		transform.Rotate (Vector3.forward * Time.deltaTime*speed);
	}
}
