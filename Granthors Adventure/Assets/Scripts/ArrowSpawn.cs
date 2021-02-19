using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject arrowRightPrefab;
    public GameObject arrowLeftPrefab;

    float arrowRotateAngle;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootArrow();
        }
    }

    void ShootArrow()
    {
        float move_x = GetComponent<PlayerController>().movement.x;
        float move_y = GetComponent<PlayerController>().movement.y;

        var face_x = GetComponent<PlayerController>().animator.GetFloat("HorizontalFace");
        var face_y = GetComponent<PlayerController>().animator.GetFloat("VerticalFace");

        Debug.Log($"Move X: {move_x}, Move Y: {move_y}"); 
        Debug.Log($"Face X: {face_x}, Face Y: {face_y}");

        if (face_x == 1 && face_y == 0) // moving right
        {
            arrowRotateAngle = -180f;
        }
        else if (face_x == -1 && face_y == 0) // moving left
        {
            arrowRotateAngle = 0f;
        }
        else if (face_x == 0 && face_y == 1) // moving up
        {
            arrowRotateAngle = -90f;
        }
        else if (face_x == 0 && face_y == -1) // moving down
        {
            arrowRotateAngle = 90f;
        }
        //else
        //{
        //    arrowRotateAngle = -180f;
        //}

        spawnPoint.rotation = Quaternion.Euler(0f, 0f, arrowRotateAngle);
        Instantiate(arrowLeftPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
