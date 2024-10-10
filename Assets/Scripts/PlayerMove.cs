using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
     public float speed = 20f;
    public float rotationSpeed = 40f;
    public float teleportDistance = 10f; // 순간이동할 거리

    // Update is called once per frame
    void Update()
    {
        // 이동
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        { transform.Translate(0, 0, speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        { transform.Translate(0, 0, -speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        { transform.Translate(-speed * Time.deltaTime, 0, 0); }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        { transform.Translate(speed * Time.deltaTime, 0, 0); }

        // 마우스 회전
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * rotationSpeed * Time.deltaTime, 0);

        // 스페이스바 입력시 플레이어가 보고 있는 방향으로 순간이동
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 teleportDirection = transform.forward * teleportDistance; // 플레이어가 보고 있는 방향
            transform.position += teleportDirection; // 해당 방향으로 순간이동
        }
    }
}
