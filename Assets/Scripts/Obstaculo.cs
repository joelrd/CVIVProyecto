using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Declaramos una enumeración
public enum Movimiento
{
    Derecha,
    Izquierda, 
    Adelante,
    Atras,
    Up, 
    Down
}

public class Obstaculo : MonoBehaviour
{
    // Miembros de clase pública.
    public Movimiento direccion;
    public float distancia = 5;
    public float velocidad = 1;
    public Transform destino;

    // Miembros de clase protegidos
    protected Vector3 posicionInicial;

    // Método que se ejecuta cuando aparece este objeto en pantalla
    void Start()
    {
        // Guardamos la posición inicial
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculamos la nueva posicion
        switch (direccion)
        {
            case Movimiento.Derecha:
                // Dibujamos una linea por donde el objeto hará un recorrido.
                Debug.DrawLine(posicionInicial, posicionInicial + (Vector3.right * distancia), Color.magenta);

                // Usamos la función Ping Pong
                transform.position = new Vector3(posicionInicial.x + Mathf.PingPong(Time.time * velocidad, distancia), // X (Calculamos)
                                                 transform.position.y, // Y
                                                 transform.position.z); // Z
                break;

            case Movimiento.Izquierda:
                // Dibujamos una linea por donde el objeto hará un recorrido.
                Debug.DrawLine(posicionInicial, posicionInicial + (Vector3.left * distancia), Color.magenta);

                // Usamos la función Ping Pong
                transform.position = new Vector3(posicionInicial.x - Mathf.PingPong(Time.time * velocidad, distancia), // X
                                                 transform.position.y, // Y
                                                 transform.position.z); // Z
                break;

            case Movimiento.Adelante:
                // Dibujamos una linea por donde el objeto hará un recorrido.
                Debug.DrawLine(posicionInicial, posicionInicial + (Vector3.forward * distancia), Color.magenta);

                // Usamos la función Ping Pong
                transform.position = new Vector3(transform.position.x, 
                                                 transform.position.y, 
                                                 posicionInicial.z + Mathf.PingPong(Time.time * velocidad, distancia));
                break;

            case Movimiento.Atras:
                // Dibujamos una linea por donde el objeto hará un recorrido.
                Debug.DrawLine(posicionInicial, posicionInicial + (Vector3.back * distancia), Color.magenta);

                // Usamos la función Ping Pong
                transform.position = new Vector3(transform.position.x, // X
                                                 transform.position.y, // Y
                                                 posicionInicial.z - Mathf.PingPong(Time.time * velocidad, distancia)); // Z
                break;

            case Movimiento.Up:
                // Dibujamos una linea por donde el objeto hará un recorrido.
                Debug.DrawLine(posicionInicial, posicionInicial + (Vector3.up * distancia), Color.magenta);

                // Usamos la función Ping Pong
                transform.position = new Vector3(transform.position.x, // X
                                                 posicionInicial.y + Mathf.PingPong(Time.time * velocidad, distancia), // Y
                                                 transform.position.z); // Z
                break;

            case Movimiento.Down:
                // Dibujamos una linea por donde el objeto hará un recorrido.
                Debug.DrawLine(posicionInicial, posicionInicial + (Vector3.down * distancia), Color.magenta);

                // Usamos la función Ping Pong
                transform.position = new Vector3(transform.position.x, // X
                                                 posicionInicial.y - Mathf.PingPong(Time.time * velocidad, distancia), // Y
                                                 transform.position.z); // Z
                break;
        }
    }

    // Método que se ejecuta cuando este objeto interseca otro objeto en el juego.
    private void OnTriggerEnter(Collider other)
    {
        // Consultamos si el objeto que interseca tiene la etiqueta del jugador.
        if (other.CompareTag("Player"))
        {
            other.transform.position = destino.transform.position;

            PlayerData playerdata = other.GetComponent<PlayerData>();
            // con playerdata referenciado al jugador podemos hacer cosas como quitarle una vida al personaje.
            // ejemplo: 
            // playerdata.vidas--;
        }
    }
}
