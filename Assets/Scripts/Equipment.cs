using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Equipment : MonoBehaviour {

	[SerializeField]
	Canvas canvas;
	[SerializeField]
	GameObject slotPrefab;
	[SerializeField]
	GameObject itemPrefab;
	[SerializeField]
	float distanceBetweenSlots = 2.5f;
	float xPosition;
	float yPosition;
	float imageHeight;
	const int numberOfSlots = 10;
	int currentSlot = 0;
	//ArrayList items = new ArrayList();
	GameObject[] slots = new GameObject[numberOfSlots];
	//GameObject[] items = new GameObject[numberOfSlots];


	// Use this for initialization
	void Start () {
		// Create window
		// Set all objects etc.
		/*
		 * Window size:
		 * width - 1/3 screen size
		 * height - 3/4 screen size
		 * handle bar - 1/20 window size
		 * slots - idk yet
		 */
		for (int i = 0; i < numberOfSlots; i++)
		{
			slots[i] = Instantiate<GameObject>(slotPrefab);
			slots[i].transform.SetParent(canvas.transform);
			slots[i].transform.position =
				new Vector3(slotPrefab.transform.position.x,
				slotPrefab.transform.position.y
				+ i * (slotPrefab.GetComponent<RectTransform>().sizeDelta.y
				+ distanceBetweenSlots),
				0f);
			slots[i].name = "Slot" + (i + 1);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addItem(GameObject item)
	{
		// Create new item in players inventory
		GameObject itemShell = Instantiate<GameObject>(itemPrefab);
		itemShell.name = item.name;
		itemShell.tag = item.tag;
		// Set it as a child of corresponding type of items
		itemShell.transform.SetParent(transform.FindChild(itemShell.tag + " Pocket"));
		// Copy script component.
		UnityEditorInternal.ComponentUtility.CopyComponent(item.GetComponent<Item>());
		UnityEditorInternal.ComponentUtility.PasteComponentValues(itemShell.GetComponent<Item>());
		//Change image of the slot.
		slots[currentSlot].GetComponent<Image>().sprite = item.GetComponent<Item>().itemImage;
		// Destroy original item
		Destroy(item);
		currentSlot++;
	}
}
