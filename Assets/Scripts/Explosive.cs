// Universidad del Valle de Guatemala
// Programacion de plataformas moviles y juegos
// File: Explosive.cs
// Script para dibujar una linea en el hinge joint
// Autores: David Valenzuela 171001

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour {

    // Linea a ser dibujada
    private LineRenderer line;

    // Use this for initialization
    void Start () {
        // Obtenemos los componentes necesarios
        line = GetComponent<LineRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        // Punto inicial de la linea
        line.SetPosition(0, transform.position);
        // Punto final de la linea
        line.SetPosition(1, new Vector3(7.578012f, 1.026789f, 0.0f));

    }
}
