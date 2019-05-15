using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.tag == "Mole") {
                    MoleBehav mole = hit.collider.gameObject.GetComponent<MoleBehav>();
                    mole.SwitchCollider(0);
                    mole.anim.SetTrigger("hitM");
                    //Debug.Log(hit.collider.gameObject + "got hit");
                }
                
            }
        }
    }
}
