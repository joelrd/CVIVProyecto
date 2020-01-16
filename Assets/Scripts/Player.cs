// Universidad Estatal a Distancia
// Introducción a Unity
// Autor: Lic. Juan Pablo Navarro Fennell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{
    // Miembros de clase pública
    public float velocidadDesplamiento = 5;
    public float velocidadSalto = 5;
    public float distanciaRayo = 1.1f;
    public bool enElPiso;

    // Miembros de clase protegidos
    protected Rigidbody cuerpoRigido;
    protected float velocodadX;
    protected float velocodadY;
    protected float velocodadZ;
    protected RaycastHit hit;

    // Método que se ejecuta cuando aparece este objeto en pantalla
    void Start()
    {
        // Se obtiene la referencia al componente
        cuerpoRigido = GetComponent<Rigidbody>();
    }

    // Rutina que se ejecuta cada vez que se dibuja una nueva imagen en pantalla.
    void Update()
    {
        // Lectura de teclado
        velocodadX = Input.GetAxisRaw("Horizontal") * velocidadDesplamiento;
        velocodadZ = Input.GetAxisRaw("Vertical") * velocidadDesplamiento;

        // Tecla de salto
        if (enElPiso && Input.GetKeyDown(KeyCode.Space))
        {
            Sound_Handler.instance.playsound((int)SoundType.salto);
            velocodadY = velocidadSalto;
        }
        else
        {
            velocodadY = cuerpoRigido.velocity.y;
        }

        // Se aplica la velocidad
        cuerpoRigido.velocity = new Vector3(velocodadX, velocodadY, velocodadZ);
    }

    // rutina que se ejecuta después de que todos los calculos físicos han sido completados.
    private void FixedUpdate()
    {
        TocaPiso();
    }

    // Metodo privado que 
    private void TocaPiso()
    {
        // Se dibuja una linea para poder visualizarla en el Unity Editor.
        Debug.DrawLine(
            this.transform.position, 
            this.transform.position + (Vector3.down * distanciaRayo),
            Color.white);

        // Lanzamos un rayo, si este impacta alguna superficie, el valor de "enElPiso" será verdadero
        // de lo contrario será falso.
        enElPiso = Physics.Raycast(transform.position, -Vector3.up, distanciaRayo);
    }
}
