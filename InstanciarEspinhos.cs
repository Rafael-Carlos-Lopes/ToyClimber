using UnityEngine;
using System.Collections;

public class InstanciarEspinhos : MonoBehaviour {

	[SerializeField]
	GameObject espinho;
	[SerializeField]
	GameObject personagem;

	Vector3 pos;
	GameObject spike;

	// Use this for initialization
	void Start () {
		Invoke ("InstanciarEsp", 3f);
	}

	void InstanciarEsp()
	{
		pos = new Vector3 (Random.Range (-3f, 9f), 40, 0);
		spike = Instantiate (espinho, pos, Quaternion.identity) as GameObject;

		if (personagem.transform.position.y <= 24) {
			Invoke ("InstanciarEsp", 3f);
		}
	}
}
