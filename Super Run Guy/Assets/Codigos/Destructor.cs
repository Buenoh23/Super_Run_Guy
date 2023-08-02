using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
    [SerializeField] float velocidad = 10f; //Se declara la variable de velocidad

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }

    [SerializeField] void Movimiento()
    {
        transform.position += transform.right * Time.deltaTime * velocidad;
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        Destroy(collision.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
