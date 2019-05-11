using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControllerMario : MonoBehaviour
{
    
    public AudioClip salto;
    public AudioClip powerUp;
    public AudioClip morir;
    public AudioClip win;
    public AudioSource audioS;
    public bool saltar;
    public bool mejorar;
    public bool fin;
    public bool gano;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (saltar == true)
        {
            saltar = false;
            audioS.clip = salto;
            audioS.Play();
        }

        if (mejorar == true)
        {
            mejorar = false;
            audioS.clip = powerUp;
            audioS.Play();
        }

        if (fin == true)
        {
            fin = false;
            audioS.clip = morir;
            audioS.Play();
        }

        if (gano == true)
        {
            gano = false;
            audioS.clip = win;
            audioS.Play();
        }
    }
}
