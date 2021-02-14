using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShot : MonoBehaviour
{
    public float moveSpeed = 20.0f;
    public Transform arrowSpawn;
    public GameObject arrowPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawn.position, arrowSpawn.rotation);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(arrowSpawn.right * moveSpeed, ForceMode2D.Impulse);
    }
}
