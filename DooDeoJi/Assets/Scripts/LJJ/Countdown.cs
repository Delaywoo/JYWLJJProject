using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField] public float setTime = 300.0f;
    [SerializeField] Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        int minute_text;
        int second_text;

        minute_text = (int)setTime / 60;
        second_text = (int)setTime % 60;

        countdownText.text = minute_text.ToString() + "분 " + second_text.ToString() + "초";
    }

    // Update is called once per frame
    void Update()
    {
        if(setTime > 0)
        {
            setTime -= Time.deltaTime;
        }
        else if (setTime <= 0)
        {
            Time.timeScale = 0.0f;
        }

        float text_time = Mathf.Round(setTime);

        int uminute_text;
        int usecond_text;

        uminute_text = (int)setTime / 60;
        usecond_text = (int)setTime % 60;

        countdownText.text = uminute_text.ToString() + "분 " + usecond_text.ToString() + "초";

    }
}
