using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitpointDestroy : MonoBehaviour
{

	public int lives;

	void OnTriggerEnter (Collider collider)
	{
		lives -= 1;
		if (lives <= 0) {
			Destroy (gameObject);
		}
	}
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
