using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour 
{
	public Material[] bossColors = new Material[1];

	// Use this for initialization
	void Start () 
	{
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
			SphereCollider coll = gameObject.GetComponent<SphereCollider>();
			coll.enabled = true;
			gameObject.renderer.material = bossColors[1];
		}//end if
	}//end DetermineVulnerability

//	void OnCollisionEnter (Collision col)
//	{
//		if(col.gameObject.name == "BoardingCrew")
//		{
//			Destroy(col.gameObject);
//			Destroy(this.gameObject);
//			Application.LoadLevel("_Boss_Ship");
//		}//end if
//	}//end OnCollisionEnter
}


