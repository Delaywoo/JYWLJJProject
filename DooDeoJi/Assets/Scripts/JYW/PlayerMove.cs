using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    //public float walkSpeed = 2.0f;
    //public float runSpeed = 7.0f;

    public float moveSpeed = 0;
    public float gravity = -9.81f; //중력 구현
    float yVelocity; //y속도

    CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>(); //캐릭터 컨드롤러를 찾음으로써 벽 통과 못하게함
    }

    // Update is called once per frame
    void Update()
    {
        yVelocity += gravity * Time.deltaTime; //y속도를 중력에 더해 한 프레임마다 누적시킴으로써 위를 보며 이동할 때 올라가는 것을 막음
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direction = Vector3.right * h + Vector3.forward * v;
        
        //카메라가 바라보는 방향을 앞방향으로 하고 싶다.
        direction = Camera.main.transform.TransformDirection(direction);

        direction.Normalize();
        direction.y = yVelocity; //y속도를 direction의 y에 대입

        cc.Move(direction * moveSpeed * Time.deltaTime); //Move함수는 캐릭터 컨트롤러의 Move값을 불러와서 움직이기 전에 충돌 검사를 하고 충돌체가 있으면 통과하지 못하게함
        //transform.position += direction * moveSpeed * Time.deltaTime;

    }




    //private void OnCollisionEnter(Collision collision)
    //{
    //    // collision 나랑 부딛힌 아이 정보?

    //    //나랑 딛혔을때 나를 지운다
    //    Destroy(gameObject);
    //    //나랑 부딛혔을때 부딛힌 아이를 지운다
    //    Destroy(collision.gameObject);
    //}

}
