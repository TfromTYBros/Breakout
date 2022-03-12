using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameObject Ball;
    Vector3 BallVector;

    bool Right = false;
    bool Left = false;
    bool Up = true;
    bool Down = false;

    int level = 1;
    float breakingValue = 1;
    bool breaking = false;

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
        //Debug.Log("Hit");
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
            //Debug.Log("BarLeft");
            SetBallChangeBarLeft();
            SetChangeBreaking();
        }
        if (collision.transform.CompareTag("BarLeftCenter"))
        {
            //Debug.Log("BarLeftCenter");
            SetBallChangeBarLeftCenter();
            SetChangeBreaking();
        }
        if (collision.transform.CompareTag("BarCenter"))
        {
            //Debug.Log("BarCenter");
            SetBallVectorChangeBarCenterHit();
            SetChangeBreaking();
        }
        if (collision.transform.CompareTag("BarCenterRight"))
        {
            //Debug.Log("BarCenterRight");
            SetBallVectorChangeBarCenterRightHit();
            SetChangeBreaking();
        }
        if (collision.transform.CompareTag("BarRight"))
        {
            //Debug.Log("BarRight");
            SetBallVectorChangeBarRightHit();
            SetChangeBreaking();
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
        BallVector.x += 0.05f * level;
    }

    void VectorXMinus()
    {
        BallVector.x -= 0.05f * level;
    }

    void VectorYPlus()
    {
        BallVector.y += (0.05f * breakingValue) * level;
    }

    void VectorYMinus()
    {
        BallVector.y -= (0.05f * breakingValue) * level;
    }

    void SetChangeBreaking()
    {
        if (breaking) breakingValue = 1.5f;
        else breakingValue = 1.0f;
    }

    void SetBallChangeBarLeft()
    {
        //Debug.Log("SetBallChangeBarLeft");
        Right = false;
        Down = false;
        Left = true;
        Up = true;
        breaking = false;
    }

    void SetBallChangeBarLeftCenter()
    {
        //Debug.Log("SetBallChangeBarLeftCenter");
        Right = false;
        Down = false;
        Left = true;
        Up = true;
        breaking = true;
    }

    void SetBallVectorChangeBarCenterHit()
    {
        //Debug.Log("SetBallVectorChangeBarCenterHit");
        Right = false;
        Left = false;
        Down = false;
        Up = true;
        breaking = false;
    }

    void SetBallVectorChangeBarCenterRightHit()
    {
        //Debug.Log("SetBallVectorChangeBarCenterRight");
        Left = false;
        Right = true;
        Up = true;
        Down = false;
        breaking = true;
    }

    void SetBallVectorChangeBarRightHit()
    {
        //Debug.Log("SetBallVectorChangeBarRight");
        Left = false;
        Right = true;
        Up = true;
        Down = false;
        breaking = false;
    }
}
