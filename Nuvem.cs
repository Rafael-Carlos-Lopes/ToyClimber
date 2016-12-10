using UnityEngine;
using System.Collections;

public class Nuvem : MonoBehaviour {

	Rigidbody2D rb2d;
	int velocidade;

	// Use this for initialization
	void Start () {
	
		rb2d = GetComponent<Rigidbody2D> ();
		velocidade = 5;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		rb2d.velocity = (new Vector2 (velocidade, 0));

		if (transform.position.x >= 8) 
		{
			velocidade = -5;
		}

		if (transform.position.x <= -2) 
		{
			velocidade = 5;
		}
	}
}
