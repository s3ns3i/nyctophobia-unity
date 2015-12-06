using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Item : MonoBehaviour {

	[SerializeField]
	GameObject equipment;

	public int itemId;
	public Sprite itemImage;
	public string itemName;
	public Type itemType;
	//and maybe something more

	void Start()
	{

	}

	public enum Type
	{
		key,
		battery
	}

	public void collectItem()
	{
		equipment.GetComponent<Equipment>().addItem(gameObject);
	}

}
