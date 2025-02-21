using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvDeactive : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider other)//这是消除地板的
	{
		if(other.tag.Equals("hero"))
		{	
			spawnObject.instance.DespanFx (this.transform.parent.gameObject);
		}
	}

}
