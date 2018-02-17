// Universidad del Valle de Guatemala
// Programacion de plataformas moviles y juegos
// File:Weight.cs
// Script para dibujar una linea en el distance joint
// Autores: David Valenzuela 171001

// Importar librerias
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight : MonoBehaviour {

    // Linea a ser dibujada
    private LineRenderer line;
    // Distance joint al cual dibujaremos la linea
    private DistanceJoint2D distanceJoint;

	// Use this for initialization
	void Start () {

        // Obtenemos los componentes que utilizaremos
        line = GetComponent<LineRenderer>();
        distanceJoint = GetComponent<DistanceJoint2D>();
	}
	
	// Update is called once per frame
	void Update () {
        // Punto inicial de la linea
        line.SetPosition(0, transform.position);
        // Punto final de la linea
        line.SetPosition(1, distanceJoint.connectedBody.transform.position);
		
	}
}
