using UnityEngine;
using System.Collections;

public class BlocosPai : MonoBehaviour {
	
	bool podeDestruir = true;
	public bool GetpodeDestruir()
	{
		return podeDestruir;
	}
	public void SetpodeDestruir( bool valor)
	{
		podeDestruir = valor;
	}
	public void SettimerParaDestruir()
	{
		Invoke ("PodeVoltarADestruir", 0.1f);
	}
	void PodeVoltarADestruir()
	{
		podeDestruir = true;
	}
}
