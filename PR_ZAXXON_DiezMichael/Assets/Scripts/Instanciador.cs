using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{
    //Pendiente: cambiar el intervalo en base a la velocidad
    float intervalo;
    [SerializeField] float distance;
    //Variables para instanciar columnas iniciales
    [SerializeField] float posZcolumna1;

    //Creo un ARRAY (por eso los corchetes) para los obstáculos
    //En Unity, daré al nº de elementos del array y sus prefabs
    [SerializeField] GameObject[] obstaculos;

    //Posición donde se instanciarán los obstáculos
    [SerializeField] Transform instantiatePos;
    //Límites de posición para los obstáculos
    float limiteL = -10f;
    float limiteR = 10f;

    //Acceder al script con las variables generales
    InitGame initGame;

    // Start is called before the first frame update
    void Start()
    {
        //intervalo = 1f;

        posZcolumna1 = 150f;
        initGame = GameObject.Find("InitGame").GetComponent<InitGame>();
        //Inicio la corrutina que crea los obstáculos
        StartCoroutine("CrearColumna");

        //Método nuevo para crear columnas iniciales
        CrearColumnasIniciales();


    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CrearColumna()
    {
        float speed;
        distance = initGame.obstacleDistance;
        while (true)
        {

            speed = initGame.spaceshipSpeed;
            intervalo = distance / speed;
            //print(intervalo);


            //Genero un nº aleatorio para elegir obstaculo
            int numAl = Random.Range(0, obstaculos.Length);

            float randomX;
            //Posición Random en X
            if (obstaculos[numAl].tag != "Obstaculo")
            {
                randomX = Random.Range(limiteL, limiteR);
            }
            else
            {
                randomX = 0f;
            }

            //Posición de instanciación, según el valor Random en X
            Vector3 newPos = new Vector3(randomX, instantiatePos.position.y, instantiatePos.position.z);


            //Instancio el elemento del Array aleatorio
            Instantiate(obstaculos[numAl], newPos, Quaternion.identity);

            /*
            //Este código es una forma de instanciar diferentes prefabs modo DUMMIE
            if(numAl == 0)
            {
                //Instantiate(columna, newPos, Quaternion.identity);
            }
            else
            {
                //Instantiate(pared, newPos, Quaternion.identity);
            }
            */

            //Repito el intervalo de la corrutina
            yield return new WaitForSeconds(intervalo);
        }
    }

    void CrearColumnasIniciales()
    {

        float posZ = instantiatePos.position.z;
        float columnasIniciales = (posZ - posZcolumna1) / distance;

        columnasIniciales = Mathf.Round(columnasIniciales);
        print(columnasIniciales);

        for (float n = posZcolumna1; n < posZ; n += distance)
        {
            float randomX = Random.Range(limiteL, limiteR);

            Vector3 columnaInicialPos = new Vector3(randomX, instantiatePos.position.y, n);
            Instantiate(obstaculos[0], columnaInicialPos, Quaternion.identity);
        }
    }
}
