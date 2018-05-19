﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AparecenRandoms : MonoBehaviour {
    float Altura;
    float Anchura;
    float camaraPosX;
    float camaraPosY;
    string cuenta;
    int resultado;
    int tiempoMax = 10;
    float tiempoPasado;
    int operacionesHechas=-1;
    public Text suma;
    public Text hechas;
    public float tiempo;
    public GameObject coleccionable;
	// Use this for initialization
	void Start () {
        Altura = (Camera.main.orthographicSize*2)-0.25f;
        Anchura = (Altura*Camera.main.aspect)-0.25f;
        camaraPosX = (Camera.main.transform.position.x)-0.25f;
        camaraPosY = (Camera.main.transform.position.y)-0.25f;
        
        CambiaOperacion();

    }

    public void CambiaOperacion()
    {
        tiempoPasado = 0;
        operacionesHechas++;
        resultado = CalculaOperacion();
        suma.text = cuenta;
        CancelInvoke();
        SpawnSoluciones();
		ActualizaOperacion ();
		CompruebaOperacion ();
    }
	// Update is called once per frame
	public void SpawnSoluciones  () {
		if (!GameManager.instance.pauseMode && !GameManager.instance.ventanaAbierta) {
			Vector2 spawn = new Vector2 (Random.Range (camaraPosX - Anchura / 2, camaraPosX - 1 + Anchura / 2), Random.Range (camaraPosY - Altura / 2 + 1, camaraPosY + Altura / 2));
			GameObject copia = Instantiate (coleccionable, spawn, Quaternion.identity);
			copia.GetComponent<TextMesh> ().text = resultado.ToString ();
			Destroy (copia, tiempo);
		}
			Invoke ("SpawnSoluciones", tiempo);
    }
    public int CalculaOperacion()
    {
        int operando1 = Random.Range(0, 9);
        int operando2 = Random.Range(0, 9);
        int operacion = Random.Range(0, 1);

        if(operacion==0)
        {
            cuenta = operando1.ToString()+ "+" +operando2.ToString();
            return operando1 + operando2;
        }
        else
        {
            cuenta = operando1.ToString() + "+" + operando2.ToString();
            return operando1 - operando2;
        }
    }
    private void FixedUpdate()
    {
		if (!GameManager.instance.pauseMode && !GameManager.instance.ventanaAbierta) {
			tiempoPasado += Time.deltaTime;
			if (tiempoPasado >= tiempoMax) {
				CambiaOperacion ();
			}
		}    
    }

	void ActualizaOperacion(){
		hechas.text = GameManager.instance.matematicasScore.ToString() + "/" + operacionesHechas.ToString();
	}
	void CompruebaOperacion(){
		if (operacionesHechas == 10)
		{
			GameManager.instance.FinExamenMatematicas();
		}
	}
}
