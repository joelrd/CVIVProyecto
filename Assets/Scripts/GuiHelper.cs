using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuiHelper : MonoBehaviour
{
    public void IniciarPartida()
    {
        SceneManager.LoadScene("08-EscenarioJuego-01-Bosque-A");
    }
    public void VolverMenuPrincipal()
    {
        SceneManager.LoadScene("portada");
    }
    public void CerrarAplicacion()
    {
        Application.Quit();
    }
}
