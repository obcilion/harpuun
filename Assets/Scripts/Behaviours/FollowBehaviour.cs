using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBehaviour : MonoBehaviour
{
	public GameObject target;
	public Vector3 offset;
	public float speed;

	public bool x_axis_movement;
	public bool y_axis_movement;
	public bool z_axis_movement;

	private int x_axis_mod;
	private int y_axis_mod;
	private int z_axis_mod;


	// Use this for initialization
	void Start ()
	{
		x_axis_mod = x_axis_movement ? 1 : 0;
		y_axis_mod = y_axis_movement ? 1 : 0;
		z_axis_mod = z_axis_movement ? 1 : 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		var dir = (target.transform.position + offset) - transform.position;
		dir = dir.normalized;
		dir.x *= x_axis_mod;
		dir.y *= y_axis_mod;
		dir.z *= z_axis_mod;
		transform.Translate ((dir) * speed * Time.deltaTime, Space.World);
	}
}
