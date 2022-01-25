using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControladorJuego : MonoBehaviour
{
    public static ControladorJuego Singleton;
    public TextMeshPro Marcador1;
    public TextMeshPro Marcador2;
    public int puntosJugador1
    {
        set
        {
            puntosJugador1 = value;
            CambiarPuntuacion();
        }
        get
        {
            return puntosJugador1;
        }
    }
    public int puntosJugador2
    {
        set
        {
            puntosJugador2 = value;
            CambiarPuntuacion();
        }
        get
        {
            return puntosJugador2;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.puntosJugador1 = 0;
        this.puntosJugador2 = 0;
        Singleton = this;
    }
    public void CambiarPuntuacion()
    {
        this.Marcador1.text = this.puntosJugador1.ToString();
        this.Marcador2.text = this.puntosJugador2.ToString(); 
    }
}
