using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-0.1f,0.0f,0.0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(0.1f, 0.0f, 0.0f);
        }
    }
}
