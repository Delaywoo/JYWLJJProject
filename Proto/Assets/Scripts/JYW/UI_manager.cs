using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_manager : MonoBehaviour
{ 
    // ��ư ������ �� ���� ����
    void Start()
    {
        


    }

    public void UpMathQuiz()
    {
        GameManager.gm.MakeMathQuiz();
    }

    //�ɼ� �г��� ������ �ٽ� ������ �簳�ϴ� �Լ�
    public void Resume()
    {

    }

    //���� �ٽ� ���� �Լ�
    public void Restart()
    {
        SceneManager.LoadScene("JYW_Scene");
    }

    //�� ���� �Լ�
    public void Quit()
    {
        Application.Quit();
    }






}
