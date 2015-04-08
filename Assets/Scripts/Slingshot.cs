using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour 
{
	//Fields in the inspector pane
	public GameObject prefabProjectile;
	private float velocityMult = 10f;
	private bool _______________;

	//Dynamic fields
	private GameObject launchPoint;
	private Vector3 launchPos;
	private GameObject projectile;
	private bool aimingMode;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!aimingMode) return;
		// get mouse position in 2d coordinates
		Vector3 mousePos2D = Input.mousePosition;
		// convert to 3D coordinates
		mousePos2D.z = -Camera.main.transform.position.z;
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);
		// find delta from launchPos to mousePos3D
		Vector3 mouseDelta = mousePos3D - launchPos;
		//limit mouseDelta to radius of Slingshot spherecollider
		float maxMagnitude = this.GetComponent<SphereCollider> ().radius;

		if (mouseDelta.magnitude > maxMagnitude)
		{
			mouseDelta.Normalize();
			mouseDelta *= maxMagnitude;
		}//end if
		//move projectile to new position
		Vector3 projPos = launchPos + mouseDelta;
		projectile.transform.position = projPos;
		
		if (Input.GetMouseButtonUp(0))
		{
			//mouse has been released
			aimingMode = false;
			projectile.rigidbody.isKinematic = false;
			projectile.rigidbody.velocity = -mouseDelta * velocityMult;
			projectile = null;
		}//end if
	}//end update

	void Awake()
	{
		Transform launchPointTrans = transform.Find("LaunchPoint");
		launchPoint = launchPointTrans.gameObject;
		launchPoint.SetActive(false);
		launchPos = launchPointTrans.position;
	}

	void OnMouseEnter()
	{
		launchPoint.SetActive(true);
	}

	void OnMouseExit()
	{
		launchPoint.SetActive(false);
	}
	void OnMouseDown()
	{
		//player pressed mouse button while over slingshot
		aimingMode = true;
		// instantiate projectile
		projectile = Instantiate(prefabProjectile) as GameObject;
		//start projectile at launch point
		projectile.transform.position = launchPos;
		projectile.rigidbody.isKinematic = true;
	}//end OnMouseDown

	public void SetPrefab(GameObject obj)
	{
		prefabProjectile = obj;
	}//end SetPrefab

}
