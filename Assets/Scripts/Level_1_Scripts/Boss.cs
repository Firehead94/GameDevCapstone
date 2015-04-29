using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Boss : MonoBehaviour 
{
    Controller control;
    RandomSpawner rs;

    public float speed = 0.5f;

    public int maxHealth = 4;
    public int health;
    public GameObject explosion;
    public GameObject winScreen;


    // Use this for initialization
    void Start()
    {
        health = maxHealth;
        control = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Controller>();
        rs = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RandomSpawner>();
    }

    /*
     * Determines if the boss has been hit and changes the color of his ship if he has
     */
    void Update()
    {
        Vector3 tempPos = gameObject.transform.position;
        if (gameObject.transform.position.x > 10)
            tempPos.x -= speed * Time.deltaTime;
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, (byte)MapVals(health, 0, maxHealth, 50, 255), (byte)MapVals(health,0, maxHealth, 50, 255), 255);
        gameObject.transform.position = tempPos;
    
    }
	/*
	 * If the boss is hit by regular ammo then he loses one health
	 */
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("ammo") && this.health > 0)
        {
            this.health -= 1;
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(coll.gameObject);
            if (this.health < 1)
            {
                rs.Alert(2);
            }
        }
		/*
		 * If the boss is vulnerable and is hit by the capsule then it loads the boss ship level
		 */
        else if(coll.gameObject.tag.Equals("ammoCap") && this.health < 1)
        {
            StartCoroutine(explode());

            new WaitForSeconds(3);
            control.win = true; ;
           
        }
        else
        {
            print(coll.gameObject.tag);
        }

    }

    private float MapVals(float hp, float inMin, float inMax, float outMin, float outMax)
    {

        return (hp - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;

    }

    IEnumerator explode()
    {
        Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(explosion, gameObject.transform.position + new Vector3(0,0.5f,0), gameObject.transform.rotation);
        yield return new WaitForSeconds(0.2f);
        Instantiate(explosion, gameObject.transform.position + new Vector3(0.5f, 0.5f, 0), gameObject.transform.rotation);
        yield return new WaitForSeconds(0.3f);
        Instantiate(explosion, gameObject.transform.position + new Vector3(-0.5f, 0, 0), gameObject.transform.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(explosion, gameObject.transform.position + new Vector3(0, -0.5f, 0), gameObject.transform.rotation);
        yield return new WaitForSeconds(0.2f);
        Instantiate(explosion, gameObject.transform.position + new Vector3(-0.5f, -0.5f, 0), gameObject.transform.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
        yield return new WaitForSeconds(1);
        

    }

}


