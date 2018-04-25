﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambiaEscena : MonoBehaviour {

    Text mensajeEscena;
	public string escenaACambiar;// Aula si es un examen
    public string Examen;
    private void Start()
    {
        mensajeEscena = GameObject.FindGameObjectWithTag("MensajeEscena").GetComponent<Text>();
    }
    void OnTriggerEnter2D(Collider2D col){

        if (col.tag == "Player")
        {
            if (escenaACambiar == "Aula")
            {
                int num = Random.Range(0, 10);
                if (num < 3)
                    SceneManager.LoadScene("Pasillos");
                else
                {
                    mensajeEscena.gameObject.SetActive(true);
                    if (escenaACambiar != "Aula")
                        mensajeEscena.text = "Pulsa X para acceder al " + escenaACambiar;
                    else
                        mensajeEscena.text = "Pulsa X para acceder al Aula de " + Examen;
                    if (Input.GetKeyDown(KeyCode.X))
                    {
                        mensajeEscena.gameObject.SetActive(false);
                        SceneManager.LoadScene(escenaACambiar);
                    }
                }
            }
            else
            {
                mensajeEscena.gameObject.SetActive(true);
                if (escenaACambiar != "Aula")
                    mensajeEscena.text = "Pulsa X para acceder al " + escenaACambiar;
                else
                    mensajeEscena.text = "Pulsa X para acceder al Aula de " + Examen;
                if (Input.GetKeyDown(KeyCode.X))
                {
                    mensajeEscena.gameObject.SetActive(false);
                    SceneManager.LoadScene(escenaACambiar);
                }
            }
                if (escenaACambiar != "Piso1")
                    GameManager.instance.Escena1PlayerPos = GameManager.instance.ActualPlayerPosition;
            
                if (Examen == "Matematicas" && !GameManager.instance.finMates)
                    GameManager.instance.Examen = 0;
                else if (Examen == "Historia" && !GameManager.instance.finHistoria)
                    GameManager.instance.Examen = 1;
                else if (Examen == "Lengua" && !GameManager.instance.finLengua)
                    GameManager.instance.Examen = 2;
                else if (Examen == "Geografia" && !GameManager.instance.finGeo)
                    GameManager.instance.Examen = 3;
                else
                    GameManager.instance.Examen = 4;
            }
        }
	}

