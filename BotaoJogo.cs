﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BotaoJogo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		SceneManager.LoadScene("Fase1");
	}
}
