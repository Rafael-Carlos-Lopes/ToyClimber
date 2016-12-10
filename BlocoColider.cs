using UnityEngine;
using System.Collections;

public class BlocoColider : BlocosPai {
	[SerializeField]
	GameObject controlador,quebrado, inst;

	void OnTriggerEnter2D(Collider2D outro)
	{
		if (outro.gameObject.CompareTag ("Player") && controlador.GetComponent<BlocosPai>().GetpodeDestruir())
		{
			Invoke ("DelayDestruir", 0.1f);
		}
	}

	void DelayDestruir()
	{
		controlador.GetComponent<BlocosPai>().SetpodeDestruir(false);
		controlador.GetComponent<BlocosPai>().SettimerParaDestruir();
		Instantiate (quebrado, transform.position, Quaternion.identity);
		Instanciar ();
		Destroy (gameObject);
	}

	void Instanciar ()
	{
		Instantiate (inst, transform.position, Quaternion.identity);
	}
}
