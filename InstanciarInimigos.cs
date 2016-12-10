using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InstanciarInimigos : MonoBehaviour {
	[SerializeField]
	Transform[]AndaresDir;
	[SerializeField]
	Transform[]AndaresEsq;

	[SerializeField]
	GameObject foca;

	[SerializeField]
	GameObject urso;

	GameObject inimigo;

	float sort;
	int sortAndar;

	// Use this for initialization
	void Start () {
		Invoke("InstanciarInimigo",1f);
	}

	void InstanciarInimigo()
	{
		if (SceneManager.GetActiveScene ().name == "Fase1") 
		{
			sort = Random.Range (0, 2);
			sortAndar = Random.Range (0, 7);

			if (sort == 0)
			{
				inimigo = Instantiate(foca, AndaresDir [sortAndar].position, Quaternion.identity) as GameObject;
			}
			if (sort == 1)
			{
				inimigo = Instantiate(foca, AndaresEsq [sortAndar].position, Quaternion.identity) as GameObject;
			}
			
			Invoke ("InstanciarInimigo", 7f);
		}

		else if(SceneManager.GetActiveScene ().name == "Fase2") 
		{
			sort = Random.Range (0, 2);
			sortAndar = Random.Range (0, 7);

			if (sort == 0)
			{
				inimigo = Instantiate(urso, AndaresDir [sortAndar].position, Quaternion.identity) as GameObject;
			}
			if (sort == 1)
			{
				inimigo = Instantiate(urso, AndaresEsq [sortAndar].position, Quaternion.identity) as GameObject;
			}
			
			Invoke ("InstanciarInimigo", 2f);
		}

		else if(SceneManager.GetActiveScene ().name == "Fase3") 
		{
			sort = Random.Range (0, 2);
			sortAndar = Random.Range (0, 7);
			
			while (sortAndar == 4) 
			{
				sortAndar = Random.Range (0, 7);
			}

			if (sort == 0)
			{
				if(sortAndar <= 3)
				inimigo = Instantiate(foca, AndaresDir [sortAndar].position, Quaternion.identity) as GameObject;

				else 
				inimigo = Instantiate(urso, AndaresDir [sortAndar].position, Quaternion.identity) as GameObject;
			}
			if (sort == 1)
			{
				if(sortAndar <= 3)
					inimigo = Instantiate(foca, AndaresDir [sortAndar].position, Quaternion.identity) as GameObject;
				
				else 
					inimigo = Instantiate(urso, AndaresDir [sortAndar].position, Quaternion.identity) as GameObject;
			}
			
			Invoke ("InstanciarInimigo", 7f);
		}
	}
}
