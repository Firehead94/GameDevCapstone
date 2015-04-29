using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {

	// Use this for initialization
	void Start () {

        StartCoroutine(explode());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator explode()
    {
        yield return new WaitForSeconds(0.3f);

        Destroy(gameObject);
    }
}
