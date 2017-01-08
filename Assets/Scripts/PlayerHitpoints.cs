using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitpoints : MonoBehaviour
{
	private GameState game_state;
	private Boat boat;

	[SerializeField]
	private int lives;

	public int Lives {
		get { return lives; }
		private set { lives = value; }
	}

	void OnTriggerEnter (Collider collider)
	{
		Lives -= 1;
		if (Lives <= 0) {
			game_state.GameOver = true;
		}
		boat.OnTriggerEnter (collider);
	}
	// Use this for initialization
	void Start ()
	{
		game_state = GameObject.FindGameObjectWithTag ("GameState").GetComponent<GameState> ();
		boat = GameObject.FindGameObjectWithTag ("Player").GetComponent<Boat> ();

	}

	// Update is called once per frame
	void Update ()
	{
		
	}
}
