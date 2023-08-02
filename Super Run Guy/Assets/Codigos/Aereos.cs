using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aereos : MonoBehaviour
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
}
