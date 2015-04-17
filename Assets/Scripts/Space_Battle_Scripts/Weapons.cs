using UnityEngine;
using System.Collections;

public class Weapons : MonoBehaviour 
{
	public GameObject EnergyProjectile;
	public GameObject BoardingCrew;
	private bool changer = true;
	private Slingshot slingshotAmmo;
	
	// Use this for initialization
	void Start () 
	{
		slingshotAmmo = gameObject.GetComponent<Slingshot>();
	}
	
	// Update is called once per frame
	void Update ()
	{

		if(Input.GetKeyDown(KeyCode.F1))
		{
			changer = true;
			SwitchProjectile();
		}//end if

		if(Input.GetKeyDown(KeyCode.F2))
		{
			changer = false;
			SwitchProjectile();
		}//end if

	}//end Update

	void SwitchProjectile()
	{
		if(changer == true)
		{
			EnergyProjectile.gameObject.SetActive(true);
			BoardingCrew.gameObject.SetActive(false);
			slingshotAmmo.SetPrefab(EnergyProjectile);
		}
		else
		{
			EnergyProjectile.gameObject.SetActive(false);
			BoardingCrew.gameObject.SetActive(true);
			slingshotAmmo.SetPrefab(BoardingCrew);
		}//end if-else

	}//end SwitchProjectile

}

