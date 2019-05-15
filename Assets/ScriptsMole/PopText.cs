using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopText : MonoBehaviour
{
    public Text popupText;
    Animator anim;
    public Text Go;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();

        AnimatorClipInfo[] info = anim.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, info[0].clip.length);
    }

    public void Show(int n) {
        popupText.text = (n > 0) ? "+" + n : n.ToString();
    }
}
