using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public float sensitivity = 500f;


    // Start is called before the first frame update
    void Start()
    {
        float moveDirX = Input.GetAxis("Horizontal");
        float moveDirZ = Input.GetAxis("Vertical");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
