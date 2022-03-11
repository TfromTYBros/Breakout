using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour
{
    private Vector2 mouse;
    private Vector2 target;
    private float y = -4.3f;

    void Update()
    {
        mouse = Input.mousePosition;
        target = Camera.main.ScreenToWorldPoint(mouse);
        target.y = y;
        this.transform.position = target;
    }
}
