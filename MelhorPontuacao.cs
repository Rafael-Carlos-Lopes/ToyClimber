using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MelhorPontuacao : MonoBehaviour {
	//[SerializeField]
	//Text texto;
	//int pontosDoJogador;
	//int melhorPonto;

	// Use this for initialization
	void Start () {
	//	pontosDoJogador = PlayerPrefs.GetInt ("PontosDoJogador1");
	//	melhorPonto = PlayerPrefs.GetInt ("PontoAlto");
	//	texto.text = "Melhor Pontuação: " + melhorPonto + " Seus Pontos: " + pontosDoJogador;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) 
		{
			Application.LoadLevel (0);
		}
	
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Application.Quit ();
		}
	}
}
