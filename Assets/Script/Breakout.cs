using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakout : MonoBehaviour
{
    [SerializeField] public GameObject[] Blocks;
    [SerializeField] public GameObject BlockBox;
    [SerializeField] public GameObject BlockPos;

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

    public static void GameSet()
    {
        Debug.Log("GameSet");
    }
}
