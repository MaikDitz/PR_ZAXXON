using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveMove : MonoBehaviour
{
    //Variables para el movimiento
    [SerializeField] float desplSpeed;
    [SerializeField] float rotationSpeed;
    InitGame initGame;
    [SerializeField] GameObject bala;
    [SerializeField] Transform cannon;
    [SerializeField] AudioClip disparo;
    AudioSource audiosource;

    //Variables para restricción de movimiento
    float limiteH = 10f; //Solo creo una porque por la izquierda es la misma pero en negativo
    float limiteV = 10f;
    float limiteSuelo = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        //Asigno el valor a las variables de movimiento
        desplSpeed = 20f;
        rotationSpeed = 100f; //La de rotación es alta porque la rotación es muy lenta
        initGame = GameObject.Find("InitGame").GetComponent<InitGame>();
        audiosource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (initGame.alive)
        {
            MoverNarve();
        }

        Disparar();

    }


    //Método que mueve la nave
    void MoverNarve()
    {
        
        float desplX = Input.GetAxis("Horizontal");
        float desplY = Input.GetAxis("Vertical");
        float desplR = Input.GetAxis("Rotation"); //Este lo he creado en Input Manager

        float posX = transform.position.x;
        float posY = transform.position.y;


        if ((posX < limiteH || desplX < 0f) && (posX > -limiteH || desplX > 0f))
        {
            transform.Translate(Vector3.right * Time.deltaTime * desplSpeed * desplX, Space.World);
        }

        if ((posY < limiteV || desplY < 0f) && (posY > limiteSuelo || desplY > 0f))
        {
            transform.Translate(Vector3.up * Time.deltaTime * desplSpeed * desplY, Space.World);
        }

        //Rotación con joystick derecho
        transform.Rotate(0f, 0f, desplR * Time.deltaTime * -rotationSpeed);

 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstaculo")
        {

            initGame.SendMessage("Me he chocado", other.gameObject);
        }
    }
    void Disparar()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            print("Disparando");
            Instantiate(bala, cannon);
            audiosource.PlayOneShot(disparo, 2f);
        }
    }
}
