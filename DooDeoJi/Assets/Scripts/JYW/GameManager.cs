using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public GameObject QuizUI;



    public Text[] gameText = new Text[2]; //1. ���� ��ȣ 2. ���� ���� 

    int answer;

    public int number = 1;

    public InputField inputanswer;

    public GameObject[] YesOrNo = new GameObject[6];
    public GameObject[] Faces = new GameObject[2];


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

        number = 1;

        GameManager.gm.gameText[0].text = "SOLVE MATH Q1:";
        GameManager.gm.RandomQuiz();

        for (int i = 0; i < GameManager.gm.YesOrNo.Length; i++)
        {
            GameManager.gm.YesOrNo[i].SetActive(false);
        }

        for (int i = 0; i < 2; i++)
        {
            GameManager.gm.Faces[i].SetActive(false);
        }


    }



    //1. ���� ��ȣ ����
    public void MakeMathQuiz()
    {

        //1. ���� Ȯ��
        GradeQuiz();

        
        

        if (number < 3)
        {
            inputanswer.text = "";

            //1. ���� ��ȣ ����
            number++;
            gameText[0].text = "SOLVE MATH Q" + number.ToString() + ":";


            //2. ���� ���� ����
            RandomQuiz();

            //3. �������� �� Ȯ���� �� ��ǲ�ʵ� �ʱ�ȭ
            

        }

        

        


    }

    

    public void RandomQuiz()
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

        print(answer);



    }

    void GradeQuiz()
    {
        string text = inputanswer.text;
        if (text == answer.ToString())
        {
            // 1-> 0, 2-> 2, 3->4 true
            YesOrNo[(number - 1) * 2].SetActive(true);
            Faces[0].SetActive(true);
            Faces[1].SetActive(false);
            
        }
        else
        {
            // 1->1, 2->3, 3->5
            YesOrNo[(number - 1) * 2 + 1].SetActive(true);
            Faces[0].SetActive(false);
            Faces[1].SetActive(true);
        }

        print(answer +"," + text);


    }

    public GameObject canvasUI;
    public void SetActiveOption(bool toggle)
    {
        //UIâ�� Ȱ��ȭ
        canvasUI.SetActive(toggle);

    }




}
