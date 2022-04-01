using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Sprite changeSprite;
    [SerializeField]
    private SpriteRenderer swear;

    public GameObject TileOn;
    private bool IsOnGround = false;

    private bool onElavator = false;
    private GameObject elevator;
    private int Lifes = 3;

    public float DeathTime = 0.0f;

    private bool LeftElevator = true;
    private bool RightElevator = true;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -6.0f)
        {
            Reset();
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            transform.position = new Vector3(-1.0f, 3.0f, -5.224f);
        }
        if (DeathTime > 0.0f)
        {
            DeathTime -= Time.deltaTime;
        }
        else
        {
            DeathTime = 0.0f;
            swear.enabled = false;
            Controller();
            moveWithElavator();
        }
    }

    private void Controller()
    {
        MoveUpRight();
        MoveUpLeft();
        MoveDownRight();
        MoveDownLeft();
    }

    private void moveWithElavator()
    {
        if (elevator != null)
        {
            if (onElavator && elevator.GetComponent<BoxCollider2D>().enabled)
            {
                Vector3 Offset = new Vector3(0.0f, elevator.GetComponent<SpriteRenderer>().size.y / 2, 0.0f);
                transform.position = new Vector3(elevator.transform.position.x, elevator.transform.position.y, transform.position.z) + (Offset * 2);
            }
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
            if ((TileOn.transform.parent.tag == "TopTile" || TileOn.transform.parent.tag == "RightSideTile" || TileOn.transform.parent.tag == "RightCornerTile"))
            {
                if ((RightElevator && (TileOn.transform.parent.name == "Tile (10)")))
                {
                    RightElevator = false;
                }
                else
                {
                    GetComponent<BoxCollider2D>().enabled = false;
                    transform.position = new Vector3(transform.position.x, transform.position.y, TileOn.transform.position.z - 0.5f);
                }
            }
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
            if ((TileOn.transform.parent.tag == "TopTile" || TileOn.transform.parent.tag == "LeftSideTile" || TileOn.transform.parent.tag == "LeftCornerTile"))
            {
                if ((LeftElevator && (TileOn.transform.parent.name == "Tile (14)")))
                {
                    LeftElevator = false;
                }
                else
                {
                    GetComponent<BoxCollider2D>().enabled = false;
                    transform.position = new Vector3(transform.position.x, transform.position.y, TileOn.transform.position.z - 0.5f);
                }
            }
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
            if (TileOn.transform.parent.tag == "BottomTile" || TileOn.transform.parent.tag == "LeftCornerTile" || TileOn.transform.parent.tag == "RightCornerTile")
            {
                GetComponent<BoxCollider2D>().enabled = false;
                transform.position = new Vector3(transform.position.x, transform.position.y, TileOn.transform.position.z - 0.5f);
            }
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
            if (TileOn.transform.parent.tag == "BottomTile" || TileOn.transform.parent.tag == "LeftCornerTile" || TileOn.transform.parent.tag == "RightCornerTile")
            {
                GetComponent<BoxCollider2D>().enabled = false;
                transform.position = new Vector3(transform.position.x, transform.position.y, TileOn.transform.position.z - 0.5f);
            }
            GetComponent<Rigidbody2D>().velocity = new Vector2(-0.75f, 2.0f);
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void Reset()
    {
        DeathTime = 2.0f;
        swear.enabled = true;
        Lifes--;

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("RedBall").Length; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("RedBall")[i]);
        }
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("GreenBall").Length; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("GreenBall")[i]);
        }
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Coily").Length; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("Coily")[i]);
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
            TileOn = collision.gameObject;
        }
        if (collision.gameObject.tag == "Elevator")
        {
            onElavator = true;
            elevator = collision.gameObject;
        }
        else
        {
            elevator = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RedBall" || collision.gameObject.tag == "GreenBall" || collision.gameObject.tag == "Coily")
        {
            Reset();
            if (Lifes == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!(collision.gameObject.tag == "RedBall") && !(collision.gameObject.tag == "GreenBall") && !(collision.gameObject.tag == "Coily"))
        {
            IsOnGround = false;
        }
    }
}
