using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerActions : MonoBehaviour {

	[SerializeField]
	float rayLength = 10f;
	[SerializeField]
	Text actionText;
	[SerializeField]
	GameObject gameManager;
	[SerializeField]
	GameObject equipment;
	[SerializeField]
	bool flashlightOn = true;

	bool doorClosed = true;
	bool shownGUI = false;

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
				if (!shownGUI)
				{
					actionText.text = "Use";
					shownGUI = true;
				}
				if (Input.GetButtonDown("Use"))
				{
					Debug.Log(hit.collider.gameObject.GetComponent<Door>());
					if(!hit.collider.transform.parent.GetComponent<Door>().openDoor(equipment)){
						actionText.text = "This door is locked";
					}
				}
			}
			else if (hit.collider.gameObject.tag == "Key")
			{
				if (!shownGUI)
				{
					actionText.text = "Pick up";
					shownGUI = true;
				}

				if (Input.GetButtonDown("Use"))
				{
					Debug.Log("picking up a key");
					//Delete visual components of the object an leave it only with item script
					hit.collider.gameObject.GetComponent<Item>().collectItem();
				}
			}
		}
		else
		{
			if (shownGUI)
			{
				Debug.Log("deleting text");
				actionText.text = "";
				shownGUI = false;
			}
		}
		if (Input.GetButtonDown("Fire2"))
		{
			GameObject flashlightLight = transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
			flashlightOn = !flashlightOn;
			flashlightLight.SetActive(flashlightOn);
		}
	}
}
