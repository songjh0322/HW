using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    public AudioClip bgmClip; // 브금 파일
    private AudioSource audioSource;

    void Start()
    {
        // AudioSource 컴포넌트 추가
        audioSource = gameObject.AddComponent<AudioSource>();

        // 설정
        audioSource.clip = bgmClip; // 브금 파일 할당
        audioSource.loop = true;    // 브금 반복 재생
        audioSource.playOnAwake = true; // 씬 시작 시 재생
        audioSource.volume = 0.5f;  // 볼륨 설정 (0~1)

        // 브금 재생
        audioSource.Play();
    }
}