﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shoping : MonoBehaviour {
	[SerializeField]
	ObjetoEnVenta [] objetos_en_venta;
	public CanvasRenderer tienda_;

	public string currentScene;
	public KeyCode botonInteraccion;
	public Button primerBoton;
	bool collisionn;
	// Use this for initialization
	void Start () {
		tienda_.gameObject.SetActive (false);

	}
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Player") {
			MessageManager.instance.ShowMessage ("Pulsar " + botonInteraccion.ToString () + " para interactuar.");
			collisionn = true;
		}
	}
	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			collisionn = false;
			MessageManager.instance.CloseMessage ();
		}
	}
	void CheckInputDialogue(){
		if (Input.GetKeyDown (botonInteraccion) && collisionn) {
			tienda_.gameObject.SetActive (true);
			if (primerBoton.interactable)
				primerBoton.Select ();
			else
				primerBoton.FindSelectableOnDown ().Select ();
			MessageManager.instance.CloseMessage ();
			GameManager.instance.ventanaAbierta = true;
		} else if(!collisionn)
			tienda_.gameObject.SetActive (false);
	}
	// Update is called once per frame
	void Update () {
		CheckInputDialogue ();
	}
	public void Exit(){
		tienda_.gameObject.SetActive (false);
		GameManager.instance.ventanaAbierta = false;
	}
	public void ActualizaPersonaje (){
		if (SceneManager.GetActiveScene ().name == currentScene)
			this.gameObject.SetActive (true);
		else
			this.gameObject.SetActive (false);
	}
}
