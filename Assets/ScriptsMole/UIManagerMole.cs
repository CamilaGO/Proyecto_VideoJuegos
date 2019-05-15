using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerMole : MonoBehaviour
{
    public static UIManagerMole instance;
    public Text scoreText;
    public Text timeText;
    public Text levelText;

    private void Awake()
    {
        instance = this;
        //UpdateUI();
        UpdateTime(1, 0);
    }
    //public Text scoreText;
    public void UpdateUI(int score, int scoreMeta) {
        scoreText.text = "Score: " + score+"/"+scoreMeta;
    }

    public void UpdateTime(int mins, int segs) {
        timeText.text = mins.ToString("D2") + ":" + segs.ToString("D2");
    }
    public void UpdateLevel(int n) {
        levelText.text = "Level: " + n.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
