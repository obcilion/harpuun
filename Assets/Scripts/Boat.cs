﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boat : MonoBehaviour
{
	#region Fields and Constants

	private Slider throttle_slider;
	private Slider rudder_slider;

	#endregion

	#region Properties

	[SerializeField]
	private float turn_multiplier = 1f;

	public float TurnMultiplier {
		get { return turn_multiplier; }
		set { turn_multiplier = value; }	
	}

	[SerializeField]
	private float speed_multiplier = 1f;

	public float SpeedMultiplier {
		get { return speed_multiplier; }
		set { speed_multiplier = value; }	
	}

	[SerializeField]
	private float acceleration = 1f;

	public float Acceleration {
		get { return acceleration; }
		set { acceleration = value; }
	}

	[SerializeField]
	private int throttle_level = 0;

	public int ThrottleLevel {
		get { return throttle_level; }
		set { throttle_level = value; }
	}

	[SerializeField]
	private float speed = 0f;

	public float Speed {
		get { return speed; }
		private set { speed = value; }
	}

	[SerializeField]
	[Range (-180f, 180f)]
	private float rudder_angle = 0f;

	public float RudderAngle {
		get { return rudder_angle; }
		set { rudder_angle = value; }
	}

	#endregion

	#region Public Methods

	public void UpdateThrottle ()
	{
		ThrottleLevel = (int)throttle_slider.value;
	}

	public void UpdateRudder ()
	{
		RudderAngle = rudder_slider.value;
	}

	#endregion

	#region Unity Methods

	void OnTriggerEnter (Collider collider)
	{
		var dir = transform.position - collider.transform.position;
		dir.Normalize ();
		transform.Translate (dir * 2);
		Speed = 0;
		ThrottleLevel = 0;
		throttle_slider.value = 0;
	}

	void Start ()
	{
		throttle_slider = GameObject.FindGameObjectWithTag ("Throttle Slider").GetComponent<Slider> ();
		rudder_slider = GameObject.FindGameObjectWithTag ("Rudder Slider").GetComponent<Slider> ();
	}

	void Update ()
	{
		transform.Rotate (Vector3.up * Time.deltaTime * RudderAngle * TurnMultiplier);
		Speed = Mathf.MoveTowards (Speed, ThrottleLevel, Acceleration);
		transform.Translate (Vector3.forward * Time.deltaTime * speed * speed_multiplier);
	}

	#endregion
}
