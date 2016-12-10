using UnityEngine;
using System.Collections;

public class InimigoUrso : MonoBehaviour {

	Rigidbody2D rb2d;
	
	[SerializeField]
	BoxCollider2D bCol;
	
	[SerializeField]
	BoxCollider2D bColTrigger;
	
	int velocidade;
	
	bool acertado = false; 
	
	Animator anim;

	[SerializeField]
	GameObject tiro;

	[SerializeField]
	GameObject rotacao;

	Vector3 posInstanciamento;

	[SerializeField]
	GameObject explosao;
	
	void Start()
	{
		explosao.SetActive (false);

		bCol.enabled = false;
		bColTrigger.enabled = false;
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		
		if (transform.position.x < 0) 
		{
			transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
			velocidade = 2;
		}
		
		else 
		{
			transform.localScale = new Vector3 (transform.localScale.x * 1, transform.localScale.y, transform.localScale.z);
			velocidade = -2;
		}

		InvokeRepeating ("Atirar", 6f, 6f);
	}
	
	void OnTriggerEnter2D (Collider2D outro)
	{
		if (outro.gameObject.name == "ColisorAtaque") {
			if(acertado == false)
			{
			explosao.SetActive(true);
			velocidade = 0;
			rb2d.velocity = new Vector2 (0, 0);
			acertado = true;
			bCol.enabled = false;
			bColTrigger.enabled = false;
			anim.Stop();
			Destroy(gameObject,0.5f);
			acertado = true;
			}
		}
		if (outro.gameObject.tag == "Inst") {
			if(acertado == false)
			{
			transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
			velocidade *= -1;
			rb2d.velocity = new Vector2 (velocidade, rb2d.velocity.y);
			}
		}
	}
	
	void Update()
	{
		posInstanciamento = new Vector3 (rotacao.transform.position.x, rotacao.transform.position.y + 0.08f, rotacao.transform.position.z);

		if (transform.localScale.x == 0.4f) {
			rotacao.transform.eulerAngles = new Vector3 (rotacao.transform.eulerAngles.x, 0, 90);
		} 

		else if (transform.localScale.x == -0.4f) 
		{
			rotacao.transform.eulerAngles = new Vector3 (rotacao.transform.eulerAngles.x, 180, 90);
		}

		//if (vida == 0)
		//Destroy (gameObject);
		rb2d.velocity = new Vector2 (velocidade, rb2d.velocity.y);
		
		if (transform.position.x < -10 || transform.position.x > 15) 
		{
			Destroy(gameObject);
		}
		
		if (bCol.enabled == false && acertado == false) 
		{
			Invoke("AtivarColisao", 1.8f);
		}
	}

	void Atirar()
	{
		if (acertado == false) {
			GameObject g = (GameObject)Instantiate (tiro, posInstanciamento, rotacao.transform.rotation);
		}
	}
	
	void AtivarColisao()
	{
		bCol.enabled = true;
		bColTrigger.enabled = true;
	}
}
