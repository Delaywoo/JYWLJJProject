using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBook : MonoBehaviour
{
    // �÷��̾ å�� ������ ������ �����̽��ٸ� ������� ��Ʈ�� �� 
    // �����̽��ٸ� ������ ����â�� ��
    // �÷��̾ ���� �����ϸ� ����â�� ������� å�� �����.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.name == "Player")
        {
            //���� UIâ �߰� �ϴ� �Լ� ����
            GameManager.gm.OpenQuizScreen(true);


        }
        
        

    }


    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            gameObject.transform.parent = collision.transform;
            gameObject.SetActive(false);


            GameManager.gm.OpenQuizScreen(false);

            
        }
          
    }

}
