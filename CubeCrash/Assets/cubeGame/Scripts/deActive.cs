using UnityEngine;
using System.Collections;


public class deActive : MonoBehaviour {

	public float life = 0.5f;
	float tmp;
	public string fxpoolName = "fx";

	// Use this for initialization
	void Start () {
	
	}
//	
	// Update is called once per frame
	void Update () {

		tmp += Time.unscaledDeltaTime;	
		if(tmp>life)
		{
			tmp = 0;
			this.gameObject.SetActive (false);
		}	
	}
}
