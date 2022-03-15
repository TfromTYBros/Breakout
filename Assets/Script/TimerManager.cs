using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public GameObject TimerPar;
    public Text Timer;

    bool Vaild = false;
    float time = 4.0f;
    int second = 0;

    public GameObject InfoArrow;

    WaitForSeconds countDownF = new WaitForSeconds(2.9f);

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
        EnaInfoArrow();
    }

    public IEnumerator TimerStop()
    {
        yield return countDownF;
        Vaild = false;
        TimerPar.SetActive(false);
        time = 4.0f;
        second = 0;
        TextChanger();
        DisInfoArrow();
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

    public bool GetValid()
    {
        return Vaild;
    }

    void EnaInfoArrow()
    {
        InfoArrow.SetActive(true);
    }

    void DisInfoArrow()
    {
        InfoArrow.SetActive(false);
    }
}
