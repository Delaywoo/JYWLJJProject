using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//마우스의 입력값을 이용해서 회전하고 싶다.
public class CameraControll : MonoBehaviour
{
    float rx;
    float ry;

    public float rotSpeed = 200;


    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        //1. 마우스의 입력값을 이용해서
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        rx += rotSpeed * my * Time.deltaTime; //마우스가 위아래로 움직일 때 x축으로 회전
        ry += rotSpeed * mx * Time.deltaTime; //마우스가 좌우로 움직일 때 y축으로 회전

        //rx의 회전각을 제한하고 싶다. +-80도
        rx = Mathf.Clamp(rx, -80, 80);
        

        
        //2. 회전하고 싶다.
        transform.eulerAngles = new Vector3(-rx, ry, 0); //transform.rotation을 의미
        

    }
}
