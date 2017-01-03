using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitpoints : MonoBehaviour
{
	private GameState game_state;

	[SerializeField]
	private int lives;

	public int Lives {
		get { return lives; }
		private set { lives = value; }
	}

	void OnTriggerEnter (Collider collider)
	{
		Lives -= 1;
		Debug.Log ("Collision! " + Lives + " lives left");
		if (Lives <= 0) {
			game_state.GameOver = true;
		}
	}
	// Use this for initialization
	void Start ()
	{
		game_state = GameObject.FindGameObjectWithTag ("GameState").GetComponent<GameState> ();
	}

	// Update is called once per frame
	void Update ()
	{
		
	}
}
