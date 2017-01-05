using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoy : MonoBehaviour
{

	private GameState game_state;

	void OnTriggerEnter (Collider collider)
	{
		if (collider.gameObject.layer != 9) {
			return;
		}

		game_state.points += 1;
		Destroy (gameObject);
	}

	// Use this for initialization
	void Start ()
	{
		game_state = GameObject.FindGameObjectWithTag ("GameState").GetComponent<GameState> ();
	}
}
