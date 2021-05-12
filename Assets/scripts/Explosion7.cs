using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion7 : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5)
        {
            Destroy(gameObject);
        }
    }
}
