using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineAudio : MonoBehaviour
{
	private Slider throttle_slider;
	private AudioSource engine_audio;

	private Dictionary<int, float> throttle_pitch_mapping = new Dictionary<int, float> () {
		{ -1, 1f },
		{ 0, 0.9f },
		{ 1, 1f },
		{ 2, 1.1f }
	};

	public void UpdateThrottle ()
	{
		engine_audio.pitch = throttle_pitch_mapping [(int)throttle_slider.value];
	}

	// Use this for initialization
	void Start ()
	{
		throttle_slider = GameObject.FindGameObjectWithTag ("Throttle Slider").GetComponent<Slider> ();
		engine_audio = transform.GetComponent<AudioSource> ();
		UpdateThrottle ();
	}
}
