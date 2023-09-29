using UnityEngine;
using System.Collections;

public class Inventario : MonoBehaviour 
{
	Player Pj;
	
	public Vector2 FondoPos = Vector2.zero;
	public Vector2 FondoEsc = Vector2.zero;
	
	public Vector2 SlotsEsc = Vector2.zero;
	public Vector2 SlotPrimPos = Vector2.zero;
	public Vector2 Separacion = Vector2.zero;
	
	public int Fil = 0;
	public int Col = 0;
	
	public Texture2D TexturaVacia;//lo que aparece si no hay ninguna bolsa
	public Texture2D TextFondo;
	
	Rect R;
	public GUISkin GS;
	
	//------------------------------------------------------------------//
	
	// Use this for initialization
	void Start () 
	{
		Pj = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnGUI()
	{
		
	
		
		
	}
	
	//------------------------------------------------------------------//
}
