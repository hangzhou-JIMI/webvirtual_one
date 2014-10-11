using UnityEngine;
using System.Collections;

public class RoundandScale : MonoBehaviour {

	private bool roundStart = false;
	private bool transStart = false;
	public float trans_setp = 0.01f;
	public float left_right_rate = 0.1f;
	public float up_down_rate = 0.1f;

	// Use this for initialization
	void Start () {
		//this.transform.LookAt(Camera.main.transform);
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void OnGUI()
	{
		Event ev = Event.current;
		if(ev.type == EventType.ScrollWheel)
		{
			Vector3 src = this.transform.localScale * ( 1 + ev.delta.y * -left_right_rate);
			this.transform.localScale = src;
			Debug.Log("delta scroll wheel " + ev.delta);
		}
		if(ev.isMouse)
		{
			if(ev.button == 0)
			{
				if(ev.type == EventType.mouseDown)
				{
					roundStart = true;
				}
				if(ev.type == EventType.mouseUp)
				{
					roundStart = false;
				}
			}

			if(ev.button == 1)
			{
				if(ev.type == EventType.mouseDown)
				{
					transStart = true;
				}
				if(ev.type == EventType.mouseUp)
				{
					transStart = false;
				}
				if(ev.type == EventType.MouseDrag)
				{
					this.transform.Translate( new Vector3(0,ev.delta.y*-trans_setp,0) );
					Debug.Log("delta drag " + ev.delta);
				}
			}

			//
			if(roundStart)
			{
				this.transform.Rotate(new Vector3(0,ev.delta.x,0));
				this.transform.RotateAround(this.transform.position,Vector3.forward,ev.delta.y*up_down_rate);
				Debug.Log("delta " + ev.delta);
			}
		}
	}
}
