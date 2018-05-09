﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour {

	public string entranceName;
	public Entrance entranceConnection;
	[Header("Introduce el nombre de la escena del examen")]
	public string examSceneName;
	EntranceManager em;
	[Header("Marcar si el una salida")]
	public bool isExit;

	void Awake(){
		em = GetComponentInParent<EntranceManager>();
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player" && !GameManager.instance.thereIsAnInteractiveEvent) {
			MuestraMensaje ();
			em.entrance = this;
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Player") {
			GameManager.instance.thereIsAnInteractiveEvent = false;
			MessageManager.instance.CloseMessage ();
			em.entrance = null;
		}
	}

	void MuestraMensaje(){
		GameManager.instance.thereIsAnInteractiveEvent = true;
		if (!isExit)
			MessageManager.instance.ShowMessage("Pulsa " + GameManager.instance.botonInteractuar.ToString () + " para acceder al\n" + entranceName);
		else
			MessageManager.instance.ShowMessage("Pulsa " + GameManager.instance.botonInteractuar.ToString () + " para salir de\n" + GameManager.instance.lastEntrance.entranceName);
		
	}

	public void MoveToConnection(GameObject character){
		if (isExit) 
			character.transform.position = GameManager.instance.lastEntrance.gameObject.transform.position;
		else
			character.transform.position = entranceConnection.gameObject.transform.position; 
		ChooseExam ();
		GameManager.instance.lastEntrance = this;
		GameManager.instance.lastPosEntrance = this.gameObject.transform.position;
	}

	void ChooseExam(){
		if (examSceneName == "Matematicas" && !GameManager.instance.finMates)
			GameManager.instance.Examen = 0;
		else if (examSceneName == "Historia" && !GameManager.instance.finHistoria)
			GameManager.instance.Examen = 1;
		else if (examSceneName == "Lengua" && !GameManager.instance.finLengua)
			GameManager.instance.Examen = 2;
		else if (examSceneName == "Geografia" && !GameManager.instance.finGeo)
			GameManager.instance.Examen = 3;
		else
			GameManager.instance.Examen = 4;	
	}

}