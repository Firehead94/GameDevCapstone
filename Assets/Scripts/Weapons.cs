using UnityEngine;
using System.Collections;

public class Weapons : MonoBehaviour 
{
	public int currentProjectile;
	public GameObject[] projectiles;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			ChangeProjectile(currentProjectile);
		}//end if
	}//end Update

	void ChangeProjectile(int change)
	{
		currentProjectile = change;
		for(int index = 0; index < projectiles.Length; index++)
		{
			if()
		}//end for

	}//end changeProjectile
}
