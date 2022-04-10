using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coily : MonoBehaviour
{
    private bool IsOnGround = false;
    private bool CoilyHatched = false;
    private GameObject player;

    [SerializeField]
    private Sprite CoilySprite;

    [SerializeField]
    private AudioClip Jumping;

    [SerializeField]
    private AudioClip SlimeJumping;

    [SerializeField]
    private AudioSource SFX;

    private Transform playerTileTransform;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            playerTileTransform = player.GetComponent<PlayerMovement>().TileOn.transform;
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerTileTransform = player.GetComponent<PlayerMovement>().TileOn.transform;
        }
        if (!CoilyHatched)
        {
            if (Random.value >= 0.5)
            {
                MoveDownLeft();
            }
            else
            {
                MoveDownRight();
            }
        }
        if (transform.position.y <= -6.0f)
        {
            Destroy(gameObject);
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
        if (!CoilyHatched)
        {
            SFX.clip = SlimeJumping;
        }
        else
        {
            SFX.clip = Jumping;
        }
        SFX.Play();

    }
    private void MoveUpLeft()
    {
        if (!IsOnGround)
        {
            return;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(-0.80f, 4.5f);
        GetComponent<SpriteRenderer>().flipX = true;
        if (!CoilyHatched)
        {
            SFX.clip = SlimeJumping;
        }
        else
        {
            SFX.clip = Jumping;
        }
        SFX.Play();
    }
    private void MoveDownRight()
    {
        if (!IsOnGround)
        {
            return;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(0.80f, 2.0f);
        GetComponent<SpriteRenderer>().flipX = false;
        if (!CoilyHatched)
        {
            SFX.clip = SlimeJumping;
        }
        else
        {
            SFX.clip = Jumping;
        }
        SFX.Play();
    }
    private void MoveDownLeft()
    {
        if (!IsOnGround)
        {
            return;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(-0.80f, 2.0f);
        GetComponent<SpriteRenderer>().flipX = true;
        if (!CoilyHatched)
        {
            SFX.clip = SlimeJumping;
        }
        else
        {
            SFX.clip = Jumping;
        }
        SFX.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Elevator").Length; i++)
        {
            Physics2D.IgnoreCollision(GameObject.FindGameObjectsWithTag("Elevator")[i].gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
        }
        if (!(collision.gameObject.tag == "RedBall" || collision.gameObject.tag == "GreenBall" || collision.gameObject.tag == "Coily" || collision.gameObject.tag == "Elevator"))
        {
            if (collision.gameObject.transform.parent != null)
            {
                if (collision.gameObject.transform.parent.tag == "BottomTile" || collision.gameObject.transform.parent.tag == "LeftCornerTile" || collision.gameObject.transform.parent.tag == "RightCornerTile")
                {
                    CoilyHatched = true;
                    GetComponent<SpriteRenderer>().sprite = CoilySprite;
                }
            }
            Vector3 Offset = new Vector3(0.0f, collision.gameObject.GetComponent<BoxCollider2D>().size.y / 2, 0.0f);
            transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, transform.position.z) + (Offset * 2);
            IsOnGround = true;
        }
        else
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>(), true);
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
