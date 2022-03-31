using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public bool move = false;
    [SerializeField]
    Transform GoTo;

    [SerializeField]
    private bool IsLeft = true;

    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
       
       direction = transform.position - GoTo.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLeft)
        {
            if (move)
            {
                if (!(transform.position.x >= GoTo.position.x))
                {
                    transform.position += -direction * Time.deltaTime;
                }
                else
                {
                    GetComponent<BoxCollider2D>().enabled = false;
                    transform.position += Vector3.up * Time.deltaTime;
                }
            }
        }
        else
        {
            if (move)
            {
                if (!(transform.position.x <= GoTo.position.x))
                {
                    transform.position += -direction * Time.deltaTime;
                }
                else
                {
                    GetComponent<BoxCollider2D>().enabled = false;
                    transform.position += Vector3.up * Time.deltaTime;
                }
            }
        }

        if (transform.position.y >= 6.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            move = true;
        }
    }
}
