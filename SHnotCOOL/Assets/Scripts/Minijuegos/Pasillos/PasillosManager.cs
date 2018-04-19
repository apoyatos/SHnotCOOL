﻿using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Gestor del juego (singleton simplificado). Controlará el estado del juego
/// y tendrá métodos llamados desde los distintos objetos que lo hacen avanzar.
/// Debe haber una única instancia. 
/// </summary>
public class PasillosManager : MonoBehaviour
{

    // Creamos una variable estática para almacenar la instancia única
    public static PasillosManager instance = null;

    // Añadimos las variables necesarias para almacenar información
    int tiempo=5, vidas = 5;

    //Ancho y altura del juego
    int ancho = 17, altura = 10;
    public string level;

    // En cuanto el objeto se active
    void Awake()
    {
        // Si no hay ningún objeto GameManager ya creado
        if (instance == null)
        {
            // Almacenamos la instancia actual
            instance = this;
            // Nos aseguramos de no destruir el objeto, es decir, 
            // de que persista, si cambiamos de escena
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // Si ya existe un objeto GameManager, no necesitamos uno nuevo
            Destroy(this.gameObject);
        }
    }

    // A partir de aquí añadiríamos los métodos que necesitemos implementar
    // para conseguir las funcionalidades que pretendamos incluir. 

    // Método que devuelve true si la posición queda fuera de los límites del juego
    public bool IsOutOfBounds(Vector2 position)
    {
        return (position.x < -9 || position.x >= ancho || position.y < 0 || position.y > altura);
    }

    // Carga la escena principal (level) cuando se pulsa el botón en el menú
    public void Game()
    {
        SceneManager.LoadScene(level);
    }


    // Devuelve el valor de vidas
    public int Frogs()
    {
        return vidas;
    }

	public int TiempoRestante()
	{
		if (tiempo < 0) {
			vidas = 5;
			tiempo = 100;
			Game ();
		}
		return tiempo;
	}

	public void RestarTiempo()
	{tiempo--;
	}
	public void Home ()
	{
		Game ();
	}



    // Si quedan vidas: Actualiza el valor de vidas y llama a Game
    // Si no: Reinicializa las variables y llama a Menu
    public void PlayerDead()
    {
        if (vidas > 0)
        {
            vidas--;
            Game();
        }
        else
        {
            vidas = 5;

        }
    }
}