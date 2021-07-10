using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour
{

    public Text[] gameText = new Text[2]; //1. 문항 번호 2. 퀴즈 내용 

    int number = 1;
    private int answer;


    public Text inputanswer;

    public GameObject yes;
    public GameObject no;
    



    // 버튼 누르기 전 문항 정보
    void Start()
    {
        gameText[0].text = "SOLVE MATH Q1:";
        RandomQuiz();

        yes.SetActive(false);
        no.SetActive(false);


    }



    //1. 문항 번호 설정
    public void MakeMathQuiz()
    {
        
               
        if(number < 3)
        {
            
            //1. 문항 번호 설정
            number++;
            gameText[0].text = "SOLVE MATH Q" + number.ToString() + ":";

            //2. 문제 내용 설정
            RandomQuiz();

            //3. 인풋필드 초기화: inspector 창에서 설정함. inputfield -> text : null로 설정

        }
        
    }

    void RandomQuiz()
    {
        
        int a = Random.Range(1, 101);
        int b = Random.Range(1, 101);
        int sign = Random.Range(0, 3);

        if (sign == 0)
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
