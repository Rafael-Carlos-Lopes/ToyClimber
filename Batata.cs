using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Batata : MonoBehaviour {
	[SerializeField]
	GameObject personagem;
	int velocidade;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (10 * Time.deltaTime, 0, 0);

		if (transform.position.x > 13) 
		{
			transform.position = new Vector2 (-7, transform.position.y);
		}
	}

	void OnTriggerEnter2D(Collider2D outro)
	{
		if (outro.tag == "Player") 
		{
			if (SceneManager.GetActiveScene ().name == "Fase1")
				SceneManager.LoadScene ("Fase2");

			else if(SceneManager.GetActiveScene ().name == "Fase2")
				SceneManager.LoadScene ("Vitoria");
		}
	}
}
