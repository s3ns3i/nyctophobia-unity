using UnityEngine;
using System.Collections;

public class DoorBehavior : MonoBehaviour {

	bool doorClosed = true;
	[SerializeField]
	float rayLength = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Vector3 forward = transform.TransformDirection(Vector3.forward);

		if (Physics.Raycast(transform.position, forward, out hit, rayLength) || Physics.Raycast(transform.position, -forward, out hit, rayLength))
		{
			if (hit.collider.gameObject.tag == "Door")
			{
				if (Input.GetButtonDown("Use"))
				{
					Animator doorAnimator = hit.collider.gameObject.transform.parent.GetComponent<Animator>();
					doorAnimator.SetTrigger("door_action");
					doorClosed = !doorClosed;
				}
			}
		}
	}
}
