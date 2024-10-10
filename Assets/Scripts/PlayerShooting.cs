using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject prefab;
    public GameObject shootPoint;
    public float bulletLifeTime = 1f; // 총알이 파괴되기까지의 시간
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // 총알 생성
            GameObject bullet = Instantiate(prefab, shootPoint.transform.position, shootPoint.transform.rotation);

            // 1초 뒤에 총알 파괴
            Destroy(bullet, bulletLifeTime);
        }
        

    }
}
