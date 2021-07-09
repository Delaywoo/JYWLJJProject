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
        
        float h = Input.GetAxis("Vertical");
        float v = Input.GetAxis("Horizontal");
        
  
        Vector3 direction = new Vector3 (-v, 0, -h);
        direction.Normalize();

        transform.position += direction * moveSpeed * Time.deltaTime;


        
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
