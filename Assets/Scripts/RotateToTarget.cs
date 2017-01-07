using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTarget : MonoBehaviour
{

	public GameObject target;
	public Vector3 offset;
	public float rotation_speed;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (target == null) {
			return;
		}
		var dir = target.transform.position - transform.position;
		dir.Normalize ();
		var q = Quaternion.LookRotation (dir);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, q, rotation_speed * Time.deltaTime);
	}
}
