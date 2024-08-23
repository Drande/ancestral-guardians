using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostrarPanel : MonoBehaviour
{
    public GameObject panelA;
    public GameObject panelB;

    // Este método se llama cuando se hace clic en el botón
    public void MostrarOtroPanel()
    {
        // Desactiva el panel actual
        panelA.SetActive(false);
        // Activa el otro panel
        panelB.SetActive(true);
    }
}

