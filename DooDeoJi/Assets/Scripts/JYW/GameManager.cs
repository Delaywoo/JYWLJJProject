using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public GameObject QuizUI;
    

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

                

    }



    



}
