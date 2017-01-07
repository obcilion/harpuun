using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSensitivity : MonoBehaviour
{
	public float time_to_live = 1;
	private float time_in_light = 0;
	private Collider in_collider = null;

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.layer == 12 && in_collider == null) {
			in_collider = other;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (in_collider == other) {
			in_collider = null;
			time_in_light = 0;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (in_collider != null) {
			time_in_light += Time.deltaTime;
			if (time_in_light >= time_to_live) {
				Destroy (gameObject);
			}
		}
	}
}
