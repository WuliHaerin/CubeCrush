using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvCreate : MonoBehaviour {

	GameObject go;
	GameObject map1;
	bool isCreate ;
	int r ;
	// Use this for initialization
	void Start () {
		 r = Random.Range (0, 1);
	}
	

	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider other)
	{		
		if(other.tag.Equals("hero"))
		{	

			switch(r)
			{
			case 0:
				go = spawnObject.instance.GetCreatFx ("floor01", Vector3.zero).gameObject;
				break;
			case 1:
				go = spawnObject.instance.GetCreatFx ("floor02", Vector3.zero).gameObject;
				break;
			case 2:
				go = spawnObject.instance.GetCreatFx ("floor03", Vector3.zero).gameObject;
				break;
			case 3:
				go = spawnObject.instance.GetCreatFx ("floor04", Vector3.zero).gameObject;
				break;
			case 4:
				go = spawnObject.instance.GetCreatFx ("floor04", Vector3.zero).gameObject;
				break;
			}	
				
			GameObject map1	= spawnObject.instance.GetCreatFx("map1",Vector3.zero).gameObject;		
			map1.transform.position = new Vector3 (-4, 0, this.transform.position.z + 20.5f);
			map1.GetComponent<mapCreator> ().createBlock ();
			map1.transform.parent = null;
			go.transform.position = new Vector3 (0.5f, -1, transform.position.z + 40);
		}
	}
}
