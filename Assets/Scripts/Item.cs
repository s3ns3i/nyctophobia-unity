using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Item : MonoBehaviour {

	public int itemId;
	public Image itemImage;
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

}
