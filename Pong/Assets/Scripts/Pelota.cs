using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    float velocidad = 10;
    Rigidbody2D cuerpo;
    Vector3 posicionInicio;
    // Start is called before the first frame update
    void Start()
    {
        this.cuerpo = GetComponent<Rigidbody2D>();
        this.cuerpo.velocity = Vector2.right * velocidad;
        this.posicionInicio = this.transform.position;
    }


    void OnCollisionEnter2D(Collision2D colision)
    {
        Debug.Log(colision.transform.position);
        Vector3 direccion;
        if (colision.gameObject.tag == "Player")
        {
            float y = FactorGolpeo(transform.position, colision.transform.position, colision.collider.bounds.size.y);
            direccion = new Vector2(-this.transform.position.normalized.x, y).normalized;
            cuerpo.velocity = direccion * velocidad;
        }


        if (colision.gameObject.tag == "EliminacionJugador1")
        {
            ResetearPelota();
            ControladorJuego.Singleton.puntosJugador1 = ControladorJuego.Singleton.puntosJugador1 + 1;
        }
        else if (colision.gameObject.tag == "EliminacionJugador2")
        {
            ResetearPelota();
            ControladorJuego.Singleton.puntosJugador2 = ControladorJuego.Singleton.puntosJugador2 + 1;
        }
    }
    public void ResetearPelota()
    {
        this.transform.position = this.posicionInicio;
        this.cuerpo.velocity = Vector2.right * velocidad;
    }

    private float FactorGolpeo(Vector2 posicionPelota, Vector2 posicionRaqueta, float alturaRaqueta)
    {
        return (posicionPelota.y - posicionRaqueta.y) / alturaRaqueta;
    }
}
