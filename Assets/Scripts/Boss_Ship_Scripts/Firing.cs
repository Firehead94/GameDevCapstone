//using UnityEngine;
//using System.Collections;
//
//public class Firing : MonoBehaviour 
//{
//	public GameObject bulletPrefab;
//	private int speed = 20;
//
//	private GameObject bullet;
//
//	// Use this for initialization
//	void Start ()
//	{
//	
//	}
//	
//	// Update is called once per frame
//	void Update () 
//	{
//		if(Input.GetKeyDown(KeyCode.Space))
//		{
//			Fire();
//			print ("firing");
//		}
//	}
//
//	void Fire()
//	{
//
//		bullet = Instantiate (bulletPrefab) as GameObject;
//		bullet = Instantiate(bulletPrefab, transform.position,transform.rotation) as GameObject;
//		bullet.GetComponent<Rigidbody>().velocity = Time.deltaTime * speed;
//
//	}//end Fire
//}
//
