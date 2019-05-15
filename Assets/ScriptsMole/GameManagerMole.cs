using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerMole : MonoBehaviour
{
    //timer
    int playTime=60;
    int segs, mins;

    static int curlevel = 1;
    int baseScore = 25;
    int scoreMeta;
    // Start is called before the first frame update
    void Start()
    {
        scoreMeta = curlevel * baseScore;
        ScoreManagerMole.scoreMeta = scoreMeta;
        UIManagerMole.instance.UpdateUI(0, scoreMeta);
        UIManagerMole.instance.UpdateLevel(curlevel);
        StartCoroutine("Timer");
        
    }
    IEnumerator Timer() {
        while (playTime>0) {
            yield return new WaitForSeconds(1);
            playTime--;
            segs = playTime % 60;
            mins = playTime / 60%60;
            //update UI
            UIManagerMole.instance.UpdateTime(mins, segs);
        }
        Debug.Log("Timer has ended");
        CheckForWin();
        //Win

        //lose
    }
    void CheckForWin() {
        if (ScoreManagerMole.ReadScore() >= scoreMeta)
        {
            Debug.Log("you won");
            curlevel++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        else {
            //lose
            Debug.Log("Loser");
        }
    }
}
