using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Sprite changeSprite;

    public Transform TileOn;
    private bool IsOnGround = false;

    private bool onElavator = false;
    private GameObject elevator;
    private int Lifes = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpRight();
        MoveUpLeft();
        MoveDownRight();
        MoveDownLeft();
        Reset();
        moveWithElavator();
    }

    private void moveWithElavator()
    {
        if (onElavator && elevator.GetComponent<BoxCollider2D>().enabled)
        {
            Vector3 Offset = new Vector3(0.0f,elevator.GetComponent<SpriteRenderer>().size.y /2, 0.0f);
            transform.position = new Vector3(elevator.transform.position.x, elevator.transform.position.y, transform.position.z) + (Offset * 2);
        }

    }

    private void MoveUpRight()
    {
        if (!IsOnGround)
        {
            return;
        }
        if (Input.GetKeyDown("up") || Input.GetKeyDown("[8]"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0.75f, 4.5f);
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    private void MoveUpLeft()
    {
        if (!IsOnGround)
        {
            return;
        }
        if (Input.GetKeyDown("left") || Input.GetKeyDown("[4]"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-0.75f, 4.5f);
            GetComponent<SpriteRenderer>().flipX = true;

        }
    }
    private void MoveDownRight()
    {
        if (!IsOnGround)
        {
            return;
        }
        if (Input.GetKeyDown("right") || Input.GetKeyDown("[6]"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0.80f, 2.0f);
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    private void MoveDownLeft()
    {
        if (!IsOnGround)
        {
            return;
        }
        if (Input.GetKeyDown("down") || Input.GetKeyDown("[2]"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-0.75f, 2.0f);
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void Reset()
    {
        if (Input.GetKeyDown("r"))
        {
            transform.position = new Vector3(-1.0f, 3.0f, -5.224f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(collision.gameObject.tag == "RedBall") && !(collision.gameObject.tag == "GreenBall") && !(collision.gameObject.tag == "Coily") && !(collision.gameObject.tag == "Elevator"))
        {
            Vector3 Offset = new Vector3(0.0f, collision.gameObject.GetComponent<BoxCollider2D>().size.y, 0.0f);
            transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, transform.position.z) + (Offset * 2);
            IsOnGround = true;
            collision.gameObject.transform.parent.gameObject.GetComponent<SpriteRenderer>().sprite = changeSprite;
            TileOn = collision.gameObject.transform;
        }
        if (collision.gameObject.tag == "Elevator")
        {
            onElavator = true;
            elevator = collision.gameObject;
        }

        //if (collision.gameObject.tag == "RedBall" || collision.gameObject.tag == "GreenBall" || collision.gameObject.tag == "Coily")
        //{
        //    Lifes--;
        //    if (Lifes == 0)
        //    {
        //        Destroy(this.gameObject);
        //    }
        //}
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!(collision.gameObject.tag == "RedBall") && !(collision.gameObject.tag == "GreenBall") && !(collision.gameObject.tag == "Coily"))
        {
            IsOnGround = false;
        }
    }
}
