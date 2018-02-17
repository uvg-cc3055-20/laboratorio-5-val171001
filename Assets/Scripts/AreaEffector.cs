// Universidad del Valle de Guatemala
// Programacion de plataformas moviles y juegos
// File:_Areaeffector.cs
// Script para encender y apagar el area effector en un intervalo de tiempo
// Autores: David Valenzuela 171001


// Importar librerias
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEffector : MonoBehaviour {

    // Cuenta del tiempo
    private float time;

    // Effector que se activara y desactivara
    public GameObject childEffectorDown;
    public GameObject childEffectorUp;

    // Estado actual del effector 
    private bool active;

	// Use this for initialization
	void Start () {
        time = 0f;
        active = true;
	}
	
	// Update is called once per frame
	void Update () {

        // Sumamos el intervalo de tiempo
        time += Time.deltaTime;

        // Si el tiempo es mayor o igual a 1.9
        if (time >= 1.9f)
        {
            // Cambiamos el estado de active
            active = !active;

            // Aplicamos los cambios a los effectors
            childEffectorDown.gameObject.SetActive(active);
            childEffectorUp.gameObject.SetActive(active);

            // Reseteamos el tiempo
            time = 0f;
        }
	}
}
