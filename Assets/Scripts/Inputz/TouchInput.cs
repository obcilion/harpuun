using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveEventArgs : EventArgs
{
    public Vector2 Movement { get; set; }
}

public class TouchInput : MonoBehaviour {

    public event EventHandler<MoveEventArgs> OnMove;

    public float MoveTolerance = 0;

    public Vector2 TouchStartPos { get; set; }
    public float TouchStartTime { get; set; }

    public Rect LegalScreenArea { get; set; }

    void Awake()
    {
        LegalScreenArea = new Rect(0, 0, Screen.width, Screen.height / 2.5f);
    }

	void Update () {
        if (Input.touchCount <= 0) return;

        var primaryTouch = Input.GetTouch(0);
        if (primaryTouch.Equals(null) 
            && primaryTouch.deltaPosition.sqrMagnitude < MoveTolerance) return;

        switch (primaryTouch.phase)
        {
            case TouchPhase.Began:
                if (!PointWithinLegalBounds(primaryTouch.position, LegalScreenArea)) break;

                TouchStartPos = primaryTouch.position;
                TouchStartTime = Time.time;
                break;
            case TouchPhase.Ended:
                Move(NormalizeToScreenSize(primaryTouch.position - TouchStartPos), Time.time - TouchStartTime);
                break;
        }
    }

    void Move(Vector2 amount, float time)
    {
        GameObject.FindGameObjectWithTag("DEBUGTEXT").GetComponent<Text>().text = "TouchInput.Move()";
        if(OnMove != null) OnMove.Invoke(this, new MoveEventArgs { Movement = amount });
    }

    Vector2 NormalizeToScreenSize(Vector2 screenpoint)
    {
        return new Vector2(screenpoint.x / Screen.width, screenpoint.y / Screen.height);
    }

    bool PointWithinLegalBounds(Vector2 screenpoint, Rect rect)
    {
        if (rect == null) return false;

        return screenpoint.x > rect.x &&
            screenpoint.x <= rect.x + rect.width &&
            screenpoint.y > rect.y &&
            screenpoint.y <= rect.y + rect.height;
    }
}