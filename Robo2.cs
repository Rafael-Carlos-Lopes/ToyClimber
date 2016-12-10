using UnityEngine;
using System.Collections;

public class Robo2 : MonoBehaviour {

	int vel = 1;

	[SerializeField]
	GameObject bomba;

	// Use this for initialization
	void Start () {
	
		InvokeRepeating("MudarVelocidade", 3f,3f);
		InvokeRepeating ("InstanciarBomba", 5f, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (vel * Time.deltaTime, 0, 0);
	}

	void MudarVelocidade()
	{
		vel *= -1;
	}

	void InstanciarBomba()
	{
		GameObject g = (GameObject)Instantiate (bomba, transform.position, Quaternion.identity);
	}
}
