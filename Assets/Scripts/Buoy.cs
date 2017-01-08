using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Buoy : MonoBehaviour
{

	private GameState game_state;
	public AudioSource source;
	public AudioClip[] audioFiles;


	void OnTriggerEnter (Collider collider)
	{
		
		
		if (collider.gameObject.layer != 9) {
			return;
		}

		game_state.points += 1;
		Debug.Log (game_state.points % 2);
		source.PlayOneShot (audioFiles[game_state.points % 2]);
		Destroy (gameObject);
	}

	// Use this for initialization
	void Start ()
	{
		
		game_state = GameObject.FindGameObjectWithTag ("GameState").GetComponent<GameState> ();
		source = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource> ();

	}
}
