// Universidad del Valle de Guatemala
// Programacion de plataformas moviles y juegos
// File:Character.cs
// Script para el movimiento del personaje
// Autores: David Valenzuela 171001 (Codigo original obtenido de GitHub)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    // Use this for initialization
    void Start () {

        // obtenemos los componenetes del personaje
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
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

    // Collision with a trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Al llegar al portal cambiamos al siguiente nivel
        if(collision.tag == "Portal")
        {  
            // Si esta en el nivel uno, pasamos al 2
            if(SceneManager.GetActiveScene().name == "Dungeon1")
            {
                SceneManager.LoadScene("Dungeon2");

            // Si esta en el nivel 2, pasamos al 3
            } else if (SceneManager.GetActiveScene().name == "Dungeon2")
            {
                SceneManager.LoadScene("Dungeon3");
            }


        }
    }

    // Collision with a Collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // SI chici contra un obstaculo
        if(collision.collider.tag == "Obstaculo")
        {   
            // Si esta en el nivel 2, regresamos al nivel 1
            if(SceneManager.GetActiveScene().name == "Dungeon2")
            {
                SceneManager.LoadScene("Dungeon1");
            
            // Si esta en el nivel 3, regersamos al nivel 2
            }else if (SceneManager.GetActiveScene().name == "Dungeon3")
            {
                SceneManager.LoadScene("Dungeon2");
            }
        }
    }
}
