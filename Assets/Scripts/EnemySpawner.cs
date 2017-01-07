using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

	public float spawn_distance;
	public float y_pos = 0;
	public float enemy_radius = .5f;
	public int max_loops = 10;

	public void SpawnEnemy (GameObject enemy_prefab)
	{
		int loop = 0;
		while (loop < max_loops) {
			loop++;
			float randomAngle = Random.Range (0f, Mathf.PI * 2f);
			Vector2 point = new Vector2 (Mathf.Sin (randomAngle), Mathf.Cos (randomAngle)).normalized;
			point *= spawn_distance;
			Vector3 position = transform.position + new Vector3 (point.x, y_pos, point.y);
			var result = Physics.OverlapSphere (position, enemy_radius);
			if (result.Length == 0) {
				var instance = GameState.Instantiate (enemy_prefab);
				instance.transform.position = position;
				break;
			}
		}
	}

	// Use this for initialization
	void Start ()
	{
		
	}
}
