using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameObject Ball;
    Vector3 BallVector;

    bool Right = true;
    bool Left = false;
    bool Up = true;
    bool Down = false;
    bool breakNow = false;

    int level = 1;
    float breaking = 0.025f;

    void Start()
    {
        BallVector = Ball.transform.position;
    }

    void Update()
    {
        if (Right) VectorXPlus();
        if (Left) VectorXMinus();
        if (Up) VectorYPlus();
        if (Down) VectorYMinus();

        Ball.transform.position = BallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit");
        if (collision.transform.CompareTag("LeftRight"))
        {
            SetBallVectorChangeLeftRightHit();
        }
        if (collision.transform.CompareTag("UpBlock"))
        {
            SetBallVectorChangeUpBlockHit();
        }
        if (collision.transform.CompareTag("BarLeft"))
        {
            Debug.Log("BarLeft");
        }
        if (collision.transform.CompareTag("BarLeftCenter"))
        {
            Debug.Log("BarLeftCenter");
        }
        if (collision.transform.CompareTag("BarCenter"))
        {
            Debug.Log("BarCenter");
            SetBallVectorChangeBarCenterHit();
        }
        if (collision.transform.CompareTag("BarCenterRight"))
        {
            Debug.Log("BarCenterRight");
            SetBallVectorChangeBarCenterRightHit();
        }
        if (collision.transform.CompareTag("BarRight"))
        {
            Debug.Log("BarRight");
            SetBallVectorChangeBarRightHit();
        }
    }

    void SetBallVectorChangeLeftRightHit()
    {
        if (Right)
        {
            Right = false;
            Left = true;
        }
        else
        {
            Left = false;
            Right = true;
        }
    }

    void SetBallVectorChangeUpBlockHit()
    {
        Up = false;
        Down = true;
    }

    void VectorXPlus()
    {
        BallVector.x += 0.05f;
    }

    void VectorXMinus()
    {
        BallVector.x -= 0.05f;
    }

    void VectorYPlus()
    {
        BallVector.y += (0.05f - breakNow ? breaking:0)*level;
    }

    void VectorYMinus()
    {
        BallVector.y -= 0.05f;
    }

    void SetBallVectorChangeBarCenterHit()
    {
        Debug.Log("SetBallVectorChangeBarCenterHit");
        Right = false;
        Left = false;
        Down = false;
        Up = true;
    }

    void SetBallVectorChangeBarCenterRightHit()
    {
        Debug.Log("SetBallVectorChangeBarCenterRight");
        Left = false;
        Right = true;
        Up = true;
        Down = false;
    }

    void SetBallVectorChangeBarRightHit()
    {
        Debug.Log("SetBallVectorChangeBarRight");
        Left = false;
        Right = true;
        Up = true;
        Down = false;
    }
}
