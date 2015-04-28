using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		gameObject.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		DetermineVulnerablility();
	}

	void DetermineVulnerablility()
	{

		if(RandomSpawner.ticker == 0)
		{
			gameObject.renderer.enabled = true;
			SphereCollider coll = gameObject.GetComponent<SphereCollider>();
			coll.enabled = true;

		}//end if
	}//end DetermineVulnerability

}


