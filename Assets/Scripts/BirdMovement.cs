using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public float speed = 2f; // 이동 속도
    private Vector3 randomDirection; // 랜덤 방향

    // Start is called before the first frame update
    void Start()
    {
        // 랜덤한 방향을 설정 (XY 평면에서만 이동하도록 Y는 0으로 고정)
        randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        // 랜덤한 방향으로 계속 이동
        transform.position += randomDirection * speed * Time.deltaTime;
    }
}
