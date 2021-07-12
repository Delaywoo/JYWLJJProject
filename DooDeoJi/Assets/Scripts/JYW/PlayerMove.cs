using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    //public float walkSpeed = 2.0f;
    //public float runSpeed = 7.0f;

    public float moveSpeed = 0;
    public float gravity = -9.81f; //�߷� ����
    float yVelocity; //y�ӵ�

    CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>(); //ĳ���� ����ѷ��� ã�����ν� �� ��� ���ϰ���
    }

    // Update is called once per frame
    void Update()
    {
        yVelocity += gravity * Time.deltaTime; //y�ӵ��� �߷¿� ���� �� �����Ӹ��� ������Ŵ���ν� ���� ���� �̵��� �� �ö󰡴� ���� ����
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direction = Vector3.right * h + Vector3.forward * v;
        
        //ī�޶� �ٶ󺸴� ������ �չ������� �ϰ� �ʹ�.
        direction = Camera.main.transform.TransformDirection(direction);

        direction.Normalize();
        direction.y = yVelocity; //y�ӵ��� direction�� y�� ����

        cc.Move(direction * moveSpeed * Time.deltaTime); //Move�Լ��� ĳ���� ��Ʈ�ѷ��� Move���� �ҷ��ͼ� �����̱� ���� �浹 �˻縦 �ϰ� �浹ü�� ������ ������� ���ϰ���
        //transform.position += direction * moveSpeed * Time.deltaTime;

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
