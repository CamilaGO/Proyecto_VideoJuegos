using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerMole : MonoBehaviour
{
    static int score;
    public static int scoreMeta;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: "+ score);
        UIManagerMole.instance.UpdateUI(score, scoreMeta);
    }
    public static int ReadScore() {
        return score;
    }
}
