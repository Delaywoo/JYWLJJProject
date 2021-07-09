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

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.name == "Player")
        {
            //퀴즈 UI창 뜨게 하는 함수 실행
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
