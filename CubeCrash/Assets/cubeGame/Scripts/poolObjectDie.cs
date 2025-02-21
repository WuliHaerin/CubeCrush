using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poolObjectDie : MonoBehaviour {


	public float life = 1;
	float temp;
	public bool isParent;

	// Use this for initialization
	void Start () 
	{		
	}
	
	// Update is called once per frame
	void Update () {
		temp += Time.deltaTime;
		if(temp>life)
		{
			this.gameObject.SetActive (false);
			temp = 0;
		}
	}
}
