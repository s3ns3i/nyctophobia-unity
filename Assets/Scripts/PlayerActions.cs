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
	Transform camera;

	// Use this for initialization
	void Start () {
		camera = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;

		if (Physics.Raycast(camera.position, camera.forward, out hit, rayLength))
		{
			Debug.Log("Detected collision");
			if (hit.collider.gameObject.tag == "Door")
			{
				showActionText("Use");
				//if (!shownGUI)
				//{
				//	actionText.text = "Use";
				//	shownGUI = true;
				//}
				if (Input.GetButtonDown("Use"))
				{
					Debug.Log(hit.collider.gameObject.GetComponent<Door>());
					if (!hit.collider.transform.parent.GetComponent<Door>().openDoor(equipment))
					{
						showActionText("This door is locked", false);
						//actionText.text = "This door is locked";
						//shownGUI = true;
					}
				}
			}
			else if (hit.collider.gameObject.tag == "Key")
			{
				showActionText("Pick up");
				//if (!shownGUI)
				//{
				//	actionText.text = "Pick up";
				//	shownGUI = true;
				//}

				if (Input.GetButtonDown("Use"))
				{
					Debug.Log("picking up a key");
					//Delete visual components of the object an leave it only with item script
					hit.collider.gameObject.GetComponent<Item>().collectItem();
					GetComponent<Sounds>().PlaySound(0, 1f);
				}
			}
			else
			{
				// Same line is out the if statement, because without this line text won't
				// disappear raycast will detect collissions with, for example, wall
				deleteActionText();
				//if (shownGUI)
				//{
				//	Debug.Log("deleting text");
				//	actionText.text = "";
				//	shownGUI = false;
				//}
			}
			if (Input.GetButtonDown("Fire2"))
			{
				GameObject flashlightLight = transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
				flashlightOn = !flashlightOn;
				flashlightLight.SetActive(flashlightOn);
			}
		}
			// If you'll, for example, open a door, raycast won't detect collision,
		 // so text won't disappear. That's why this line is important.
		else
			deleteActionText();
	}

	void showActionText(string message)
	{
		if (!shownGUI)
		{
			Debug.Log(message);
			actionText.text = message;
			shownGUI = true;
		}
	}
	void showActionText(string message, bool checkIfGUIIsShown)
	{
		if (checkIfGUIIsShown)
		{
			if (!shownGUI)
			{
				Debug.Log(message);
				actionText.text = message;
				shownGUI = true;
			}
		}
		else
		{
			Debug.Log(message);
			actionText.text = message;
			shownGUI = true;
		}
	}

	void deleteActionText()
	{
		if (shownGUI)
		{
			Debug.Log("deleting text");
			actionText.text = "";
			shownGUI = false;
		}
	}
}
