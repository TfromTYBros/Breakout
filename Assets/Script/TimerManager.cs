using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public GameObject TimerPar;
    public Text Timer;

    bool Vaild = false;

    float time = 5.0f;
    int second = 0;

    void Update()
    {
        if (Vaild)
        {
            CountDown();
        }
    }

    public void TimerStart()
    {
        TimerPar.SetActive(true);
        Vaild = true;
    }

    public IEnumerator TimerStop()
    {
        yield return new WaitForSeconds(5.0f);
        Vaild = false;
        TimerPar.SetActive(false);
        time = 0.0f;
        second = 0;
        TextChanger();
    }

    void CountDown()
    {
        time -= Time.deltaTime;
        second = (int)time;
        TextChanger();
    }

    void TextChanger()
    {
        Timer.text = second.ToString();
    }
}
