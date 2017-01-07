using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boat : MonoBehaviour
{
	#region Fields and Constants

	private Slider throttle_slider;
	private Slider rudder_slider;
    private TouchInput input;

    public Text DebugText1;
    public Text DebugText2;

    [SerializeField]
	private float bump_distance_on_hit;

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
		set
        {
            if (rudder_angle + value > 180) rudder_angle = 180;
            if (rudder_angle + value < -180) rudder_angle = -180;
            rudder_angle = value;
        }
	}

	#endregion

	#region Public Methods

	public void UpdateThrottle ()
	{
		ThrottleLevel = (int)throttle_slider.value;
	}


    float rudderChangeVelocity = 0;
    float rudderChangeDrag = 0.98f;
	public void UpdateRudder ()
	{
        if (DebugText1 != null) DebugText1.text = "" + rudderChangeVelocity;

        if (rudderChangeVelocity <= 0.01) return;

        //RudderAngle = rudder_slider.value;
        rudderChangeVelocity *= rudderChangeDrag;
        RudderAngle += rudderChangeVelocity;
	}

    private void Input_OnMove(object sender, MoveEventArgs e)
    {
        if (DebugText2 != null) DebugText2.text = "OnMove triggered.";
        RudderAngle = 60f * e.Movement.x; 
    }

    #endregion

    #region Unity Methods

    void OnTriggerEnter (Collider collider)
	{
        if (DebugText2 != null) DebugText2.text = "Collision enter";

		// Only recoil on terrain
		if (collider.gameObject.layer != 10) {
			return;
		}

		transform.Translate (-Vector3.forward * bump_distance_on_hit * Mathf.Clamp (ThrottleLevel, -1, 1));
		Speed = 0;
		ThrottleLevel = 0;
		//throttle_slider.value = 0;
		RudderAngle = 0;
		//rudder_slider.value = 0;
	}

	void Start ()
	{
        input = gameObject.AddComponent<TouchInput>();
        //throttle_slider = GameObject.FindGameObjectWithTag ("Throttle Slider").GetComponent<Slider> ();
		//rudder_slider = GameObject.FindGameObjectWithTag ("Rudder Slider").GetComponent<Slider> ();

        input.OnMove += Input_OnMove;
	}

    void Update ()
	{
        //UpdateRudder();

		transform.Rotate (Vector3.up * Time.deltaTime * RudderAngle * TurnMultiplier);
		Speed = Mathf.MoveTowards (Speed, ThrottleLevel, Acceleration);
		transform.Translate (Vector3.forward * Time.deltaTime * speed * speed_multiplier);
	}

	#endregion
}
