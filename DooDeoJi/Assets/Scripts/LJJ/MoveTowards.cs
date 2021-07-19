using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveLookAt();
    }

    void MoveLookAt()
    {
        //메인 카메라가 바라보는 방향
        Vector3 dir = cam.transform.localRotation * Vector3.forward;
        //카메라가 바라보는 방향으로 팩맨도 바라보게 함
        transform.localRotation = cam.transform.localRotation;
        //팩맨의 Rotation.x값을 freeze해놓았지만 움직여서 따로 Rotation값을 0으로 세팅해줌
        transform.localRotation = new Quaternion(0, transform.localRotation.y, 0, transform.localRotation.w);
        //바라보는 시점 방향으로 이동
        gameObject.transform.Translate(dir * 0.1f * Time.deltaTime);
    
    }


}
