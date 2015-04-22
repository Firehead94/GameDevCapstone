using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour 
{
	private Transform player;
	 
	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 playerPosition = player.position;
		playerPosition.z = transform.position.z;
		transform.position = playerPosition;
	}
}
