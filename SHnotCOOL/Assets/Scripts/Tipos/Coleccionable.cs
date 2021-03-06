using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class Coleccionable : MonoBehaviour {

	public string currentScene;
	public string NombreColeccionable;
	public Sprite imagenRepresentacion;
	[HideInInspector]
	public bool isTaken;
	bool usado=false;
	HUDManager im;

	void Awake(){
		this.gameObject.SetActive (true);
		im = FindObjectOfType<HUDManager> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag =="Player"&& !GameManager.instance.thereIsAnInteractiveEvent ){
			//Da referencia del objeto en el InventoryManager
			im.objeto = this;	
			GameManager.instance.thereIsAnInteractiveEvent = true;
		}	
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			im.objeto = null;
			GameManager.instance.thereIsAnInteractiveEvent = false;
			MessageManager.instance.CloseMessage ();
		}
	}

	public void ActualizaObjeto(){
		if (SceneManager.GetActiveScene ().name == currentScene&&!usado&& !isTaken)
			this.gameObject.SetActive (true);
		else
			this.gameObject.SetActive (false);
	}
	public void ObjetoUsado()
	{
		usado = true;
	}
}
