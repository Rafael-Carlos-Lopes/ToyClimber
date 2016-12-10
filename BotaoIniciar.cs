using UnityEngine;
using System.Collections;

public class BotaoIniciar : MonoBehaviour {

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
	}

	void OnMouseDown()
	{
		menu.GetComponent<Menu> ().setIniciar (true);
	}
}
