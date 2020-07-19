using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMove : MonoBehaviour
{
    public int speed;
    public int bounceDegree;
    
    private float gap;
    private Rigidbody2D ballRb;


    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        //물리 약간 적용
        //transform.Translate(new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //막대가 공이랑 부딪히면
        if(collision.gameObject.tag == "Ball")
        { 
            Vector2 hitpoint = collision.contacts[0].point;
            Vector2 barCenterPoint = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);

            //공 충돌지점 - 바 중간 == gap (중간부터 얼마나 멀리에서 충돌했는지)
            gap =  hitpoint.x - barCenterPoint.x;
            ballRb = collision.gameObject.GetComponent<Rigidbody2D>();

            ballRb.velocity = Vector2.zero;
            ballRb.AddForce(new Vector2(gap * bounceDegree , collision.gameObject.GetComponent<BallMove>().speed));
        }
    }
}
