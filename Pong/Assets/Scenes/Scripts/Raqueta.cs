using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Raqueta : MonoBehaviour
{
    public float velocidad = 50;
    public string eje ;

    private Rigidbody2D rb;
    void Start(){
        this.rb = GetComponent<Rigidbody2D>();
    }
    void Update(){
        float v = Input.GetAxis(eje);
        rb.velocity = new Vector2(0, v) * velocidad;
    }
}
