using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitGame : MonoBehaviour
{

    public float spaceshipSpeed;
    public float spaceshipMoveSpeed = 30f;
    public float score;
    public bool alive;
    public float obstacleDistance = 30f;
    int vidas;


    [SerializeField] Slider enrgySlider;
    [SerializeField] Text speedText;
    [SerializeField] Slider volumeSlider;
    [SerializeField] GameObject GameOverCanvas;
    [SerializeField] Button ButtonRetry;

    AudioSource musicVolume;

    void Start()
    {
        obstacleDistance = 30f;
        spaceshipSpeed = 20f;
        alive = true;
        enrgySlider.value = 100f;

        GameOverCanvas.SetActive(false);

        musicVolume = GameObject.Find("Canvas").GetComponent<AudioSource>();

        volumeSlider.value = GameManager.musicVolume;

        if (GameManager.vidas == 0)
        {
            GameManager.vidas = 3;
        }
        vidas = GameManager.vidas;

    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            spaceshipSpeed += 0.001f;
        }

        float veloc = (spaceshipSpeed * 3600) / 1000;
    }
    public void Chocar(GameObject other)

    {
        print(other.tag);
        if (other.tag == "obstaculo")
        {
            enrgySlider.value -= 20;
        }

        ConfigVars.numLives--;
        if (enrgySlider.value <= 0)
        {
            Morir();
        }
        else
        {
            Destroy(other);
        }


    }

    void Morir()
    {
        if (score > GameManager.HighScore)
        {
            GameManager.HighScore = score;

        }
        spaceshipSpeed = 0f;
        alive = false;
        GameObject.Find("NavePadre").SetActive(false);
        Invoke("MostrarGameOver", 2f);
    }

    public void SetVolume()
    {

        musicVolume.volume = volumeSlider.value;
    }

    void MostrarGameOver()
    {
        GameOverCanvas.SetActive(true);
        ButtonRetry.Select();
    }
}
