using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomSpawner : MonoBehaviour 
{
	public static RandomSpawner RS;

	public GameObject[] prefabEnemies;
	public float enemySpawnPerSecond = 0.5f;
	public float enemySpawnPadding = 1.5f;

	public bool ______________;

	//Delay between Enemy spawns
	public float enemySpawnRate;

	// Use this for initialization
	void Start () 
	{
		
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
	
	public void SpawnEnemy()
	{
		//Pick random enemy prefab to instantiate
		int index = Random.Range (0, prefabEnemies.Length);
		GameObject go = Instantiate (prefabEnemies [index]) as GameObject;
		Vector3 position = Vector3.zero;

		float yMin = -8f;
		float yMax = 10f;

		position.y = Random.Range (yMin, yMax);
		position.x = 25f;
		go.transform.position = position;

		//Call SpawnEnemy() again in a couple of seconds
		Invoke ("SpawnEnemy", enemySpawnRate);
	}//end SpawnEnemy

}
