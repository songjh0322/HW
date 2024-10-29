using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ForwardMovement : MonoBehaviour
{
    public float speed = 100f;
    private int count = 0;

    public GameObject explosionParticle;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    // 적과 충돌 시 호출되는 메서드
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            count++;  // count 증가
            Debug.Log("Enemy 격파!: " + count);

            // 폭발 파티클 생성
            if (explosionParticle != null)
            {
                Instantiate(explosionParticle, other.transform.position, Quaternion.identity);
            }

            // 적 오브젝트 파괴
            Destroy(other.gameObject);

            // 총알도 파괴
            Destroy(gameObject);

        }
    }
}