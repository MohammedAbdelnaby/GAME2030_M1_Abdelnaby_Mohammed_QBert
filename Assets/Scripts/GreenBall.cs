using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBall : MonoBehaviour
{
    private bool IsOnGround = false;
    private bool LeftLane;
    // Start is called before the first frame update
    void Start()
    {
        if (Random.value >= 0.5)
        {
            LeftLane = true;
        }
        else
        {
            LeftLane = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (LeftLane)
        {
            MoveDownLeft();
        }
        else
        {
            MoveDownRight();
        }
    }

    private void MoveDownRight()
    {
        if (!IsOnGround)
        {
            return;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(0.80f, 2.0f);
    }
    private void MoveDownLeft()
    {
        if (!IsOnGround)
        {
            return;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(-0.80f, 2.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(collision.gameObject.tag == "RedBall" || collision.gameObject.tag == "GreenBall" || collision.gameObject.tag == "Coily"))
        {
            Vector3 Offset = new Vector3(0.0f, collision.gameObject.GetComponent<BoxCollider2D>().size.y, 0.0f);
            transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, transform.position.z) + (Offset * 2);
            IsOnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IsOnGround = false;
    }
}
