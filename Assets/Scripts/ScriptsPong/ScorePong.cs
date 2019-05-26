using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScorePong : MonoBehaviour
{
    public Text izqScore;
    public Text derScore;
    public int puntosLeft;
    public int puntosRight;
    private bool isPause = false;

    // Start is called before the first frame update
    void Start()
    {
        puntosLeft = 0;
        puntosRight = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause) Continue();
            else PauseGame();
        }

    }
     
    public void ganoRight()
    {
        puntosRight += 1;
        derScore.text = puntosRight.ToString();
    }

    public void ganoLeft()
    {
        puntosLeft += 1;
        izqScore.text = puntosLeft.ToString();
    }

    public void PauseGame()
    {
        //Se muestra el panel de pausa
        transform.Find("PausePanel").gameObject.SetActive(true);
        //Se pausan todos los objetos de la escena
        Time.timeScale = 0.0f;
        isPause = true;
    }

    public void Continue()
    {
        //Se quita el menu de pause
        transform.Find("PausePanel").gameObject.SetActive(false);
        //Se vuelven a mover todos los objetos
        Time.timeScale = 1.0f;
        isPause = false;
    }

    public void ExitGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }

    public void ReplayGame(string sceneName)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sceneName);

    }

}
