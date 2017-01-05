using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatBehaviour : MonoBehaviour
{

	public float move_amplitude = 1;
	public float move_speed = 1;

	public bool x_movement;
	public bool y_movement;
	public bool z_movement;

	private float xm0;
	private float ym0;
	private float zm0;

	public float rotate_x_amplitude = 1;
	public float rotate_x_speed = 1;
	public float rotate_y_amplitude = 1;
	public float rotate_y_speed = 1;
	public float rotate_z_amplitude = 1;
	public float rotate_z_speed = 1;

	public bool x_rotation;
	public bool y_rotation;
	public bool z_rotation;

	// Use this for initialization
	void Start ()
	{
		
	}

	// Update is called once per frame
	void Update ()
	{
		float xm = x_movement ? transform.parent.position.x + move_amplitude * Mathf.Sin (move_speed * Time.time) : transform.parent.position.x;
		float ym = y_movement ? transform.parent.position.y + move_amplitude * Mathf.Sin (move_speed * Time.time) : transform.parent.position.y;
		float zm = z_movement ? transform.parent.position.y + move_amplitude * Mathf.Sin (move_speed * Time.time) : transform.parent.position.z;

		transform.position = new Vector3 (xm, ym, zm);

		float xr = x_rotation ? transform.parent.rotation.x + rotate_x_amplitude * Mathf.Sin (rotate_x_speed * Time.time) : transform.parent.rotation.x;
		float yr = y_rotation ? transform.parent.rotation.y + rotate_y_amplitude * Mathf.Sin (rotate_y_speed * Time.time) : transform.parent.rotation.y;
		float zr = z_rotation ? transform.parent.rotation.z + rotate_z_amplitude * Mathf.Sin (rotate_z_speed * Time.time) : transform.parent.rotation.z;

		transform.localRotation = Quaternion.Euler (new Vector3 (xr, yr, zr));
	}
}
