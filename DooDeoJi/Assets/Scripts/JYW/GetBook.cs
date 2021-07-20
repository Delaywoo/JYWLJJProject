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

    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if (hit.transform.name == "Player")
    //    {
    //        //���� UIâ �߰� �ϴ� �Լ� ����
    //        GameManager.gm.OpenQuizScreen(true);

    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            //���� UIâ �߰� �ϴ� �Լ� ����
            GameManager.gm.OpenQuizScreen(true);

            
        }

    }


    //private void OnCollisionEnter(Collision collision)
    //{

    //    if(collision.gameObject.name == "Player")
    //    {
    //        //���� UIâ �߰� �ϴ� �Լ� ����
    //        GameManager.gm.OpenQuizScreen(true);

    //    }


    //}

    private void OnTriggerStay(Collider other)
    {
        if(GameManager.gm.QuizUI.activeSelf == true)
        {
            GameObject.FindWithTag("Enemy").GetComponent<EnemyFSM>().state = EnemyFSM.State.Stop;


        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {

            if (IsQuizEnd())
            {
                gameObject.transform.parent = other.transform;
                gameObject.SetActive(false);

                if(GameManager.gm.correctAnswerNum != 3)
                {
                    GameObject.FindWithTag("Enemy").GetComponent<EnemyFSM>().speed *= 1.2f;

                }

            }



            GameManager.gm.OpenQuizScreen(false);

            //�浹 �������� �������� ��, ���� UI�� �� �� ���� �ٽ� �����̵��� �Ѵ�.
            GameObject.FindWithTag("Enemy").GetComponent<EnemyFSM>().state = EnemyFSM.State.Move;
            

        }
    }

    public bool IsQuizEnd()
    {
        for (int i = 0; i < GameManager.gm.YesOrNo.Length; i++)
        {
            if(GameManager.gm.YesOrNo[i].activeSelf == true)
            {
                GameManager.gm.end++;
            }
        }


        if (GameManager.gm.end == 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    if(collision.gameObject.name == "Player" )
    //    {

    //        if(IsQuizEnd())
    //        {
    //            gameObject.transform.parent = collision.transform;
    //            gameObject.SetActive(false);

    //        }



    //        GameManager.gm.OpenQuizScreen(false);


    //    }

    //}




}
