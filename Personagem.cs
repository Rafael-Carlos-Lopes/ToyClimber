using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Personagem : MonoBehaviour {

	[SerializeField]
	Rigidbody2D rbDaNuvem;
	[SerializeField]
	Transform transfDaNuvem;
	bool naNuvem = false;
	Rigidbody2D rb2d;
	Animator anim;
	GameObject cam, colisorAtaque;
	[SerializeField] int forcaDoPulo, velocidade;
	bool pulando = false;
	bool podePular = true;
	bool estaNoChao = false;
	bool podeAndar = true;
	[SerializeField] LayerMask nemSeiPraQ;
	float contadorAtaque = 0;
	bool atacando = false;
	bool girando = false;
	AudioSource puloSong;
	int pontosJ1 = 0;
	bool morreu = false;

	float axisH = 0;

	bool direita,esquerda,cima,ataque;

	[SerializeField]
	Collider2D col2d,colCirculo;

	[SerializeField]
	Collider2D col2dPulo;

	SpriteRenderer sr;
	//pega a imagem do personagem quando perde
	[SerializeField]
	Sprite Perdeu;

	//=========================================================

	enum qualUsar{Vogais, Consoantes};
	[SerializeField]
	qualUsar atual = qualUsar.Vogais;

	[SerializeField]
	int[] vogaisNum;
	[SerializeField]
	int[] consoantesNum;

	[SerializeField]
	GameObject[] vogais;

	[SerializeField]
	GameObject[] consoantes;

	void Awake()
	{
		cam = GameObject.FindGameObjectWithTag ("MainCamera");//pegando objeto com tag camera
		colisorAtaque = GameObject.Find("ColisorAtaque");
	}

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();//pegando rigidbody
		anim = GetComponent<Animator> ();//pegando animator
		colisorAtaque.SetActive(false);
		puloSong = gameObject.GetComponent<AudioSource> ();
		sr = GetComponent<SpriteRenderer> ();
		pontosJ1 = PlayerPrefs.GetInt ("PontosDoJogador1");

		col2d.enabled = true;
		col2dPulo.enabled = true;
	}

	void Update ()
	{
		if (direita == true) 
		{
			axisH = 1;
		} 
		else if (esquerda == true) 
		{
			axisH = -1;
		} 

		else 
		{
			axisH = 0;
		}

		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Application.Quit ();
		}

		//RayCast--------------------------------------------------------------------------------------------------
		RaycastHit2D rcInfo;
		rcInfo = Physics2D.Raycast (transform.position, -Vector3.up, 0.9f, nemSeiPraQ);
		if (morreu == false) {
			if (estaNoChao && podePular && Input.GetKeyDown(KeyCode.Space)) {//pular
				rb2d.velocity = new Vector2 (0, 8f);
				puloSong.Play ();
				anim.SetBool ("Andando", false);
				anim.SetBool ("Parado", false);
				//cima = false;
			}
		}
	}

	void FixedUpdate()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Application.Quit ();
		}
		//Camera seguir personagem--------------------------------------------------------------------------------------
		if (transform.position.y <= 25 && transform.position.y >= 0.1f)
		cam.transform.position = new Vector3 (3.01f , transform.position.y + 3.8f, -10);
		//---------------------------------------------------------------------------------------------------------
		//RayCast--------------------------------------------------------------------------------------------------
		RaycastHit2D rcInfo;
		rcInfo = Physics2D.Raycast (transform.position, -Vector3.up, 0.9f, nemSeiPraQ);
		//Debug.DrawLine (transform.position, rcInfo.point, Color.blue);
		//---------------------------------------------------------------------------------------------------------
		if (rcInfo.collider != null)//verificando colisao
		{
			estaNoChao = true;
			anim.SetBool ("Pulando", false);
			anim.SetBool ("Parado", true);
		}
		else
		{
			estaNoChao = false;
			anim.SetBool ("Pulando", true);
			anim.SetBool ("Parado", false);
		}

		/*if (estaNoChao && podePular && (Input.GetButtonDown("Jump") || (Input.GetKeyDown(KeyCode.C))))//pular
		{
			rb2d.velocity = new Vector2 (0,7.1f);
			puloSong.Play ();
			anim.SetBool ("Andando", false);
			anim.SetBool ("Parado", false);
		}*/

		if (Input.GetKeyDown(KeyCode.X) && estaNoChao)//atacar
		{
			if(contadorAtaque == 0)
			{
				atacando = true;
			
			//Invoke ("SumirColisorAtaque", 0.35f);
			podeAndar = false;
			anim.SetTrigger ("Atacando");
			rb2d.velocity = new Vector2 (0, rb2d.velocity.y);
			}
		}

		if (atacando == true) 
		{
			contadorAtaque += Time.deltaTime;

			if(contadorAtaque >= 0.3f)
			{
				colisorAtaque.SetActive (true);
			}

			if(contadorAtaque >= 0.7f)
			{
				colisorAtaque.SetActive(false);
				contadorAtaque = 0;
				atacando = false;
			}
		}

		if (anim.GetBool("Andando"))
		{
			podeAndar = true;
		}

		if (podeAndar == true) 
		{
			if (naNuvem == false) {
				rb2d.velocity = new Vector2 (Input.GetAxisRaw("Horizontal") * velocidade, rb2d.velocity.y);//velocidade do personagem
			}
			else
			{
				if(transform.position.y > transfDaNuvem.position.y)
					rb2d.velocity = new Vector2 ((Input.GetAxisRaw("Horizontal") * velocidade)  + rbDaNuvem.velocity.x, rb2d.velocity.y);//velocidade do personagem
			}
		}

		if (Input.GetAxisRaw("Horizontal") == -1)//andando
		{
			colisorAtaque.transform.position = new Vector2(transform.position.x - 0.5f, transform.position.y);
			transform.localScale = new Vector3 (-1f, 1f, 1f);//invertendo a imagem
			anim.SetBool ("Andando", true);
		}
		else if (Input.GetAxisRaw("Horizontal") == 1)//andando
		{
			colisorAtaque.transform.position = new Vector2(transform.position.x + 0.5f, transform.position.y);
			transform.localScale = new Vector3 (1f, 1f, 1f);//invertendo a imagem
			anim.SetBool ("Andando", true);
		}
		else
		{
			anim.SetBool ("Andando", false);
		}
		if (!estaNoChao)
		{
			anim.SetBool ("Andando", false);
		}

		if (girando == true) 
		{
			transform.eulerAngles += new Vector3(0,0,20);
		}

		if (transform.position.y <= -20) 
		{
			SceneManager.LoadScene("GameOver");
		}
			
	}

	//void SumirColisorAtaque()
	//{
	//	colisorAtaque.SetActive (false);
	//}


	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Inimigo") 
		{
			anim.Stop();
			sr.sprite = Perdeu;
			girando = true;
			col2d.enabled = false;
			col2dPulo.enabled = false;
			colCirculo.enabled = false;
			rb2d.velocity = new Vector2 (rb2d.velocity.x, 2);
			morreu = true;
		}

		if (col.gameObject.tag == "Espinho") 
		{
			anim.Stop();
			sr.sprite = Perdeu;
			girando = true;
			col2d.enabled = false;
			col2dPulo.enabled = false;
			colCirculo.enabled = false;
			rb2d.velocity = new Vector2 (rb2d.velocity.x, 2);
		}

		if (atual == qualUsar.Vogais)
		{
			for (int i = 0; i < vogais.Length; i++) {
				if (col.name.Equals (vogais [i].name)) {
					setPontos (10);
					vogaisNum [i]++;
					Destroy (col.gameObject);
				}
			}

			for (int i = 0; i < vogais.Length; i++) {
				if (col.name.Equals (consoantes [i].name)) {
					setPontos (-10);
					consoantesNum [i]++;
					Destroy (col.gameObject);
				}
			}
		}

		else if (atual == qualUsar.Consoantes)
		{
			for (int i = 0; i < vogais.Length; i++) {
				if (col.name.Equals (vogais [i].name)) {
					setPontos (-10);
					vogaisNum [i]++;
					Destroy (col.gameObject);
				}
			}

			for (int i = 0; i < vogais.Length; i++) {
				if (col.name.Equals (consoantes [i].name)) {
					setPontos (10);
					consoantesNum [i]++;
					Destroy (col.gameObject);
				}
			}
		}
	}

	void OnCollisionStay2D(Collision2D col)
	{
		if (col.gameObject.tag == "nuvem") 
		{
			naNuvem = true;
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "nuvem") 
		{
			naNuvem = false;
		}
	}

	public void setPontos(int valor)
	{
		pontosJ1 += valor;
		PlayerPrefs.SetInt ("PontosDoJogador1", pontosJ1);
		if (pontosJ1 > PlayerPrefs.GetInt ("PontoAlto"))
		{
			PlayerPrefs.SetInt ("PontoAlto", pontosJ1);
		}
	}

}
