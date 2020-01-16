using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CambiarEscenaAlContacto : MonoBehaviour
{
    public string SiguienteEscena;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.ChangeScenes(SiguienteEscena);
        }
    }
}