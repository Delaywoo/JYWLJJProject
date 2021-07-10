using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour
{

    public Text[] gameText = new Text[2]; //1. ���� ��ȣ 2. ���� ���� 

    int number = 1;
    private int answer;


    public Text inputanswer;

    public GameObject yes;
    public GameObject no;
    



    // ��ư ������ �� ���� ����
    void Start()
    {
        gameText[0].text = "SOLVE MATH Q1:";
        RandomQuiz();

        yes.SetActive(false);
        no.SetActive(false);


    }



    //1. ���� ��ȣ ����
    public void MakeMathQuiz()
    {
        
               
        if(number < 3)
        {
            
            //1. ���� ��ȣ ����
            number++;
            gameText[0].text = "SOLVE MATH Q" + number.ToString() + ":";

            //2. ���� ���� ����
            RandomQuiz();

            //3. ��ǲ�ʵ� �ʱ�ȭ: inspector â���� ������. inputfield -> text : null�� ����

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
