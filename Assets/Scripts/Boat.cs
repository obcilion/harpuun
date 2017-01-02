using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
	[SerializeField]
	private float speed_multiplier = 1f;
	public float SpeedMultiplier
	{
		get { return speed_multiplier; }
		set { speed_multiplier = value; }	
	}

	[SerializeField]
	private float acceleration = 1f;
	public float Acceleration
	{
		get { return acceleration; }
		set { acceleration = value; }
	}

	[SerializeField]
	private int throttle_level = 0;
	public int ThrottleLevel
	{
		get { return throttle_level; }
		set { throttle_level = value; }
	}

	[SerializeField]
	private float speed = 0f;
	public float Speed
	{
		get { return speed; }
		private set { speed = value; }
	}

	[SerializeField]
	private float rudder_angle = 0f;
	public float RudderAngle
	{
		get { return rudder_angle; }
		set { rudder_angle = value; }
	}

	// Use this for initialization
	void Start() 
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		transform.Rotate (Vector3.up * Time.deltaTime * RudderAngle);
		Speed = Mathf.MoveTowards (Speed, ThrottleLevel, acceleration);
		transform.Translate(Vector3.forward * Time.deltaTime * speed * speed_multiplier);
	}
}
