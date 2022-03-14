using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Breakout breakOut;

    public GameObject Ball;
    Vector3 BallVector;

    [SerializeField] bool Right = false;
    [SerializeField] bool Left = false;
    [SerializeField] bool Up = false;
    [SerializeField] bool Down = false;

    
    float breakingValue = 1;
    bool breaking = false;

    Vector3 BallStartPos = new Vector3(0.0f, -3.0f, -1.0f);
    WaitForSeconds countDownF = new WaitForSeconds(4.9f);

    void Start()
    {
        breakOut = FindObjectOfType<Breakout>();
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
            SetBallVectorChangeBarLeft();
            SetChangeBreaking();
        }
        if (collision.transform.CompareTag("BarLeftCenter"))
        {
            //Debug.Log("BarLeftCenter");
            SetBallVectorChangeBarLeftCenter();
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
        if (collision.transform.CompareTag("Catch"))
        {
            //Debug.Log("Catch");
            BallPosReset();
        }
        if (collision.transform.CompareTag("OutLine"))
        {
            Debug.Log("OutLine");
            breakOut.GameOver();
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
        //Debug.Log("BlockHit");
        if (Up)
        {
            Up = false;
            Down = true;
        }
        else
        {
            Up = true;
            Down = false;
        }
    }

    void VectorXPlus()
    {
        BallVector.x += 0.025f * breakOut.GetLevel();
    }

    void VectorXMinus()
    {
        BallVector.x -= 0.025f * breakOut.GetLevel();
    }

    void VectorYPlus()
    {
        BallVector.y += (0.025f * breakingValue) * breakOut.GetLevel();
    }

    void VectorYMinus()
    {
        BallVector.y -= (0.025f * breakingValue) * breakOut.GetLevel();
    }

    void SetChangeBreaking()
    {
        if (breaking) breakingValue = 1.5f;
        else breakingValue = 1.0f;
    }

    void SetBallVectorChangeBarLeft()
    {
        //Debug.Log("SetBallChangeBarLeft");
        Right = false;
        Down = false;
        Left = true;
        Up = true;
        breaking = false;
    }

    void SetBallVectorChangeBarLeftCenter()
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

    public void BallPosReset()
    {
        //Debug.Log("CatchBall");
        BallVector = BallStartPos;
    }

    public void BallStop()
    {
        //Debug.Log("BallStop");
        Right = false;
        Left = false;
        Up = false;
        Down = false;
        breaking = false;
    }

    public IEnumerator BallStartRightUp()
    {
        yield return countDownF;
        Right = true;
        Up = true;

        Left = false;
        Down = false;
        breaking = false;
    }

    public IEnumerator DebugStart()
    {
        yield return countDownF;
        Up = true;
    }
}
