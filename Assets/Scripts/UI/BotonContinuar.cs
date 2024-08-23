using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class BotonContinuar : MonoBehaviour
{
    public GameObject menuPausaUI; 
    public void Continuar()
    {
        // Desactiva el menú de pausa
        menuPausaUI.SetActive(false);

        // Reanuda el juego
        Time.timeScale = 1f;
    }
}

