using UnityEngine;
using System.Collections;

public class Key1Trigger : OnDestroyPropTrigger {

	[SerializeField]
	GameObject victim;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		base.Update();
	}

	public override void TriggerAction()
	{
		Debug.Log("Entered triggerAction");
		Vector3 relativePosition = victim.transform.position - prop.transform.position;
		relativePosition.y = 0f;
		prop.transform.rotation = Quaternion.LookRotation(relativePosition, Vector3.up);
		//play sound
		prop.gameObject.GetComponent<AudioSource>().Play();
		//Destroy(gameObject);
	}
}
