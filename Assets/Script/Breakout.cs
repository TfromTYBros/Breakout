using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakout : MonoBehaviour
{
    [SerializeField] public GameObject[] Blocks;
    [SerializeField] public GameObject BlockBox;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        Debug.Log("Start");
        MakeBlocks();
    }

    void MakeBlocks()
    {
        //zÇÕ-1
        //-8.0fÇ©ÇÁ+8.0fÇ‹Ç≈Ç™xé≤Ç©ÅH
        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 10; j++)
            {

            }
        }
    }

    Vector2 GetBlockBoxPos()
    {
        return BlockBox.transform.position;
    }

    public static void GameSet()
    {
        Debug.Log("GameSet");
    }
}
