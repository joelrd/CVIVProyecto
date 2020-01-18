// Universidad Estatal a Distancia
// Introducción a Unity
// Autor: Lic. Juan Pablo Navarro Fennell
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {

    public float velocidadDesplamiento = 5;

    public float velocidadSalto = 5;

    public float distanciaRayo = 1.1f;

    public bool enElPiso;

    public Animator anim;

    protected Rigidbody cuerpoRigido;

    protected float velocodadX;

    protected float velocodadY;

    protected float velocodadZ;

    protected RaycastHit hit;
    // Método que se ejecuta cuando aparece este objeto en pantalla
    void Start() {
        // Se obtiene la referencia al componente
        cuerpoRigido = GetComponent<Rigidbody>();
    }
    void Update() {
        if (velocidadDesplamiento < 0)
            Debug.LogError("Valor negativo en desplazamiento");
        // Lectura de teclado
        velocodadX = Input.GetAxisRaw("Horizontal") * velocidadDesplamiento;
        velocodadZ = Input.GetAxisRaw("Vertical") * velocidadDesplamiento;
        if((velocodadZ + velocodadX) == 0) {
            if(anim != null) anim.SetFloat("speed", 0f);
        }
        else {
            if(anim != null) anim.SetFloat("speed", 1f);
        }
        // Tecla de salto
        if (enElPiso && Input.GetKeyDown(KeyCode.Space)) {
            velocodadY = velocidadSalto;
        }
        else {
            velocodadY = cuerpoRigido.velocity.y;
        }
        cuerpoRigido.velocity= new Vector3(velocodadX,velocodadY,velocodadZ);
    }

    private void FixedUpdate() { TocaPiso(); }

    private void TocaPiso() {
        Debug.DrawLine(
            this.transform.position,
            this.transform.position + (Vector3.down * distanciaRayo),
            Color.white);
        enElPiso = Physics.Raycast(transform.position,-Vector3.up, distanciaRayo);
    }
}
