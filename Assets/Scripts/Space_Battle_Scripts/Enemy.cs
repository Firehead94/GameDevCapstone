using UnityEngine;
using System.Collections;
/*
public class Enemy : MonoBehaviour 
{
	// Max distance an enemy can move to the left
	public static float leftX = -40f;

	//Max Up and Down that a fast enemy can move
	public float moveUp = 2f;
	public float moveDown = -2f;

	public float speed = 10f;
	public int score = 10;
	GameObject tempHealthPoint;
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
		if(transform.position.x < leftX)
		{
			TakeDamage();
			Destroy(this.gameObject);
		}
		else
		{
//			if(this.gameObject.name == "FastEnemy(Clone)")
//			{
//				FastEnemyMovement();
//			}
//			else
//			{
//				Move();
//			}//end inner if-else
			Move();

		}//end outer if-else
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

	void TakeDamage()
	{
		GameObject go = GameObject.Find("Slingshot");
		Slingshot slingShot = go.GetComponent<Slingshot>();

			if(slingShot.playerHealth > 0)
			{
				slingShot.playerHealth--;
			}

	}//end TakeDamage

	void FastEnemyMovement()
	{
		if(transform.position.y > moveUp)
		{
			Vector3 tempPos = position;
			tempPos.y -= speed * Time.deltaTime;
			position = tempPos;
			Move();
		}
		if(transform.position.y < moveDown)
		{
			Vector3 tempPos = position;
			tempPos.y -= speed * Time.deltaTime;
			position = tempPos;
			Move();
		}
	}
}
*/