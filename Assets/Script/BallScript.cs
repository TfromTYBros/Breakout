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

    
    float breakingXValue = 1.0f;
    float breakingYValue = 1.0f;

    Vector3 BallStartPos = new Vector3(0.0f, -3.0f, -1.0f);
    WaitForSeconds countDownF = new WaitForSeconds(2.9f);
    CircleCollider2D circleCollider2D;

    void Start()
    {
        circleCollider2D = this.gameObject.GetComponent<CircleCollider2D>();
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
        //wall,block
        if (collision.transform.CompareTag("LeftRight"))
        {
            SetBallVectorChangeLeftRightHit();
        }
        if (collision.transform.CompareTag("UpBlock"))
        {
            SetBallVectorChangeUpBlockHit();
        }
        //Bars
        if (collision.transform.CompareTag("Bar0"))
        {
            //Debug.Log("Bar0");
            SetBallVectorChangeBar0Hit();
        }
        if (collision.transform.CompareTag("Bar1"))
        {
            //Debug.Log("Bar1");
            SetBallVectorChangeBar1Hit();
        }
        if (collision.transform.CompareTag("Bar2"))
        {
            //Debug.Log("Bar2");
            SetBallVectorChangeBar2Hit();
        }
        if (collision.transform.CompareTag("Bar3"))
        {
            //Debug.Log("Bar3");
            SetBallVectorChangeBar3Hit();
        }
        if (collision.transform.CompareTag("BarCenter"))
        {
            //Debug.Log("BarCenter");
            SetBallVectorChangeBarCenterHit();
        }
        if (collision.transform.CompareTag("Bar5"))
        {
            //Debug.Log("Bar5");
            SetBallVectorChangeBar5Hit();
        }
        if (collision.transform.CompareTag("Bar6"))
        {
            //Debug.Log("Bar6");
            SetBallVectorChangeBar6Hit();
        }
        if (collision.transform.CompareTag("Bar7"))
        {
            //Debug.Log("Bar7");
            SetBallVectorChangeBar7Hit();
        }
        if (collision.transform.CompareTag("Bar8"))
        {
            //Debug.Log("Bar8");
            SetBallVectorChangeBar8Hit();
        }

        //safeLine
        if (collision.transform.CompareTag("Catch"))
        {
            //Debug.Log("Catch");
            BallPosReset();
        }
        if (collision.transform.CompareTag("OutLine"))
        {
            //Debug.Log("OutLine");
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
        BallVector.x += (0.02f + breakingXValue) * breakOut.GetLevel();
    }

    void VectorXMinus()
    {
        BallVector.x -= (0.02f + breakingXValue) * breakOut.GetLevel();
    }

    void VectorYPlus()
    {
        BallVector.y += (0.02f + breakingYValue) * breakOut.GetLevel();
    }

    void VectorYMinus()
    {
        BallVector.y -= (0.02f + breakingYValue) * breakOut.GetLevel();
    }

    void SetChangeBreakingX(float value)
    {
        breakingXValue = value;
    }

    void SetChangeBreakingY(float value)
    {
        breakingYValue = value;
    }

    void SetBallVectorChangeBar0Hit()
    {
        //Debug.Log("SetBallVectorChangeBarLeftEdgeHit");
        Right = false;
        Down = false;
        Left = true;
        Up = true;
        SetChangeBreakingX(0.02f);
        SetChangeBreakingY(0.005f);
    }

    void SetBallVectorChangeBar1Hit()
    {
        //Debug.Log("SetBallChangeBarLeftHit");
        Right = false;
        Down = false;
        Left = true;
        Up = true;
        SetChangeBreakingX(0.015f);
        SetChangeBreakingY(0.01f);
    }

    void SetBallVectorChangeBar2Hit()
    {
        //Debug.Log("SetBallChangeBar2");
        Right = false;
        Down = false;
        Left = true;
        Up = true;
        SetChangeBreakingX(0.01f);
        SetChangeBreakingY(0.015f);
    }

    void SetBallVectorChangeBar3Hit()
    {
        //Debug.Log("SetBallChangeBar3");
        Right = false;
        Down = false;
        Left = true;
        Up = true;
        SetChangeBreakingX(0.005f);
        SetChangeBreakingY(0.02f);
    }

    void SetBallVectorChangeBarCenterHit()
    {
        //Debug.Log("SetBallVectorChangeBarCenterHit");
        Right = false;
        Left = false;
        Down = false;
        Up = true;
        SetChangeBreakingX(0.0f);
        SetChangeBreakingY(0.02f);
    }

    void SetBallVectorChangeBar5Hit()
    {
        //Debug.Log("SetBallVectorChangeBar5Hit");
        Left = false;
        Right = true;
        Up = true;
        Down = false;
        SetChangeBreakingX(0.005f);
        SetChangeBreakingY(0.02f);
    }

    void SetBallVectorChangeBar6Hit()
    {
        //Debug.Log("SetBallVectorChangeBar6Hit");
        Left = false;
        Right = true;
        Up = true;
        Down = false;
        SetChangeBreakingX(0.01f);
        SetChangeBreakingY(0.015f);
    }
    void SetBallVectorChangeBar7Hit()
    {
        //Debug.Log("SetBallVectorChangeBar7Hit");
        Left = false;
        Right = true;
        Up = true;
        Down = false;
        SetChangeBreakingX(0.015f);
        SetChangeBreakingY(0.01f);
    }
    void SetBallVectorChangeBar8Hit()
    {
        //Debug.Log("SetBallVectorChangeBar8Hit");
        Left = false;
        Right = true;
        Up = true;
        Down = false;
        SetChangeBreakingX(0.02f);
        SetChangeBreakingY(0.005f);
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
        SetChangeBreakingX(0.0f);
        SetChangeBreakingY(0.0f);
    }

    public IEnumerator BallStartRightUp()
    {
        yield return countDownF;
        Right = true;
        Up = true;
        Left = false;
        Down = false;
        SetChangeBreakingX(0.015f);
        SetChangeBreakingY(0.015f);
    }

    public IEnumerator DebugStart()
    {
        yield return countDownF;
        Up = true;
    }

    public IEnumerator EnaBall()
    {
        yield return countDownF;
        circleCollider2D.enabled = true;
    }

    public void DisBall()
    {
        circleCollider2D.enabled = false;
    }
}
