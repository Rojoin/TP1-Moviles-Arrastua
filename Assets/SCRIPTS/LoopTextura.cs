using UnityEngine;
using System.Collections;

public class LoopTextura : MonoBehaviour
{
    public float Intervalo = 1;
    float Tempo = 0;

    public Texture2D[] Imagenes;
    public Texture2D[] ImagenesMovil;
    int Contador = 0;

    // Use this for initialization
    void Start()
    {
#if UNITY_ANDROID
        if (ImagenesMovil.Length > 0)
            GetComponent<Renderer>().material.mainTexture = ImagenesMovil[0];
#else
             	if(Imagenes.Length > 0)
			GetComponent<Renderer>().material.mainTexture = Imagenes[0];
#endif
    }

    // Update is called once per frame
    void Update()
    {
        Tempo += Time.deltaTime;

        if (Tempo >= Intervalo)
        {
            Tempo = 0;
            Contador++;
            if (Contador >= Imagenes.Length)
            {
                Contador = 0;
            }
#if UNITY_ANDROID
            GetComponent<Renderer>().material.mainTexture = ImagenesMovil[Contador];
#else
          GetComponent<Renderer>().material.mainTexture = Imagenes[Contador];
#endif
        }
    }
}