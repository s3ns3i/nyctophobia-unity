﻿using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class InGameMenu : MainMenu
{
	
	[SerializeField]
	FirstPersonControllerModified player;
	[SerializeField]
	GameObject menu;
	[SerializeField]
	GameObject hud;

	bool isGamePaused = false;

	public new void Start ()
    {
        base.Start();
        continueButton.GetComponent<Text>().text = "Continue";
        Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		menu.SetActive (false);
		hud.SetActive (true);
	}

	public void Update ()
	{
		if (Input.GetButtonDown ("Cancel")) {
			if (!isGamePaused) {
				isGamePaused = true;
				Time.timeScale = 0f;
				player.enabled = false;
				menu.SetActive (true);
				hud.SetActive (false);
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			} else {
				isGamePaused = false;
				Time.timeScale = 1f;
				player.enabled = true;
				menu.SetActive (false);
				hud.SetActive (true);
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
			}
		}
	}

	public void ContinueGame ()
	{
		isGamePaused = false;
		Time.timeScale = 1f;
		player.enabled = true;
		menu.SetActive (false);
		hud.SetActive (true);
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
}