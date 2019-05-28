using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleBehavior : MonoBehaviour
{
    public GameObject[] moles;
    public bool hasMole;
    // Start is called before the first frame update
    void Start()
    {
        if (!hasMole) {
            Invoke("Spawn", Random.Range(3f, 7f));

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn() {
        if (!hasMole) {
            //int num = Random.Range(0, moles.Length);
            int num = rarity();
            GameObject mole = Instantiate(moles[num], transform.position, Quaternion.identity) as GameObject;

            mole.GetComponent<MoleBehav>().myPar = this.gameObject;
            hasMole = true;
        }
        
        Invoke("Spawn", Random.Range(3f, 7f));
    }
    int rarity() {
        int num = Random.Range(1, 101);

        if (num <= 5)
        {
            return 4;
        }
        else {
            return Random.Range(0, moles.Length-1);
        }
        return 0;
    }
}
