using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorTerrenos : MonoBehaviour
{
    [SerializeField] GameObject terrenoPrefab;
    Transform initPos;
    // Start is called before the first frame update
    void Start()
    {
        initPos = gameObject.transform;
        CrearTerreno();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CrearTerreno()
    {
        Instantiate(terrenoPrefab, initPos);
    }
}
