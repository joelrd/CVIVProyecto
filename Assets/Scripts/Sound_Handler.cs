﻿// Universidad Estatal a Distancia
// Introducción a Unity
// Autor: Lic. Juan Pablo Navarro Fennell
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum SoundType
{
    none = -1,
    cambiarEscena = 0,
    utilizarLlave = 1,
    salto = 2,
};
// Declaración de la clase
public class Sound_Handler : MonoBehaviour {
    public static Sound_Handler instance;
    public AudioSource speaker1;
    public AudioSource speaker2;
    public AudioSource speaker3;
    // Arreglo de archivos de audio
    public AudioClip[] sounds;
    // Inicialización del objeto singleton
    void Awake () {
        if(instance != null && instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Método público para reproducir sonido
    public void playsound(int indexOfSound) {
        if(!speaker1.isPlaying) {
            speaker1.PlayOneShot(sounds[indexOfSound]);
        }
        else if(!speaker2.isPlaying) {
            speaker2.PlayOneShot(sounds[indexOfSound]);
        }
        else if(!speaker3.isPlaying) {
            speaker3.PlayOneShot(sounds[indexOfSound]);
        }
    }
}