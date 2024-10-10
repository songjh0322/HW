using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject prefab;
    public GameObject player; // 플레이어 오브젝트
    public float startTime = 1;
    public float endTime = 5;
    public float spawnRate = 0.5f;
    public float spawnRadius = 5f; // 플레이어 주변에서 생성될 거리 반경
    public float destroyTime = 3.0f; // 생성된 오브젝트가 파괴될 시간

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", startTime, spawnRate);
        Invoke("CancelInvoke", endTime);
    }

    void Spawn()
    {
        // 플레이어 주변의 랜덤 위치 생성
        Vector2 randomPoint = Random.insideUnitCircle * spawnRadius; // 원 안의 랜덤한 점을 선택
        Vector3 spawnPosition = new Vector3(player.transform.position.x + randomPoint.x, player.transform.position.y, player.transform.position.z + randomPoint.y);

        // 프리팹 생성
        GameObject spawnedPrefab = Instantiate(prefab, spawnPosition, Quaternion.identity);

        // 3초 뒤에 파괴
        Destroy(spawnedPrefab, destroyTime);
    }
}
