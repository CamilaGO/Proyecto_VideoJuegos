using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPause = false;
    public Text mText;
    public string scenename = "SampleScene";
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause) cont();
            else Pause();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene(scenename);
        }
    }
    public void Pause()
    {
        transform.Find("PauseMenu").gameObject.SetActive(true);
        Time.timeScale = 0.0f;
        isPause = true;
        //return true;
    }
    public void cont()
    {
        transform.Find("PauseMenu").gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        isPause = false;
        //return false;
    }
    public void loser() {
       
        transform.Find("PauseMenu").gameObject.SetActive(true);
        mText = GameObject.Find("modo").GetComponent<Text>();
        mText.text = "LOSER";
        //Time.timeScale = 0.0f;
    }
}
