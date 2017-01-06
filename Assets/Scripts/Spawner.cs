using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

	private GameObject[] spawn_points;
	private Vector3 last_pos = Vector3.zero;

	public void SpawnRandom (GameObject prefab)
	{
		Vector3 pos;
		do {
			pos = spawn_points [Random.Range (0, spawn_points.Length)].transform.position;
		} while(pos == last_pos);
		last_pos = pos;
		var instance = GameObject.Instantiate (prefab, transform);
		instance.transform.position = pos;
	}

	// Use this for initialization
	void Start ()
	{
		spawn_points = GameObject.FindGameObjectsWithTag ("SpawnPoint");
	}
}
