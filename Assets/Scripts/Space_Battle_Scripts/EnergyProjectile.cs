using UnityEngine;
using System.Collections;

public class EnergyProjectile : MonoBehaviour 
{
	public static float bottomY = -20f;
	public static float topY = 20f;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(transform.position.y < bottomY || transform.position.y > topY)
		{
			Destroy(this.gameObject);
		}//end if
	}//end update

	void OnTriggerEnter(Collider coll)
	{
		if(coll.gameObject.tag == "Enemy")
		{
			Destroy(coll.gameObject);
		}
		Destroy (this.gameObject);
	}//end OnTriggerEnter
	
}
