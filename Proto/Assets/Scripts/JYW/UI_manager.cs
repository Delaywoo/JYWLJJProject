using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_manager : MonoBehaviour
{ 
    // 버튼 누르기 전 문항 정보
    void Start()
    {
        


    }

    public void UpMathQuiz()
    {
        GameManager.gm.MakeMathQuiz();
    }

    //옵션 패널이 닫히고 다시 게임을 재개하는 함수
    public void Resume()
    {

    }

    //게임 다시 시작 함수
    public void Restart()
    {
        SceneManager.LoadScene("JYW_Scene");
    }

    //앱 종료 함수
    public void Quit()
    {
        Application.Quit();
    }






}
