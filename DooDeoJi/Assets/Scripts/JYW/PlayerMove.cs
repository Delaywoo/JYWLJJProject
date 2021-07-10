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

        //ī�޶� �ٶ󺸴� ������ �չ������� �ϰ� �ʹ�.
        direction = Camera.main.transform.TransformDirection(direction);

        
    }




    //private void OnCollisionEnter(Collision collision)
    //{
    //    // collision ���� �ε��� ���� ����?

    //    //���� �������� ���� �����
    //    Destroy(gameObject);
    //    //���� �ε������� �ε��� ���̸� �����
    //    Destroy(collision.gameObject);
    //}

}
