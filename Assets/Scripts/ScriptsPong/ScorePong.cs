using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePong : MonoBehaviour
{
    public Text izqScore;
    public Text derScore;
    public int puntosLeft;
    public int puntosRight;

    // Start is called before the first frame update
    void Start()
    {
        puntosLeft = 0;
        puntosRight = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
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


}
