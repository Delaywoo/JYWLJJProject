using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//마우스의 입력값을 이용해서 회전하고 싶다.
public class CameraControll : MonoBehaviour
{
    //float rx;
    //float ry;

    //public float rotSpeed = 200;


    //// Start is called before the first frame update
    //void Start()
    //{
        

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    //1. 마우스의 입력값을 이용해서
    //    float mx = Input.GetAxis("Mouse X");
    //    float my = Input.GetAxis("Mouse Y");
        
    //    rx += rotSpeed * my * Time.deltaTime; //마우스가 위아래로 움직일 때 x축으로 회전
    //    ry += rotSpeed * mx * Time.deltaTime; //마우스가 좌우로 움직일 때 y축으로 회전

    //    //rx의 회전각을 제한하고 싶다. +-80도
    //    rx = Mathf.Clamp(rx, -80, 80);

    //    //2. 회전하고 싶다.
    //    transform.eulerAngles = new Vector3(-rx, ry, 0); //transform.rotation을 의미
        

    //}

    // 사용자의 마우스 드래그 입력을 받아서 캐릭터를 상하좌우로 회전시키고 싶다!
    // 필요 요소: 마우스 드래그 입력, 회전의 방향(축), 회전 속력
    public float rotSpeed = 10.0f;

    public bool rotateX = false;
    public bool rotateY = false;

    float rotX = 0;
    float rotY = 0;

    void Start()
    {

    }

    void Update()
    {
        // 마우스의 드래그 방향 입력을 받는다.
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        #region 실시간 회전 계산 방식
        //// 입력을 기준으로 회전의 방향을 설정한다.
        //Vector3 dir = new Vector3(-y, x, 0);
        //dir.Normalize();

        //// 회전 방향으로 회전한다.(r = r0 + vt)
        //transform.eulerAngles += dir * rotSpeed * Time.deltaTime;

        //// x축 회전 값을 상하 60도 정도로 제한한다.

        //Vector3 currentRot = transform.eulerAngles;

        ////if (currentRot.x > 60)
        ////{
        ////    currentRot.x = 60;
        ////}
        ////else if(currentRot.x < -60)
        ////{
        ////    currentRot.x = -60;
        ////}

        //currentRot.x = Mathf.Clamp(currentRot.x, -60.0f, 60.0f);

        //transform.eulerAngles = currentRot;
        #endregion

        // 입력 값을 회전 변수에 누적시킨다.
        if (rotateY)
        {
            rotX += x * rotSpeed * Time.deltaTime;
        }

        if (rotateX)
        {
            rotY += y * rotSpeed * Time.deltaTime;
        }

        // rotY의 값을 -60도 ~ 60도 사이로 제한한다.
        rotY = Mathf.Clamp(rotY, -60.0f, 60.0f);

        // 회전 벡터(오일러 각)를 만든다.
        Vector3 dir = new Vector3(-rotY, rotX, 0);

        transform.localEulerAngles = dir;
    }

}
