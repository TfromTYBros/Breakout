using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour
{
    bool IsRangeLeft = true;
    bool IsRangeRight = true;
    void Update()
    {
        SetRange();
        if (IsRangeLeft && Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-0.1f,0.0f,0.0f);
        }
        else if (IsRangeRight && Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(0.1f, 0.0f, 0.0f);
        }
    }

    void SetRange()
    {
        if (-6.5f < this.transform.position.x) IsRangeLeft = true;
        else IsRangeLeft = false;
        if (this.transform.position.x < 6.4f) IsRangeRight = true;
        else IsRangeRight = false;
    }
}
