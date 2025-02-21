using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour {


	Transform thiTrans;
	public float moveSpeed;

	public float life;
	float temp;
	// Use this for initialization
	void Start () {

		thiTrans = this.transform;
	}
	
	// Update is called once per frame
	void Update () {

		temp += Time.deltaTime;
		if(temp>life)
		{
			temp = 0;
			spawnObject.instance.DespanFx (gameObject);
			//this.gameObject.SetActive (false);
		}
		thiTrans.Translate (Vector3.forward * moveSpeed*Time.deltaTime);

	}


	void OnTriggerEnter(Collider other)
	{
		if(other.tag=="co")
		{
			spawnObject.instance.DespanFx (this.gameObject);
			spawnObject.instance.CreatFx("HeroDieExplosion",transform.position);
			GameManger.instace.playSound (9);
		}

		if(this.tag!="bullet") 
		{
			if(other.CompareTag("enemy"))
			{
				spawnObject.instance.DespanFx (this.gameObject);
				spawnObject.instance.CreatFx("HeroDieExplosion",transform.position);
				spawnObject.instance.DespanFx (other.gameObject);
				GameManger.instace.playSound (9);
			}
		}

	}


}
