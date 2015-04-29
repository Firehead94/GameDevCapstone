using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controller : MonoBehaviour {


    public GameObject[] ammo;
    public int ammoIndex = 0;
    public Vector3 spawnLoc;
    public Quaternion spawnRot;
    public bool shouldSpawn = false;
    public int scorecount = 0;
    public int health = 3;
    public int armorcount = 3;

    public Text score;
    public GameObject[] hearts;
    public GameObject[] armor;
    private bool gameOver = false;

    public GameObject pauseScreen;
    public GameObject gameOverScreen;
    public GameObject winScreen;
    public bool cooldown = false;

    public bool win = false;


	// Use this for initialization
	void Start ()
    {
        spawnLoc = GameObject.FindGameObjectWithTag("spawnammo").transform.position;
        spawnRot = GameObject.FindGameObjectWithTag("spawnammo").transform.rotation;
        Instantiate(ammo[ammoIndex], spawnLoc, spawnRot);
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (gameOver)
        {
            gameOverScreen.SetActive(true);
        }

        if (win)
        {
            winScreen.SetActive(true);
        }

        if (Input.GetButton("Cancel"))
        {
            Pause();
        }

        if (shouldSpawn)
        {
            StartCoroutine(Spawn());            
            shouldSpawn = false;
            
        }
        if (health == 0)
        {
            gameOver = true;
        }

        score.text = "Score: " + scorecount;

	}

	//Sets a cooldown rate for ammo so the player can't rapid fire
    IEnumerator Spawn()
    {
        if (!cooldown)
        {
            print("spawn new");
            cooldown = true;
            yield return new WaitForSeconds(1.5f);
            Instantiate(ammo[ammoIndex], spawnLoc, spawnRot);
            yield return new WaitForSeconds(0.5f);
            cooldown = false;
        }
    }
	//Sets the score on the players GUI
    public void SetScore(int score)
    {
        this.scorecount += score;
    }

	//Sets player hit points and determines if the player loses
    public void SetHP(int hp)
    {
        if (health > 0)
        {
            if (armorcount == 0)
            {
                health -= hp;
                hearts[health].SetActive(false);
            }
            else
            {
                SetArmor(hp);
            }
        }
        else
        {
            gameOver = true;
        }
    }

    public void SetArmor(int armor)
    {
        this.armorcount -= armor;
        this.armor[armorcount].SetActive(false);
    }


    public void AmmoBasic()
    {
        if (ammoIndex != 0)
        {
            ammoIndex = 0;
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("ammoCap"))
                Destroy(go);
            StopAllCoroutines();
            shouldSpawn = true;
            cooldown = false;
        }

    }

    public void AmmoCapsule()
    {
        if (ammoIndex != 1)
        {
            ammoIndex = 1;
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("ammo"))
                Destroy(go);
            StopAllCoroutines();
            cooldown = false;
            shouldSpawn = true;
        }

    }

    public void Pause()
    {
       pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.LoadLevel("_Scene_Main");
        UnPause();
    }

    public void Restart()
    {
        Application.LoadLevel("_Level_1");
    }


}
