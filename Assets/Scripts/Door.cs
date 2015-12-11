using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	[SerializeField]
	// In this game it should be a UI canvas, because keys are stored in UI slots
	GameObject doorKey;
	Item doorKeyComponent;
	bool doorLocked;
	bool doorClosed = true;

	// Use this for initialization
	void Start () {
		if (doorKey != null)
		{
			Debug.Log("Door " + transform.name + " have a key");
			doorLocked = true;
			doorKeyComponent = doorKey.GetComponent<Item>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool openDoor(GameObject equipment)
	{
		if (doorLocked)
		{
			Debug.Log("door is locked");
			int numberOfKeys = equipment.transform.GetChild(0).childCount;
			Transform keyPocket = equipment.transform.GetChild(0);
			Transform key;
			Item keyComponent;
			// search equipment for keys
			for(int i = 0; i < numberOfKeys; i++){
				key = keyPocket.GetChild(i);
				keyComponent = key.GetComponent<Item>();
				// check if any of the keys is for this door
				// if yes, then open the door
				if(keyComponent.itemId == doorKeyComponent.itemId
					&& key.tag == doorKey.tag)
				{
					// open door
					return doorAction();
				}
			}
			return false;
		}
		else
		{
			return doorAction();
		}
	}

	bool doorAction()
	{
		GetComponent<Animator>().SetTrigger("door_action");
		if(doorClosed)
			GetComponent<Sounds>().PlaySound(0, 1f);
		if (!doorClosed)
			GetComponent<Sounds>().PlaySound(1, 1f);
		doorClosed = !doorClosed;
		return true;
	}
}
