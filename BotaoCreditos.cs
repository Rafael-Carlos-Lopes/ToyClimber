using UnityEngine;
using System.Collections;

public class BotaoCreditos : MonoBehaviour {

	GameObject menu;
	
	// Use this for initialization
	void Start () {
		menu = GameObject.FindGameObjectWithTag("Menu");
	}
	
	// Update is called once per frame
	void Update () {
		if (menu == null) 
		{
			menu = GameObject.FindGameObjectWithTag("Menu");
		}

		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Application.Quit ();
		}
	}
	
	void OnMouseDown()
	{
		menu.GetComponent<Menu> ().setCreditos (true);
	}
}
