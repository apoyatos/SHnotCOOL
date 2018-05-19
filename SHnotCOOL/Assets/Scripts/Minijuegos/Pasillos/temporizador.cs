﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class temporizador : MonoBehaviour {
	Text temporiza;
	int temporizadorapoyo,temp;
	// Use this for initialization
	void Start () {
		temporizadorapoyo = 5;
		temporiza = GetComponent<Text> ();

		temporiza.text=PasillosManager.instance.TiempoRestante().ToString() +"S";
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameManager.instance.pauseMode && !GameManager.instance.ventanaAbierta) {
			temp = (int)Time.time;
			if (temp > temporizadorapoyo) {
				temporizadorapoyo = temp;
				PasillosManager.instance.RestarTiempo ();
				temporiza.text = PasillosManager.instance.TiempoRestante ().ToString () + "S";
			}
		}
	}
}
