using UnityEngine;
using System.Collections;

public class Pontos : MonoBehaviour {
	[SerializeField]
	GameObject personagem;

	void OnTriggerEnter2D(Collider2D outro)
	{
		if (outro.tag == "Player") 
		{
			personagem.GetComponent<Personagem> ().setPontos (10);
			gameObject.GetComponent<AudioSource> ().Play ();
			Destroy (gameObject,0.2f);
		}
	}
}
