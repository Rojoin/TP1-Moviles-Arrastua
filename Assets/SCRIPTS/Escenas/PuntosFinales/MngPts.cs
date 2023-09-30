using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MngPts : MonoBehaviour
{
    public float TiempEmpAnims = 2.5f;
    float Tempo = 0;


    public Sprite[] Ganadores;
    public TextMeshProUGUI leftPlayer;
    public TextMeshProUGUI rightPlayer;
    public Image winnerImage;
    public GameObject secondPlayer;
    public GameObject Fondo;

    public float TiempEspReiniciar = 10;


    public float TiempParpadeo = 0.7f;
    float TempoParpadeo = 0;
    bool PrimerImaParp = true;

    public bool ActivadoAnims = false;

    Visualizacion Viz = new Visualizacion();

    //---------------------------------//

    // Use this for initialization
    void Start()
    {
        SetGanador();
        rightPlayer.text = "";
        leftPlayer.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //PARA JUGAR
        if (Input.GetKeyDown(KeyCode.Space) ||
            Input.GetKeyDown(KeyCode.Return) ||
            Input.GetKeyDown(KeyCode.Alpha0))
        {
            SceneManager.LoadScene(0);
        }

        //CIERRA LA APLICACION
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


        TiempEspReiniciar -= Time.deltaTime;
        if (TiempEspReiniciar <= 0)
        {
            SceneManager.LoadScene(0);
        }


        if (ActivadoAnims)
        {
            TempoParpadeo += Time.deltaTime;

            if (TempoParpadeo >= TiempParpadeo)
            {
                TempoParpadeo = 0;

                if (PrimerImaParp)
                    PrimerImaParp = false;
                else
                {
                    winnerImage.gameObject.SetActive(true);
                    TempoParpadeo += 0.1f;
                    PrimerImaParp = true;
                }
            }
        }

        if (ActivadoAnims)
        {
            SetDinero();
        }

        if (!ActivadoAnims)
        {
            Tempo += Time.deltaTime;
            if (Tempo >= TiempEmpAnims)
            {
                Tempo = 0;
                ActivadoAnims = true;
            }
        }
    }


    //---------------------------------//


    void SetGanador()
    {
        SoundManager.Instance.PlayFinaleMusic();
        if (GameControllerSettings.Instance.selectedGameMode == GameControllerSettings.GameMode.Single)
        {
            var currentMaxScore = GameControllerSettings.Instance.GetMaxScore();
            if (DatosPartida.PtsGanador > currentMaxScore)
            {
                SoundManager.Instance.PlayMoneySound();
                winnerImage.sprite = Ganadores[2];
                GameControllerSettings.Instance.SetMaxScore(DatosPartida.PtsGanador);
            }
            else
            {
                winnerImage.sprite = Ganadores[3];
            }
            secondPlayer.gameObject.SetActive(false);
        }
        else
        {
            switch (DatosPartida.LadoGanadaor)
            {
                case DatosPartida.Lados.Der:

                    winnerImage.sprite = Ganadores[1];

                    break;

                case DatosPartida.Lados.Izq:

                    winnerImage.sprite = Ganadores[0];

                    break;
            }

            Time.timeScale = 1;
        }
    }

    void SetDinero()
    {
        if (DatosPartida.LadoGanadaor == DatosPartida.Lados.Izq) //izquierda
        {
            if (!PrimerImaParp) //para que parpadee
                leftPlayer.text = "$" + Viz.PrepararNumeros(DatosPartida.PtsGanador);
            else
                leftPlayer.text = "";
        }
        else
        {
            leftPlayer.text = "$" + Viz.PrepararNumeros(DatosPartida.PtsPerdedor);
        }


        if (DatosPartida.LadoGanadaor == DatosPartida.Lados.Der) //derecha
        {
            if (!PrimerImaParp) //para que parpadee
                rightPlayer.text = "$" + Viz.PrepararNumeros(DatosPartida.PtsGanador);
            else
                rightPlayer.text = "";
        }
        else
        {
            rightPlayer.text = "$" + Viz.PrepararNumeros(DatosPartida.PtsPerdedor);
        }
    }


    public void DesaparecerGUI()
    {
        ActivadoAnims = false;
        Tempo = -100;
    }
}