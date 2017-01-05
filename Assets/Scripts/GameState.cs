using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
	public int points = 0;
	private bool game_over = false;

	public bool GameOver {
		get { return game_over; }
		set {
			game_over = value;
			if (game_over) {
				Time.timeScale = 0;
			}
		}
	}
}
