using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleBehav : MonoBehaviour
{
    Collider col;
    public int hitPoints = 1;
    public int score=1;
    [HideInInspector] public GameObject myPar;
    public GameObject popupText;
    [HideInInspector]public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider>();
       
        col.enabled = false;
    }

    public void DestroyObj() {
        myPar.GetComponent<HoleBehavior>().hasMole = false;
        Destroy(gameObject);

    }

    public void SwitchCollider(int num)
    {
        col.enabled = (num == 0) ? false : true;
    }
    //for hits  and points
    public void GotHit()
    {
        hitPoints--;
        if (hitPoints > 0)
        {
            col.enabled = true;
        }
        else {
            myPar.GetComponent<HoleBehavior>().hasMole = false;
            ScoreManagerMole.AddScore(score);
            GameObject pop = Instantiate(popupText) as GameObject;

            pop.transform.SetParent(UIManagerMole.instance.transform, false);

            pop.transform.position = Camera.main.WorldToScreenPoint(transform.position);
            PopText popText = pop.GetComponent<PopText>();

            popText.Show(score);

            Destroy(gameObject);
        }
        //put in points HERE
        

    }

}
