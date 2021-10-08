using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebasInstatiate : MonoBehaviour
{
    //Variable GameObject a la que arrastraremos el prefab
    [SerializeField] GameObject cuboPrefab;
    //Variable Transform con el objeto de referencia para instanciar
    [SerializeField] Transform initPos;

    //Variable que indicará cuánto se moverá en X cada objeto instanciado
    float desplX = 1.1f;


    // Start is called before the first frame update
    void Start()
    {
        //Creo un Vector 3 que marcará dónde se instancia cada prefab en cada vuelta
        //Está fuera del bucle para que al inicio solo coja la posición del Empty Object
        Vector3 destPos = initPos.position;
        //Creo un Vector3 que sumaré al anterior, desplazándolo en X (lo que digamos en la variable)
        Vector3 despl = new Vector3(desplX, 0, 0);

        //Bucle que crea 10 instancias del prefab, cada una en una posición distinta
        for(int n = 0; n < 10; n++)
        {
            
            Instantiate(cuboPrefab, destPos, Quaternion.identity);
            //Para la siguiente vuelta del bucle, le cambio la posición de instancia
            destPos = destPos + despl;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
