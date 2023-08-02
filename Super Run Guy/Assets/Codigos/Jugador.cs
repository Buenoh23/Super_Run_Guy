using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    [SerializeField] GameObject jugador; //Se declara el objeto del jugador
    
    [SerializeField] float velocidad = 10f; //Se declara la variable de velocidad
    [SerializeField] float fuerzaSalto = 5f; //Se declara la variable de salto
    float incrementoVelocidad = 0.0001f; //Se establece el incremento de la velocidad
    bool enElPiso = true; //Detecta si el jugador está tocando el piso o no

    [SerializeField] Animator animator; //Se declara el objeto para manipular las animaciones

    [SerializeField] AudioSource audioSalto; //Se declara el objeto para reproducir audio del salto
    [SerializeField] AudioSource audioEnemigo; //Se declara el objeto para reproducir audio al tocar un enemigo
    [SerializeField] AudioSource audioMoneda; //Se declara el objeto para reproducir audio al recolectar una moneda

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        Saltar();
        animator.SetBool("Correr", true);
    }

    [SerializeField] void Movimiento()
    {
        velocidad += incrementoVelocidad;
        transform.position += transform.right * Time.deltaTime * velocidad;
    }

    //Detecta cuando se presiona la tecla espacio para saltar
    void Saltar()
    {
        if(Input.GetKeyDown(KeyCode.Space) && enElPiso == true){
            Salto();
        }
    }

    //Hace que el jugador salte utilizando un vector hacia arriba
    void Salto()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        enElPiso = false;
        animator.SetTrigger("Saltoo");
        animator.SetBool("Correr", false);
        audioSalto.Play();
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        //Si el personaje colisiona con el suelo, cambiamos enElPiso a true
        if(collision.gameObject.tag == "Suelo"){
            enElPiso = true;
        }
        //Si el personaje colisiona con un enemigo, el personaje se destruye
        if(collision.gameObject.tag == "Enemigo"){
            animator.SetBool("Correr", false);
            animator.SetTrigger("Idle");
            audioEnemigo.Play();
            velocidad = 0;
            incrementoVelocidad = 0;
            StartCoroutine (Esperar());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Recolectable"){
            audioMoneda.Play();
        }
    }

    private IEnumerator Esperar()
    {
        yield return new WaitForSeconds (1f);
        Destroy(gameObject);
        SceneManager.LoadScene("Game Over");
    }
}
