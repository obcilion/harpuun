using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
	public GameObject enemy_prefab;
	public GameObject buoy_prefab;

	private int _points = 0;

	public int points {
		get {
			return _points;
		}
		set {
			_points = value;
			buoy_spawner.SpawnRandom (buoy_prefab);
		}
	}

	private bool game_over = false;
	public float spawn_timer;
	public float time = 0;

	private BuoySpawner buoy_spawner;
	private EnemySpawner enemy_spawner;

	public bool GameOver {
		get { return game_over; }
		set {
			game_over = value;
			if (game_over) {
				Time.timeScale = 0;
			}
		}
	}

	void GameStart ()
	{
		buoy_spawner = gameObject.GetComponent<BuoySpawner> ();
		buoy_spawner.SpawnRandom (buoy_prefab);

		enemy_spawner = GameObject.FindGameObjectWithTag ("Player").GetComponent<EnemySpawner> ();
	}

	void Start ()
	{
		Invoke ("GameStart", 1);
	}

	void Update ()
	{
		time += Time.deltaTime;
		if (time > spawn_timer) {
			time = 0;
			enemy_spawner.SpawnEnemy (enemy_prefab);
		}
	}
}
