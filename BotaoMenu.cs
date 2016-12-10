using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BotaoMenu : MonoBehaviour {

	void OnMouseDown()
	{
		SceneManager.LoadScene("MENU");
	}
}
