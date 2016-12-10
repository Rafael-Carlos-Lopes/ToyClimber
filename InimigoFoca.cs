using UnityEngine;
using System.Collections;

public class InimigoFoca : MonoBehaviour {
	Rigidbody2D rb2d;

	[SerializeField]
	BoxCollider2D bCol;

	[SerializeField]
	BoxCollider2D bColTrigger;

	int velocidade;

	bool acertado = false; 

	Animator anim;

	void Start()
	{
		bCol.enabled = false;
		bColTrigger.enabled = false;
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

		if (transform.position.x < 0) 
		{
			transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
			velocidade = 1;
		}

		else 
		{
			transform.localScale = new Vector3 (transform.localScale.x * 1, transform.localScale.y, transform.localScale.z);
			velocidade = -1;
		}
	}

	void OnTriggerEnter2D (Collider2D outro)
	{
		if (outro.gameObject.name == "ColisorAtaque" || outro.gameObject.tag == "Ataque") {
			if (acertado == false) {
				gameObject.GetComponent<AudioSource> ().Play ();
				transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, 270);
				transform.position = new Vector2 (transform.position.x, transform.position.y - 0.4f);
				if (transform.position.x >= 3) {
					transform.localScale = new Vector3 (-0.7f, transform.localScale.y, transform.localScale.z);
					velocidade = 1;
				} else {
					transform.localScale = new Vector3 (0.7f, transform.localScale.y, transform.localScale.z);
					velocidade = -1;
				}
				//transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				//velocidade *= -1;
				rb2d.velocity = new Vector2 (velocidade * -1, rb2d.velocity.y);
				acertado = true;
				bCol.enabled = false;
				bColTrigger.enabled = false;
				anim.Stop ();
			}
		}
		if (outro.gameObject.tag == "Inst") {
			if (acertado == false) {
				transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				velocidade = velocidade * -1;
				rb2d.velocity = new Vector2 (velocidade, rb2d.velocity.y);
			}
		}
	}

	void Update()
	{
		//if (vida == 0)
		//Destroy (gameObject);
		rb2d.velocity = new Vector2 (velocidade, rb2d.velocity.y);

		if (transform.position.x < -10 || transform.position.x > 15) 
		{
			Destroy(gameObject);
		}

		if (bCol.enabled == false && acertado == false) 
		{
			Invoke("AtivarColisao", 2f);
		}
	}

	void AtivarColisao()
	{
		bCol.enabled = true;
		bColTrigger.enabled = true;
	}
}
