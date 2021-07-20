using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBook : MonoBehaviour
{

    // 플레이어가 책의 영역에 닿으면 스페이스바를 누르라는 멘트가 뜸 
    // 스페이스바를 누르면 퀴즈창이 뜸
    // 플레이어가 답을 선택하면 퀴즈창이 사라지고 책이 사라짐.


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
    //        //퀴즈 UI창 뜨게 하는 함수 실행
    //        GameManager.gm.OpenQuizScreen(true);

    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            //퀴즈 UI창 뜨게 하는 함수 실행
            GameManager.gm.OpenQuizScreen(true);

            
        }

    }


    //private void OnCollisionEnter(Collision collision)
    //{

    //    if(collision.gameObject.name == "Player")
    //    {
    //        //퀴즈 UI창 뜨게 하는 함수 실행
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

            //충돌 영역에서 빠져나갈 때, 퀴즈 UI를 끈 후 적이 다시 움직이도록 한다.
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
