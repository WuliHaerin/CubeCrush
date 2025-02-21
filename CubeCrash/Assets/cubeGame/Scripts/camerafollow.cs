using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour {

	 Vector3 offset;
	 Transform player;
		bool canStart = false;
     void Start()
    {
		canStart = false;
		StartCoroutine (waitTofind());
	}
	
	 void Update()
	 {
		if(canStart)
		{
			if(player!=null)
			transform.position = Vector3.Lerp(transform.position, player.position - offset,Time.deltaTime*5);
		}

	 }


	IEnumerator waitTofind()
	{
		yield return new WaitForSeconds (0.4f);
		player = GameObject.FindWithTag ("hero").transform;
		offset = player.position - transform.position;
		canStart = true; 

	}


}
