using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateController : MonoBehaviour
{

	private float speed;
	public GameObject slider_go;
	private Slider slider;
	private float rx0;
	private float rz0;

	public void UpdateDir ()
	{
		transform.localRotation = Quaternion.Euler (rx0, slider.value, rz0);
	}

	// Use this for initialization
	void Start ()
	{
		slider = slider_go.GetComponent <Slider> ();
		rx0 = transform.localRotation.eulerAngles.x;
		rz0 = transform.localRotation.eulerAngles.z;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
