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

    public int level = 1;
    bool BoolGameStop = false;

    void Start()
    {
        ballScript = FindObjectOfType<BallScript>();
        Tmanager = FindObjectOfType<TimerManager>();
        StartGame();
        //DebugStart();
    }

    private void Update()
    {
        if(!BoolGameStop)IsGameSet();
        if (BoolGameStop && Input.GetKey(KeyCode.Space) && GetBlockCount() <= 0) NextGame();
        if (BoolGameStop && Input.GetKey(KeyCode.Space) && 0 < GetBlockCount()) ResetMethod();
    }

    void StartGame()
    {
        //Debug.Log("Start");
        BoolGameStop = false;
        ballScript.BallStop();
        ballScript.BallPosReset();
        MakeBlocks();
        Tmanager.TimerStart();
        Tmanager.StartCoroutine("TimerStop");
        ballScript.StartCoroutine("BallStartRightUp");
        ballScript.StartCoroutine("EnaBall");
    }

    void DebugStart()
    {
        //Debug.Log("DebugStart");
        Instantiate(Blocks[0], new Vector3(0.0f, 2.0f, -1.0f), Quaternion.identity, BlockBox.transform);
        BoolGameStop = false;
        ballScript.BallStop();
        ballScript.BallPosReset();
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
        //Debug.Log("GameOver");
        ballScript.BallStop();
        BoolGameStop = true;
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
        //Debug.Log("GameSet");
        BoolGameStop = true;
        ballScript.DisBall();
        ballScript.BallStop();
        EnaGameSetText();
    }

    public void NextGame()
    {
        LevelUp();
        DisGameSetText();
        StartGame();
    }

    public int GetLevel()
    {
        return level;
    }

    void LevelUp()
    {
        level++;
    }

    void LevelReset()
    {
        level = 1;
    }

    public void ResetMethod()
    {
        if (!Tmanager.GetValid())
        {
            LevelReset();
            ScoreScript.ScoreReset();
            DisGameOverText();
            DisGameSetText();
            ballScript.BallStop();
            ballScript.BallPosReset();
            DestroyAllBlock();
            StartGame();
        }
    }

    void DestroyAllBlock()
    {
        foreach(Transform trn in BlockBox.transform)
        {
            GameObject.Destroy(trn.gameObject);
        }
    }
}
