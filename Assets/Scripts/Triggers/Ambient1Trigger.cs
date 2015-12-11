using UnityEngine;
using System.Collections;

public class Ambient1Trigger : MonoBehaviour {

	bool triggered;
	// Use this for initialization
	void Start () {
		triggered = false;
	}
	
	// Update is called once per frame
	void OnTriggerEnter()
	{
		if (!triggered)
		{
			Debug.Log("triggered ambient1");
			GetComponent<BoxCollider>().enabled = false;
			GetComponent<AudioSource>().Play();
			triggered = true;
		}
	}
}
