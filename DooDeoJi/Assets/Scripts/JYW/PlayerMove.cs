using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    

    // Start is called before the first frame update
    public float moveSpeed = 2.0f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        Vector3 direction = Vector3.left * h + Vector3.forward * -v;
        direction.Normalize();

        transform.position += direction * moveSpeed * Time.deltaTime;

        //카메라가 바라보는 방향을 앞방향으로 하고 싶다.
        direction = Camera.main.transform.TransformDirection(direction);

        
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
