using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBall : MonoBehaviour
{
    private bool IsOnGround = false;

    [SerializeField]
    private AudioClip Jumping;

    [SerializeField]
    private AudioSource SFX;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.value >= 0.5)
        {
            MoveDownLeft();
        }
        else
        {
            MoveDownRight();
        }
        if (transform.position.y <= -6.0f)
        {
            Destroy(gameObject);
        }
    }

    private void MoveDownRight()
    {
        if (!IsOnGround)
        {
            return;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(0.80f, 2.0f);
        SFX.clip = Jumping;
        SFX.Play();
    }
    private void MoveDownLeft()
    {
        if (!IsOnGround)
        {
            return;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(-0.80f, 2.0f);
        SFX.clip = Jumping;
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
