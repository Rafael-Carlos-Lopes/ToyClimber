using UnityEngine;
using System.Collections;

public class Bomba : MonoBehaviour {

	[SerializeField]
	GameObject explosao;

	Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		explosao.SetActive (false);
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate (0, -1 * Time.deltaTime, 0);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag.Equals ("Plataforma")) 
		{
			Destroy(gameObject,0.5f);
			explosao.SetActive(true);
			transform.Translate(0,0,0);
			rb2d.constraints = RigidbodyConstraints2D.FreezePositionY;
		}
	}


}
