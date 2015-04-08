using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	public static float leftX = -40f;
	public float speed = 10f;
	public int score = 10;
	bool ________________;

	//bounds of this and children
	public Bounds bounds;
	//distance of bounds from center
	public Vector3 boundsOffset;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Move();
		if(transform.position.x < leftX)
		{
			Destroy(this.gameObject);
		}//end if
	}

	public virtual void Move()
	{
		Vector3 tempPos = position;
		tempPos.x -= speed * Time.deltaTime;
		position = tempPos;
	}// end move

	public Vector3 position
	{
		get
		{
			return(this.transform.position);
		}
		set
		{
			this.transform.position = value;
		}
	}//end position

//		void OnCollisionEnter(Collision coll)
//		{	
//			GameObject other = coll.gameObject;
//			if(other.tag == "EnergyProjectile")
//			{
//				Destroy(coll.gameObject);
//			}
//		Destroy (other);
//	
//		}//end OnCollisionEnter
}
