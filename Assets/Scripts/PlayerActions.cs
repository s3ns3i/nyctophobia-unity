using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerActions : MonoBehaviour
{

	[SerializeField]
	float rayLength = 10f;
	[SerializeField]
	Text actionText;
	[SerializeField]
	GameObject gameManager;
	[SerializeField]
	GameObject equipment;
	[SerializeField]
	GameObject flashlightLight;

	bool doorClosed = true;
	bool shownGUI = false;
	Transform mainCamera;

	// Use this for initialization
	void Start ()
	{
		mainCamera = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetButtonDown ("Fire2")) {
			flashlightLight.SetActive (!flashlightLight.activeSelf);
		}

		RaycastHit hit;

		if (Physics.Raycast (mainCamera.position, mainCamera.forward, out hit, rayLength)) {
			Debug.Log ("Detected collision");
			if (hit.collider.gameObject.tag == "Door") {
				showActionText ("Use");
				if (Input.GetButtonDown ("Use")) {
					Debug.Log (hit.collider.gameObject.GetComponent<Door> ());
					if (!hit.collider.transform.parent.GetComponent<Door> ().openDoor (equipment)) {
						showActionText ("This door is locked", false);
					}
				}
			} else if (hit.collider.gameObject.tag == "Key") {
				showActionText ("Pick up");

				if (Input.GetButtonDown ("Use")) {
					Debug.Log ("picking up a key");
					//Delete visual components of the object an leave it only with item script
					hit.collider.gameObject.GetComponent<Item> ().collectItem ();
					GetComponent<Sounds> ().PlaySound (0, 1f);
				}
			} else {
				// Same line is out the if statement, because without this line text won't
				// disappear raycast will detect collissions with, for example, wall
				deleteActionText ();
			}
		}
			// If you'll, for example, open a door, raycast won't detect collision,
		 // so text won't disappear. That's why this line is important.
		else
			deleteActionText ();
	}

	void showActionText (string message)
	{
		if (!shownGUI) {
			Debug.Log (message);
			actionText.text = message;
			shownGUI = true;
		}
	}

	void showActionText (string message, bool checkIfGUIIsShown)
	{
		if (checkIfGUIIsShown) {
			if (!shownGUI) {
				Debug.Log (message);
				actionText.text = message;
				shownGUI = true;
			}
		} else {
			Debug.Log (message);
			actionText.text = message;
			shownGUI = true;
		}
	}

	void deleteActionText ()
	{
		if (shownGUI) {
			Debug.Log ("deleting text");
			actionText.text = "";
			shownGUI = false;
		}
	}
}
