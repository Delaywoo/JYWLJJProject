using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public GameObject QuizUI;
    public Text[] gameText = new Text[3]; //1. 문항 번호 2. 퀴즈 내용 3. 퀴즈 답 입력칸



    private void Awake()
    {
        if(gm == null)
        {
            gm = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        OpenQuizScreen(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OpenQuizScreen(bool toggle)
    {
        //퀴즈 UI창을 활성화한다.
        QuizUI.SetActive(toggle);

        //enter키를 누를 때마다(i++) 퀴즈 번호가 바뀌고, 문제도 바뀜 
        //정답이면 파란색+웃는 표정, 오답이면 빨간색 표시+화난 표정을 answer[i] 창에 한칸씩 한다.
        //answerInput 창에는 사용자가 입력한 숫자가 그대로 입력되게!


        
       


                

    }


    void MakeMathQuiz()
    {
        //1. 문항번호 설정
        //int i = 1;
        



        //2. 문제 내용 설정
        
        int answer;
        
        int a = Random.Range(1, 101);
        int b = Random.Range(1, 101);
        int sign = Random.Range(0, 3);
        
        if(sign == 0)
        {
            gameText[1].text = a.ToString() + "+" + b.ToString();
            answer = a + b;
        }

        if (sign == 1)
        {
            gameText[1].text = a.ToString() + "-" + b.ToString();
            answer = a - b;
        }

        if (sign == 2)
        {
            gameText[1].text = a.ToString() + "*" + b.ToString();
            answer = a * b;
        }

        




    }



}
