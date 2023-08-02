using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    [SerializeField] private GameObject[] matriz; //La prefab del objeto que se quiere generar aleatoriamente
    [SerializeField] private float posY = -2.25f;
    [SerializeField] private float posZ = -0f;
    [SerializeField] private float interval = 6; //El intervalo de tiempo entre generaciones de objetos (en segundos)
    private float elapsedTime; //La variable para almacenar el tiempo transcurrido desde la última generación de objetos


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GenerarObjetoAleatorio();
    }

    //Función para generar un objeto aleatorio
    private void GenerarObjetoAleatorio()
    {   
        //Aumenta el tiempo transcurrido en cada frame
        elapsedTime += Time.deltaTime;
        
        int longitudMatriz = matriz.Length;

        //Si ha pasado el tiempo suficiente desde la última generación de objetos
        if(elapsedTime >= interval){
            //Asigna la posición en el eje Y del objeto vacío
            transform.position = new Vector3(transform.position.x, posY, posZ);
            //Genera un número aleatorio entre el 0 y la longitud de la matriz
            int indiceAleatorio = Random.Range(0, longitudMatriz);
            //Crea una instancia del objeto a partir de la prefab en la posición del objeto vacío
            Instantiate(matriz[indiceAleatorio], transform.position, Quaternion.identity);
            //Resetea el tiempo transcurrido a cero
            elapsedTime = 0;
        }
    }
}
