using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public GameObject TimerPar;
    public Text Timer;

    bool Vaild = false;
    float time = 6.0f;
    int second = 0;

    WaitForSeconds countDownF = new WaitForSeconds(4.9f);

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
        yield return countDownF;
        Vaild = false;
        TimerPar.SetActive(false);
        time = 6.0f;
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

    public bool GetValid()
    {
        return Vaild;
    }
}
