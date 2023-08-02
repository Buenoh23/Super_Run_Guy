using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Botones_Textos : MonoBehaviour
{
    [SerializeField] Text puntaje; 

    [SerializeField] GameObject moneda;
    int monedas = 0;
    [SerializeField] Text cantidadMonedas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        puntaje.text = "Puntaje : " + Mathf.Floor(transform.position.x + 8);
        cantidadMonedas.text = "Monedas : " + monedas;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Recolectable"){
            monedas++;
            Destroy(collision.gameObject);
        }
    }
}
