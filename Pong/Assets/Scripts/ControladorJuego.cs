using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ControladorJuego : MonoBehaviour
{
    public static ControladorJuego Singleton;
    [SerializeField]
    private Text Marcador1;
    [SerializeField]
    private Text Marcador2;
    [SerializeField]
    private Text MensajeGanador;
    [SerializeField]
    private GameObject panelGanador;
    [SerializeField]
    private GameObject panelPuntuacion;
    [SerializeField]
    private GameObject panelInicio;
    [SerializeField]
    private GameObject PrefabPelota;
    [SerializeField]
    private GameObject PrefabJugador;
    private Pelota pelota;
    private GameObject jugador1;
    private GameObject jugador2;
    
    private int _puntosJugador1;
    private int _puntosJugador2;
    public int puntosJugador1
    {
        set
        {
            this._puntosJugador1 = value;
            CambiarPuntuacion();
        }
        get
        {
            return this._puntosJugador1;
        }
    }
    public int puntosJugador2
    {
        set
        {
            _puntosJugador2 = value;
            CambiarPuntuacion();
        }
        get
        {
            return _puntosJugador2;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Singleton = this;
    }
    private void InstanciarActores(){
        this.pelota = Instantiate(PrefabPelota, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Pelota>();
        this.jugador1 = Instantiate(PrefabJugador, new Vector3(-8, 0, 0), Quaternion.identity);
        this.jugador2 = Instantiate(PrefabJugador, new Vector3(8, 0, 0), Quaternion.identity);
        Raqueta jug = this.jugador2.GetComponent<Raqueta>();
        jug.eje = "Vertical2";
    }
    public void CambiarPuntuacion()
    {
        if (_puntosJugador1 == 5 || _puntosJugador2 == 5)
        {
            Destroy(this.pelota.gameObject);
            Destroy(this.jugador1);
            Destroy(this.jugador2);
            this.panelPuntuacion.gameObject.SetActive(false);
            this.panelGanador.gameObject.SetActive(true);
            this.MensajeGanador.text = "Gano el jugador " + ((_puntosJugador1 == 5) ? 1 : 2);
        }
        this.Marcador1.text = this._puntosJugador1.ToString();
        this.Marcador2.text = this._puntosJugador2.ToString();
    }

    public void EmpezarPartida(){
        InstanciarActores();
        this._puntosJugador1 = 0;
        this._puntosJugador2 = 0;
        this.panelInicio.SetActive(false);
    }
    public void ClickBotonReintentar()
    {
        this._puntosJugador1 = 0;
        this._puntosJugador2 = 0;
        this.Marcador1.text = this._puntosJugador1.ToString();
        this.Marcador2.text = this._puntosJugador2.ToString();
        this.panelPuntuacion.gameObject.SetActive(true);
        this.panelGanador.gameObject.SetActive(false);
        this.InstanciarActores();
    }
}
