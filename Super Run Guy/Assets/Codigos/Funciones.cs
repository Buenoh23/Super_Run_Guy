using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Funciones : MonoBehaviour
{
    [SerializeField] AudioSource audioBoton; //Se declara el objeto para reproducir audio al presionar un boton

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambioEscena(string Nombre)
    {
        audioBoton.Play();
        StartCoroutine (Esperar(Nombre));
    }

    public void Salir()
    {
        audioBoton.Play();
        StartCoroutine (Escape());
    }

    private IEnumerator Esperar(string Nombre)
    {
        yield return new WaitForSeconds (0.3f);
        SceneManager.LoadScene(Nombre);
    }

    private IEnumerator Escape()
    {
        yield return new WaitForSeconds (0.3f);
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
