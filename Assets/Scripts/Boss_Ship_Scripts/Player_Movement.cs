using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour 
{
	private float speed = 10f;
	private float turnSpeed = 100f;
	private float facing;


	// Use this for initialization
	void Start () 
	{
		facing = transform.localScale.x;
	}

	// Update is called once per frame
	void Update () 
	{
		Movement();
		Turning();
	}
	//Movement for player
	void Movement()
	{
		if(Input.GetKey(KeyCode.W))
		{
			transform.Translate(0, speed * Time.deltaTime, 0);
		}

		if(Input.GetKey(KeyCode.S))
		{
			transform.Translate(0, -(speed * Time.deltaTime), 0);
		}

		if(Input.GetKey(KeyCode.A))
		{
			transform.Translate(-(speed * Time.deltaTime), 0, 0);
		//	transform.Rotate((Vector3.forward * turnSpeed * Time.deltaTime));


		}

		if(Input.GetKey(KeyCode.D))
		{
			transform.Translate((speed * Time.deltaTime), 0, 0);
		//	transform.Rotate(-(Vector3.forward * turnSpeed * Time.deltaTime));
		}
	}//end Movement

	void Turning()
	{

		if(Input.GetKey(KeyCode.A))
		{
		//	transform.Rotate((Vector3.forward * turnSpeed * Time.deltaTime));
		//	transform.localScale = new Vector3(facing, transform.localScale.y);
	
		}
		
		if(Input.GetKey(KeyCode.D))
		{
		//	transform.Rotate(-(Vector3.forward * turnSpeed * Time.deltaTime));
		//	transform.Rotate(0,0,-90);
		}
	}//end Turning

}
