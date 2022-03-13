
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{

    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
    public void IniciarJuego()
    {
        SceneManager.LoadScene(1);
    }
    public void Salir()
    {

        Application.Quit();
    }

}