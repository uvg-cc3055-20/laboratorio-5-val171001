// Universidad del Valle de Guatemala
// Programacion de plataformas moviles y juegos
// File:Character.cs
// Script para el movimiento del personaje
// Autores: David Valenzuela 171001 (Codigo original obtenido de GitHub)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

    // Componenetes del personaje
    Rigidbody2D rb2d;
    SpriteRenderer sr;
    Animator anim;

    // Velocidad con la que avanza
    private float speed = 5f;

    // Fuerza con la que salta
    private float jumpForce = 250f;

    // Hacia donde apunta el personaje
    private bool facingRight = true;

    // Parte de abajo del personaje
    public GameObject feet;
    // Layer del mundo
    public LayerMask layerMask;


	void Start () {

        // obtenemos los componenetes del personaje
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }
	

	void Update () {
        // Obtenemos si esta presionando un boton para moverse
        float move = Input.GetAxis("Horizontal");

        // Si esta presionando el boton para moverse
        if (move != 0) {
            // Movemos hacia donde se haya presionado
            rb2d.transform.Translate(new Vector3(1, 0, 0) * move * speed * Time.deltaTime);
            // Hacia donde apunta el personaje
            facingRight = move > 0;
        }

        // Agregar la velocidad a la animacion
        anim.SetFloat("Speed", Mathf.Abs(move));

        // De ser necesario cambiamos hacia donde apunta el personaje
        sr.flipX = !facingRight;

        // Si presina boton para saltar
        if (Input.GetButtonDown("Jump")) {
            // Creamos un raycast
            RaycastHit2D raycast = Physics2D.Raycast(feet.transform.position, Vector2.down, 0.1f, layerMask);

            // Si el raycast detecta el piso
            if(raycast.collider != null)
            {   
                // Saltamos
                rb2d.AddForce(Vector2.up * jumpForce);
            }
        }
	}
}
