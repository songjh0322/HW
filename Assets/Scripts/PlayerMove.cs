using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 20f;
    public float rotationSpeed = 40f;
    public float teleportDistance = 10f; // 순간이동할 거리
    public float jumpHeight = 5f; // Space바로 올라갈 높이
    public int deathCount = 10;

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

        // Shift바 입력시 플레이어가 보고 있는 방향으로 순간이동
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Vector3 teleportDirection = transform.forward * teleportDistance; // 플레이어가 보고 있는 방향
            transform.position += teleportDirection; // 해당 방향으로 순간이동
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(0, jumpHeight, 0); // y축으로 이동
        }
    }

    // 적과 충돌 시 호출되는 메서드
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            deathCount--;  // count 증가
            Debug.Log("피격! 남은 목숨 " + deathCount);

            // 적 오브젝트 파괴
            Destroy(other.gameObject);
            

        }
    }
}
