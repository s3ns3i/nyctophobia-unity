using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Equipment : MonoBehaviour {

	[SerializeField]
	Canvas canvas;
	[SerializeField]
	GameObject slotPrefab;
	[SerializeField]
	float distanceBetweenSlots = 2.5f;
	float xPosition;
	float yPosition;
	float imageHeight;
	int numberOfSlots = 10;
	Item[] items = new Item[10];

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
			GameObject slot = Instantiate<GameObject>(slotPrefab);
			slot.transform.SetParent(canvas.transform);
			slot.transform.position = 
				new Vector3(slotPrefab.transform.position.x,
				slotPrefab.transform.position.y
				+ i * (slotPrefab.GetComponent<RectTransform>().sizeDelta.y 
				+ distanceBetweenSlots),
				0f);
			slot.name = "Slot" + (i+1);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
