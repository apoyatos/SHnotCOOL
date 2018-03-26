using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class Coleccionable : MonoBehaviour {

	public string NombreColeccionable;
	public Sprite imagenRepresentacion;
	HUDManager im;

	void Start(){
		im = FindObjectOfType<HUDManager> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag =="Player")
			//Da referencia del objeto en el InventoryManager
			im.objeto = this;		
	}
	void OnTriggerExit2D(Collider2D other){
		if(other.tag=="Player")
			im.objeto = null;
	}
}
