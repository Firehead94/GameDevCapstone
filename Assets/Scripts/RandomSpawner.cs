using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Timers;

public class RandomSpawner : MonoBehaviour 
{
	public static RandomSpawner RS;
	public static Timer waveTimer;
	public static int ticker = 20;

	public GameObject[] prefabEnemies;
	public float enemySpawnPerSecond = 0.3f;
	public float enemySpawnPadding = 1.5f;
	public bool ______________;

	//Delay between Enemy spawns
	public float enemySpawnRate;

	// Use this for initialization
	void Start () 
	{
		waveTimer = new Timer(1000);
		waveTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
		waveTimer.Enabled = true;
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void Awake()
	{
		RS = this;

		enemySpawnRate = 1f / enemySpawnPerSecond;

		Invoke ("SpawnEnemy", enemySpawnRate);
	}//end Awake

	/**
	 * Begins spawning enemies as soon as scene begins
	 */
	public void SpawnEnemy()
	{
		//Pick random enemy prefab to instantiate
		int index = Random.Range (0, prefabEnemies.Length);
		GameObject go = Instantiate (prefabEnemies [index]) as GameObject;
		Vector3 position = Vector3.zero;

		float yMin = -3f;
		float yMax = 4f;

		position.y = Random.Range (yMin, yMax);
		position.x = 15f;
		go.transform.position = position;

		//Call SpawnEnemy() again in a couple of seconds
		Invoke ("SpawnEnemy", enemySpawnRate);
	}//end SpawnEnemy

	/**
	 * Keeps track of ticker timer and stops the timer if ticker reaches 0
	 */
	private static void OnTimedEvent(object source, ElapsedEventArgs e)
	{
		ticker--;
		//print (ticker);
		if(ticker == 0)
		{
			waveTimer.Stop();
		}
	}//end OnTimedEvent

	/**
	 * Stops the wave if ticker gets to 0 and player has at least one life
	 */
	void StopWave()
	{

	}//end StopWave
}
