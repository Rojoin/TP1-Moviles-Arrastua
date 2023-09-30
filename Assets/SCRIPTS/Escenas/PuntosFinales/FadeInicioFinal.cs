using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeInicioFinal : MonoBehaviour 
{
	public float Duracion = 2;
	public float Vel = 2;
	float TiempInicial;
	
	MngPts Mng;
	private Image image;
	Color initialColor;
	
	bool MngAvisado = false;

	// Use this for initialization
	void Start ()
	{
		// Mng = (MngPts)GameObject.FindObjectOfType(typeof (MngPts));
		// TiempInicial = Mng.TiempEspReiniciar;
		// image = GetComponent<Image>();
		// initialColor = image.material.color;
		// initialColor.a = 0;
		// image.material.color = initialColor;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		// if(Mng.TiempEspReiniciar > TiempInicial - Duracion)//aparicion
		// {
		// 	initialColor =image.material.color;
		// 	initialColor.a += Time.deltaTime / Duracion;
		// 	image.material.color = initialColor;			
		// }
		// else if(Mng.TiempEspReiniciar < Duracion)//desaparicion
		// {
		// 	initialColor = image.material.color;
		// 	initialColor.a -= Time.deltaTime / Duracion;
		// 	image.material.color = initialColor;
		// 	
		// 	if(!MngAvisado)
		// 	{
		// 		MngAvisado = true;
		// 		// Mng.DesaparecerGUI();
		// 	}
		// }
				
	}
}
