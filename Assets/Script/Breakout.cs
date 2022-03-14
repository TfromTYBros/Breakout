using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Breakout : MonoBehaviour
{
    BallScript ballScript;
    TimerManager Tmanager;

    public GameObject[] Blocks;
    public GameObject BlockBox;
    public GameObject BlockPos;
    public GameObject GameOverTextPar;
    public GameObject GameSetTextPar;
    public GameObject ResetButton;

    bool BoolGameStop = false;

    void Start()
    {
        ballScript = FindObjectOfType<BallScript>();
        Tmanager = FindObjectOfType<TimerManager>();
        //StartGame();
        DebugStart();
    }

    private void Update()
    {
        if(!BoolGameStop)IsGameSet();
    }

    void StartGame()
    {
        //Debug.Log("Start");
        BoolGameStop = false;
        ballScript.BallStop();
        MakeBlocks();
        Tmanager.TimerStart();
        Tmanager.StartCoroutine("TimerStop");
        ballScript.StartCoroutine("BallStartRightUp");
    }

    void DebugStart()
    {
        Instantiate(Blocks[0], new Vector3(0.0f, 2.0f, -1.0f), Quaternion.identity, BlockBox.transform);
        BoolGameStop = false;
        ballScript.BallStop();
        Tmanager.TimerStart();
        Tmanager.StartCoroutine("TimerStop");
        ballScript.StartCoroutine("DebugStart");
    }

    void MakeBlocks()
    {
        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 10; j++)
            {
                float yOffset = (i * 0.5f);
                float xOffset = (j * 1.6f);
                Instantiate(Blocks[i], new Vector3(GetBlockPos().x + xOffset, GetBlockPos().y - yOffset, -1.0f),Quaternion.identity, BlockBox.transform);
            }
        }
    }

    Vector2 GetBlockPos()
    {
        return BlockPos.transform.position;
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        ballScript.BallStop();
        EnaGameOverText();
    }

    void DisGameOverText()
    {
        GameOverTextPar.SetActive(false);
    }

    void EnaGameOverText()
    {
        GameOverTextPar.SetActive(true);
    }

    void DisGameSetText()
    {
        GameSetTextPar.SetActive(false);
    }

    void EnaGameSetText()
    {
        GameSetTextPar.SetActive(true);
    }

    int GetBlockCount()
    {
        return BlockBox.transform.childCount;
    }

    public void IsGameSet()
    {
        if (GetBlockCount() <= 0) GameSet();
    }

    void GameSet()
    {
        Debug.Log("GameSet");
        BoolGameStop = true;
        ballScript.BallStop();
        EnaGameSetText();
    }

    public void ResetButtonMethod()
    {
        DisGameOverText();
        DisGameSetText();
        ballScript.BallStop();
        ballScript.BallPosReset();
        StartGame();
        ballScript.BallStartRightUp();
    }
}