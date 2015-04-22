using UnityEngine;
using System.Collections;

public class Firing : MonoBehaviour 
{
	public Rigidbody bullet;
	public float speed = 20f;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Fire();
		}
	}

	void Fire()
	{
		Rigidbody instantiateBullet = Instantiate (bullet,
		                                          transform.position,
		                                          transform.rotation)
												  as Rigidbody;

		instantiateBullet.velocity = transform.TransformDirection (new Vector3 (0, 0, speed));

	}//end Fire
}
