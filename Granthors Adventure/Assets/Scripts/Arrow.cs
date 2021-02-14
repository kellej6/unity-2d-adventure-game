using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject arrowPrefab;

   void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(arrowPrefab);
    }
}
