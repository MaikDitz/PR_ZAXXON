using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{
    float intervalo;
    [SerializeField] GameObject columna;
    [SerializeField] Transform instantiatePos;

    // Start is called before the first frame update
    void Start()
    {
        intervalo = 0.1f;

        StartCoroutine("CrearColumna");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CrearColumna()
    {
        while (true)
        {
 
            float randomX = Random.Range(-10f, 10f);
            Vector3 newPos = new Vector3(randomX, instantiatePos.position.y, instantiatePos.position.z);
            Instantiate(columna, newPos, Quaternion.identity);

            yield return new WaitForSeconds(intervalo);
        }
    }
}
