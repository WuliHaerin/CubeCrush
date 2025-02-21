using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy01 : MonoBehaviour {

	public float moveSpeed;

	public float lifeTime;
	private float Temp=0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (GameManger.instace.isOver)
			return;
		transform.Translate (Vector3.forward * Time.deltaTime * moveSpeed);
		Temp += Time.deltaTime;	
		if(Temp>lifeTime)
		{			
			Temp = 0;		
			spawnObject.instance.CreatFx("HeroDieExplosion",transform);
			spawnObject.instance.DespanFx (this.gameObject);
		}		
	}



							
	void OnCollisionEnter(Collision collision) 
	{		
		if(collision.collider.tag.Equals("co"))
		{
			spawnObject.instance.DespanFx (this.gameObject);
		}
	}





}
