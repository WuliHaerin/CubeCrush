using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deActiveAll : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnCollisionEnter(Collision other)
	{	
		if(other.gameObject.tag=="co" || other.gameObject.tag=="enemy"  ||other.gameObject.tag=="die")  //die
		{		
			spawnObject.instance.DespanFx(other.gameObject);
		}

	}
	// fallo camara

	void OnTriggerEnter(Collider other)
	{
		if(other.tag!="floor" && other.tag!="no"  && other.tag!="lco"  && other.tag!="rco" )
		{
			spawnObject.instance.DespanFx(other.gameObject);	
		}
	}

}
