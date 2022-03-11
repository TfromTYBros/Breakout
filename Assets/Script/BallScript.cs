using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameObject Ball;
    Vector3 BallVector;

    bool RightPlus = true;
    bool UpPlus = true;

    void Start()
    {
        BallVector = Ball.transform.position;
    }

    void Update()
    {
        if (RightPlus) VectorXPlus();
        else VectorXMinus();
        if (UpPlus) VectorYPlus();
        else VectorYMinus();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit");
        if (collision.transform.CompareTag("LeftRight"))
        {
            SetBallVectorChangeRight();
        }
        if (collision.transform.CompareTag("UpDown"))
        {
            SetBallVectorChangeUp();
        }
    }

    void SetBallVectorChangeRight()
    {
        if (RightPlus) RightPlus = false;
        else RightPlus = true;
    }

    void SetBallVectorChangeUp()
    {
        if (UpPlus) UpPlus = false;
        else UpPlus = true;
    }

    void VectorXPlus()
    {
        BallVector.x += 0.01f;
        Ball.transform.position = BallVector;
    }

    void VectorXMinus()
    {
        BallVector.x -= 0.01f;
        Ball.transform.position = BallVector;
    }

    void VectorYPlus()
    {
        BallVector.y += 0.01f;
        Ball.transform.position = BallVector;
    }

    void VectorYMinus()
    {
        BallVector.y -= 0.01f;
        Ball.transform.position = BallVector;
    }
}
