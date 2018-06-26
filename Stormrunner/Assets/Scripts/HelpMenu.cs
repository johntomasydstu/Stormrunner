using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour {

	public GameObject mainMenu;

	public void backButton()
	{
		mainMenu.SetActive(true);
		gameObject.SetActive (false);

	}

}
