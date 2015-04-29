using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Timers;

public class RandomSpawner : MonoBehaviour 
{
	public static RandomSpawner RS;
	public static float waveTimer;

	public GameObject[] prefabEnemies;
    public GameObject bossship;
    public Transform bossspawner;
	public float enemySpawnPerSecond = 0.5f;
	public float enemySpawnPadding = 1.5f;
    public int time = 30; //seconds
	public bool ______________;
    public GameObject alert1;
    public GameObject alert2;


	//Delay between Enemy spawns
	public float enemySpawnRate;

	// Use this for initialization
	void Start () 
	{
		waveTimer = time;
        bossspawner = GameObject.FindGameObjectWithTag("bossspawner").transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (waveTimer >= 1)
        {
            waveTimer -= 1 * Time.deltaTime;
        }
        else if (waveTimer <= 1 && GameObject.FindGameObjectsWithTag("bossship").Length < 1)
        {
            SpawnBoss();
        }
	}

	void Awake()
	{
		RS = this;

		enemySpawnRate = 1f / enemySpawnPerSecond;

		StartCoroutine(SpawnEnemy());
	}//end Awake

	/**
	 * Begins spawning enemies as soon as scene begins
	 */
	IEnumerator SpawnEnemy()
	{
		//Pick random enemy prefab to instantiate
		int index = Random.Range (0, prefabEnemies.Length);
		GameObject go = Instantiate (prefabEnemies [index]) as GameObject;
		Vector3 position = Vector3.zero;

		float yMin = -3f;
		float yMax = 4f;
        float z = -2;

		position.y = Random.Range (yMin, yMax);
		position.x = 15f;
        position.z = z;
		go.transform.position = position;

		//Call SpawnEnemy() again in a couple of seconds
		yield return new WaitForSeconds(enemySpawnRate);
        StartCoroutine(SpawnEnemy());
	}//end SpawnEnemy

	/**
	 * Spawns the boss ship and posts an alert on the GUI
	 */
	private void SpawnBoss()
	{
        Alert(1);
        Instantiate(bossship, bossspawner.position, bossspawner.rotation);
	}//end OnTimedEvent

    public void Alert(int i)
    {
        switch (i)
        {
            case 1: alert1.SetActive(true);
                alert2.SetActive(false);
                break;
            case 2: alert2.SetActive(true);
                alert1.SetActive(false);
                break;
            default: break;
        }
        
    }
	
}
