using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CambiarEscenaAlContacto : MonoBehaviour
{
    public string SiguienteEscena;
    
    public string doorId;
    
    public Player objetoPlayer;
    
    public Transform posicionObjetivo;
    
    private void Start()
    {
        if(GameManager.instance.GetDoor() == doorId)
        {
            objetoPlayer.transform.position = posicionObjetivo.position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.SetDoor(doorId);
            GameManager.instance.ChangeScenes(SiguienteEscena);
        }
    }
} 