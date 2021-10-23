using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform plyaerPos;

    [SerializeField]
    private float offSetX = -1.385f;

    private Vector3 tempPos;

    private void Awake()
    {
        FIndPlayer();
    }

    private void LateUpdate()
    {
        FollpwPlayer();
    }

    private void FIndPlayer()
    {
        plyaerPos = GameObject.FindWithTag("Player").transform;
    }

    private void FollpwPlayer()
    {
        if (plyaerPos)
        {
            tempPos = transform.position;
            tempPos.x = plyaerPos.position.x - offSetX;
            transform.position = tempPos;
        }
    }
}
