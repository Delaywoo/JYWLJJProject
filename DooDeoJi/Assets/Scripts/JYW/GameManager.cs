using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public GameObject QuizUI;
    public Text[] gameText = new Text[3]; //1. ���� ��ȣ 2. ���� ���� 3. ���� �� �Է�ĭ



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
        //���� UIâ�� Ȱ��ȭ�Ѵ�.
        QuizUI.SetActive(toggle);

        //enterŰ�� ���� ������(i++) ���� ��ȣ�� �ٲ��, ������ �ٲ� 
        //�����̸� �Ķ���+���� ǥ��, �����̸� ������ ǥ��+ȭ�� ǥ���� answer[i] â�� ��ĭ�� �Ѵ�.
        //answerInput â���� ����ڰ� �Է��� ���ڰ� �״�� �Էµǰ�!


        
       


                

    }


    void MakeMathQuiz()
    {
        //1. ���׹�ȣ ����
        //int i = 1;
        



        //2. ���� ���� ����
        
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
