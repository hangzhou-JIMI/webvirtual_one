using UnityEngine;
using System.Collections;

public class RoundandScale : MonoBehaviour {

	private bool roundStart = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		//
	
	}

	void OnGUI()
	{
		Event ev = Event.current;
		if(ev.type == EventType.ScrollWheel)
		{
			Vector3 src = this.transform.localScale * ( 1 + ev.delta.y * 0.1f);
			this.transform.localScale = src;
			Debug.Log("delta scroll wheel " + ev.delta);
		}
		if(ev.isMouse)
		{
			if(ev.type == EventType.mouseDown)
			{
				roundStart = true;
			}
			if(ev.type == EventType.mouseUp)
			{
				roundStart = false;
			}

			//
			if(roundStart)
			{
				this.transform.Rotate(new Vector3(0,ev.delta.x,0));
				Debug.Log("delta " + ev.delta);
			}
		}
	}
}
