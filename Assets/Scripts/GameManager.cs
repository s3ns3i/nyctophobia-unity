using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public bool isCursorLocked = true;

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape") && isCursorLocked)
        {
            isCursorLocked = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (Input.GetButtonDown("Fire1") && !isCursorLocked)
        {
            isCursorLocked = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
	}
}
