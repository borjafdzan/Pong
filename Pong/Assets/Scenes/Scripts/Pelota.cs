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

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D colision){
        Debug.Log(colision.transform.position);
       if (colision.gameObject.name == "Jugador1"){
           float y = FactorGolpeo(transform.position, colision.transform.position, colision.collider.bounds.size.y);
           Vector2 direccion = new Vector2(1, y).normalized;
           cuerpo.velocity = direccion * velocidad;
       } 
       if (colision.gameObject.name == "Jugador2"){
           float y = FactorGolpeo(transform.position, colision.transform.position, colision.collider.bounds.size.y);
           Vector2 direccion = new Vector2(-1, y).normalized;
           cuerpo.velocity = direccion * velocidad;

       }

       if (colision.gameObject.tag == "EliminacionJugador1"){
           ResetearPelota();
           ControladorJuego.Singleton.puntosJugador2 = ControladorJuego.Singleton.puntosJugador2 +1;
       } else if (colision.gameObject.tag == "EliminacionJugador2"){
           ResetearPelota();
           ControladorJuego.Singleton.puntosJugador1 = ControladorJuego.Singleton.puntosJugador1 +1;
       }
    }
    public void ResetearPelota(){
           this.transform.position = this.posicionInicio;
           this.cuerpo.velocity = Vector2.right * velocidad;
    }

    private float FactorGolpeo(Vector2 posicionPelota, Vector2 posicionRaqueta, float alturaRaqueta){
        return (posicionPelota.y - posicionRaqueta.y) / alturaRaqueta;
    }
}
