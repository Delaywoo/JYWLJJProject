using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            animator.SetBool("isOpen", true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            animator.SetBool("isOpen", false);
        }
    }

}
