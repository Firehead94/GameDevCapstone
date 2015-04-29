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


    // Use this for initialization
    void Start()
    {
        health = maxHealth;
        control = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Controller>();
        rs = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RandomSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tempPos = gameObject.transform.position;
        if (gameObject.transform.position.x > 10)
            tempPos.x -= speed * Time.deltaTime;
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, (byte)MapVals(health, 0, maxHealth, 50, 255), (byte)MapVals(health,0, maxHealth, 50, 255), 255);
        gameObject.transform.position = tempPos;
    
    }

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
        else if(coll.gameObject.tag.Equals("ammoCap") && this.health < 1)
        {
            StartCoroutine(explode());
            
            
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
        Application.LoadLevel("_Scene_Main");

    }

}


