using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    private GameObject player;
    public float speed = 5f; // 이동 속도
    private Rigidbody rigidbody;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player"); // 태그로 플레이어 오브젝트를 찾음
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized; // 방향 벡터 계산
            rigidbody.AddForce(direction * speed, ForceMode.VelocityChange); // 방향으로 힘을 가함
        }
    }
}
