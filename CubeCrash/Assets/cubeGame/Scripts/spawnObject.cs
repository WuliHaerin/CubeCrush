using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawnObject : MonoBehaviour {

	public static spawnObject instance;
	void Awake()
	{
		instance = this;
	}



	/// <summary>
	/// Creats the fx. prefab pool name "fx"
	/// </summary>
	/// <param name="fxName">Fx name.</param>
	/// <param name="taget">Taget.</param>
	/// <param name="offset">Offset.</param>
	public void CreatFx (string fxName, Transform taget, Vector3 offset)
	{
		poolManager.instance.GetGameObject (fxName, taget.transform.position + offset);;
	}
	public void CreatFx (string fxName, Transform taget)
	{
		poolManager.instance.GetGameObject (fxName, taget.position);
	}

	public void CreatFx (string fxName, Vector3 offset, Quaternion rotation )
	{

	}

	public void CreatFx (string fxName, Vector3 offset )
	{
		
		poolManager.instance.GetGameObject (fxName, offset);
	}

	public Transform GetCreatFx (string fxName, Transform taget, Vector3 offset)
	{
		
		return poolManager.instance.GetGameObject (fxName,taget.transform.position + offset).transform;;
	}

	public Transform GetCreatFx (string fxName, Transform taget)
	{

		return null;
	}

	public Transform GetCreatFx (string fxName,  Vector3 offset )
	{			
		return poolManager.instance.GetGameObject (fxName, offset).transform;
	}

	public void DespanFx(GameObject go)
	{
		go.SetActive (false);	
	}


}
