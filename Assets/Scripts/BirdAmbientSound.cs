using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAmbientSound : MonoBehaviour
{
    public AudioClip[] birdSounds; // 10개의 새 소리를 넣을 배열
    private AudioSource audioSource;

    public float minDelay = 3f; // 최소 지연 시간
    public float maxDelay = 8f; // 최대 지연 시간

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // AudioSource 추가
        audioSource.playOnAwake = false; // 시작 시 자동 재생 비활성화
        StartCoroutine(PlayRandomBirdSounds());
    }

    IEnumerator PlayRandomBirdSounds()
    {
        while (true) // 무한 반복
        {
            // 랜덤 시간 딜레이
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            // 랜덤 새 소리 재생
            AudioClip randomClip = birdSounds[Random.Range(0, birdSounds.Length)];
            audioSource.clip = randomClip;
            audioSource.Play();
        }
    }
}
