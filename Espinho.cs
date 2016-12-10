using UnityEngine;
using System.Collections;

public class Espinho : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate (new Vector3 (0, -10 * Time.fixedDeltaTime, 0));
	}
}
