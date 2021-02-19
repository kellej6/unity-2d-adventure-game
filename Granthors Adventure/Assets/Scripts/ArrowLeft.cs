using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLeft : MonoBehaviour
{
    public float speed = 10.0f;
    public new Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody.velocity = transform.right * -1 * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        Destroy(gameObject);
    }
}