using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebasInstatiate : MonoBehaviour
{
    //Variable GameObject a la que arrastraremos el prefab
    [SerializeField] GameObject cuboPrefab;
    //Variable Transform con el objeto de referencia para instanciar
    [SerializeField] Transform initPos;

    //Variable que indicar� cu�nto se mover� en X cada objeto instanciado
    float desplX = 1.1f;


    // Start is called before the first frame update
    void Start()
    {
        //Creo un Vector 3 que marcar� d�nde se instancia cada prefab en cada vuelta
        //Est� fuera del bucle para que al inicio solo coja la posici�n del Empty Object
        Vector3 destPos = initPos.position;
        //Creo un Vector3 que sumar� al anterior, desplaz�ndolo en X (lo que digamos en la variable)
        Vector3 despl = new Vector3(desplX, 0, 0);

        //Bucle que crea 10 instancias del prefab, cada una en una posici�n distinta
        for(int n = 0; n < 10; n++)
        {
            
            Instantiate(cuboPrefab, destPos, Quaternion.identity);
            //Para la siguiente vuelta del bucle, le cambio la posici�n de instancia
            destPos = destPos + despl;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
