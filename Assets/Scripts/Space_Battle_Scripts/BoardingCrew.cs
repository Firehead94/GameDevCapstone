using UnityEngine;
using System.Collections;

public class BoardingCrew : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider coll)
	{
		if(coll.gameObject.tag == "bossShip")
		{
			Destroy(coll.gameObject);
			Destroy (this.gameObject);
			Application.LoadLevel("_Boss_Ship");
		}
	}//end OnTriggerEnter
}
