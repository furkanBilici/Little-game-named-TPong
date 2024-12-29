using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public bool isPlayer1;
    public Rigidbody2D rgb;
    public float speed=5f;

  
    void Update()
    {
        if (isPlayer1)
        {
            rgb.velocity = Vector2.up * Input.GetAxisRaw("VerticalPlayer1")*speed;
        }
        else
        {
            rgb.velocity = Vector2.up * Input.GetAxisRaw("VerticalPlayer2") * speed;
        }
    }
}
