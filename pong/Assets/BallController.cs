using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public float speed = 7f;
    public Rigidbody2D rgb;
    [SerializeField]
    public GameObject top,wall;
    [SerializeField] public Text winner;
    [SerializeField] public GameObject panel;

    [SerializeField]
    public Text point1, point2;


    public int pointp2, pointp1;
    void Start()
    {    
        ball();
        pointp1 = pointp2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        point1.text = pointp1.ToString();
        point2.text = pointp2.ToString();
    }
    void ball()
    {
            float x = Random.Range(0, 2) == 0 ? -1 : 1;
            float y = Random.Range(0, 2) == 0 ? -1 : 1;
            rgb.velocity = new Vector2(x * speed, y * speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "wallDead1")
        {
            pointp2++;
            top.transform.position = Vector2.zero;
            controll();
        }
        if (collision.gameObject.name == "wallDead2")
        {
            pointp1++;
            top.transform.position = Vector2.zero;
            controll();
        }
    }
    void controll()
    {
        if (pointp1 == 3)
        {
            panel.GetComponent<CanvasGroup>().alpha = 1;
            winner.text = "player1 won!";
            wall.SetActive(true);
        }
        else if(pointp2 == 3) 
        {
            panel.GetComponent<CanvasGroup>().alpha = 1;
            winner.text = "player2 won!";
            wall.SetActive(true);
        }
    }
    public void TryAgain()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
