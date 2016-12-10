using UnityEngine;
using System.Collections;

public class Tiro : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (0, 3 * Time.deltaTime, 0);

		if (transform.position.x < -6.30f || transform.position.x > 12.36f) 
		{
			Destroy (gameObject);
		}
	}
}
