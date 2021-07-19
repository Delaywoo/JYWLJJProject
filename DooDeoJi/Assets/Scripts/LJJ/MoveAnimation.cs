using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
    Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            Anim.SetTrigger("IdleToMove");
        }

        if (Input.GetKey(KeyCode.S))
        {
            Anim.SetTrigger("IdleToMove");
        }

        if (Input.GetKey(KeyCode.D))
        {
            Anim.SetTrigger("IdleToMove");
        }

        if (Input.GetKey(KeyCode.W))
        {
            Anim.SetTrigger("IdleToMove");
        }

    }
}
