// Universidad Estatal a Distancia
// Introducción a Unity
// Autor: Lic. Juan Pablo Navarro Fennell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class PlayerData : MonoBehaviour
{
    // Miembros de clase pública.
    public Color colorActual = Color.white;

    // Miembros de clase protegidos
    protected Renderer render;

    // Método que se ejecuta cuando aparece este objeto en pantalla.
    void Start()
    {
        colorActual = Color.white;
        render = GetComponent<Renderer>();
    }

    // Rutina que se ejecuta cada vez que se dibuja una nueva imagen en pantalla.
    void Update()
    {
        render.material.color = colorActual;
    }

    // Método que cammbia el color actual del jugador.
    public void SetColor(Color nuevoColor)
    {
        colorActual = nuevoColor;
    }

    // Método que retorna el color actual de este obejto.
    public Color GetColor()
    {
        return colorActual;
    }
}
