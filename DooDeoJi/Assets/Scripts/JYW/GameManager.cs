using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public GameObject QuizUI;
    public GameObject OptionUI;



    public Text[] gameText = new Text[2]; //1. 문항 번호 2. 퀴즈 내용 

    int answer;

    public int number = 1;

    public InputField inputanswer;

    public GameObject[] YesOrNo = new GameObject[6];
    public GameObject[] Faces = new GameObject[2];

    public Text bookcount;
    public GameObject bookparents;

    public float LimitTime = 30.0f;
    float RealTime;
    public Text text_Timer;

    public int correctAnswerNum = 0;

    public int end = 0;

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
        OpenOption(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        CountMyBook();

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            OpenOption(true);
        }


        TimeLimit();

    }

    void TimeLimit()
    {
        if (QuizUI.activeSelf == true)
        {
            

            if (RealTime > 0)
            {
                RealTime -= Time.deltaTime;
                text_Timer.text = "Time Limit: " + Mathf.Ceil(RealTime).ToString() + "s";


            }

            //제한 시간 다되면
            else
            {
                // 1. 퀴즈 ui창 비활성화
                OpenQuizScreen(false);
                // 2. 적 속도 1.2배
                GameObject.FindWithTag("Enemy").GetComponent<EnemyFSM>().speed *= 1.2f;
                // 3. 적 state = move로 바꾸기
                GameObject.FindWithTag("Enemy").GetComponent<EnemyFSM>().state = EnemyFSM.State.Move;


            }
        }

    }

    public void OpenQuizScreen(bool toggle)
    {
        //퀴즈 UI창을 활성화한다.
        QuizUI.SetActive(toggle);
        end = 0;
        
        RealTime = LimitTime;

        number = 1;

        gameText[0].text = "SOLVE MATH Q1:";
        gm.RandomQuiz();

        for (int i = 0; i < YesOrNo.Length; i++)
        {
            YesOrNo[i].SetActive(false);
        }

        for (int i = 0; i < 2; i++)
        {
            Faces[i].SetActive(false);
        }





    }

    


    //optional panel
    public void OpenOption(bool toggle)
    {
        OptionUI.SetActive(toggle);

    }



    //1. 문항 번호 설정
    public void MakeMathQuiz()
    {

        //1. 정답 확인
        GradeQuiz();

        
        

        if (number < 3)
        {
            inputanswer.text = "";

            //1. 문항 번호 설정
            number++;
            gameText[0].text = "SOLVE MATH Q" + number.ToString() + ":";


            //2. 문제 내용 설정
            RandomQuiz();

            //3. 이전문제 답 확인한 후 인풋필드 초기화
            

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
            correctAnswerNum++;

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
        //UI창을 활성화
        canvasUI.SetActive(toggle);

    }

    void CountMyBook()
    {
        int countmybook = 5 - bookparents.transform.childCount;
        bookcount.text = countmybook.ToString() + " / 5 ";

    }

    



}
