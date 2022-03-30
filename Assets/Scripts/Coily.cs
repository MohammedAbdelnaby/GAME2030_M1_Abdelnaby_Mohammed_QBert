using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coily : MonoBehaviour
{
    private bool IsOnGround = false;
    private bool LeftLane;
    private bool CoilyHatched = false;
    private GameObject player;

    [SerializeField]
    private Sprite CoilySprite;

    private Transform playerTileTransform;
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
        if (player != null)
        {
            playerTileTransform = player.GetComponent<PlayerMovement>().TileOn;
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerTileTransform = player.GetComponent<PlayerMovement>().TileOn;
        }
        if (!CoilyHatched)
        {
            if (LeftLane)
            {
                MoveDownLeft();
            }
            else
            {
                MoveDownRight();
                //Debug.Log(IsOnGround);
            }
        }
    }
    private void MoveUpRight()
    {
        if (!IsOnGround)
        {
            return;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(0.80f, 4.5f);
        GetComponent<SpriteRenderer>().flipX = false;

    }
    private void MoveUpLeft()
    {
        if (!IsOnGround)
        {
            return;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(-0.80f, 4.5f);
        GetComponent<SpriteRenderer>().flipX = true;
    }
    private void MoveDownRight()
    {
        if (!IsOnGround)
        {
            return;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(0.80f, 2.0f);
        GetComponent<SpriteRenderer>().flipX = false;
    }
    private void MoveDownLeft()
    {
        if (!IsOnGround)
        {
            return;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(-0.80f, 2.0f);
        GetComponent<SpriteRenderer>().flipX = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("GreenBall") && !collision.gameObject.CompareTag("RedBall"))
        {
            if (collision.gameObject.transform.parent.tag == "BottomTile" || collision.gameObject.transform.parent.tag == "LeftCornerTile" || collision.gameObject.transform.parent.tag == "RightCornerTile")
            {
                CoilyHatched = true;
                GetComponent<SpriteRenderer>().sprite = CoilySprite;
            }
            Vector3 Offset = new Vector3(0.0f, collision.gameObject.GetComponent<BoxCollider2D>().size.y / 2, 0.0f);
            transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, transform.position.z) + (Offset * 2);
            IsOnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("GreenBall") && !collision.gameObject.CompareTag("RedBall"))
        {
            IsOnGround = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (CoilyHatched)
        {
            if (playerTileTransform.position.x > collision.transform.position.x && playerTileTransform.position.y == collision.transform.position.y)
            {

                MoveUpRight();
            }
            else if (playerTileTransform.position.x < collision.transform.position.x && playerTileTransform.position.y == collision.transform.position.y)
            {
                MoveUpLeft();
            }
            else if(playerTileTransform.position.x == collision.transform.position.x && playerTileTransform.position.y > collision.transform.position.y)
            {
                MoveUpLeft();
            }
            else if (playerTileTransform.position.x == collision.transform.position.x && playerTileTransform.position.y < collision.transform.position.y)
            {
                MoveDownLeft();
            }
            else if (playerTileTransform.position.x > collision.transform.position.x && playerTileTransform.position.y > collision.transform.position.y)
            {
                MoveUpRight();
            }
            else if (playerTileTransform.position.x < collision.transform.position.x && playerTileTransform.position.y > collision.transform.position.y)
            {
                MoveUpLeft();
            }
            else if (playerTileTransform.position.x > collision.transform.position.x && playerTileTransform.position.y < collision.transform.position.y)
            {
                MoveDownRight();
            }
            else if (playerTileTransform.position.x < collision.transform.position.x && playerTileTransform.position.y < collision.transform.position.y)
            {
                MoveDownLeft();
            }
        }
    }
}
