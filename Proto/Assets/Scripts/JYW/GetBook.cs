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

    private void OnCollisionStay(Collision collision)
    {
        //Enemy�� ������ ���߱�!!!!!!!

        //GameObject.FindWithTag("Enemy")
    }


    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.name == "Player" )
        {
            
            if(IsQuizEnd())
            {
                gameObject.transform.parent = collision.transform;
                gameObject.SetActive(false);

            }
            


            GameManager.gm.OpenQuizScreen(false);

            
        }
          
    }

    private bool IsQuizEnd()
    {
        int end = 0;

        for (int i=0; i < GameManager.gm.YesOrNo.Length; i++)
        {
            

            if(GameManager.gm.YesOrNo[i].activeSelf)
            {
                end++;
            }

        }

        if(end ==3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
