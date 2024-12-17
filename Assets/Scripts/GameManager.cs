using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerMove player;

    private bool isGameOver = false; // 씬 전환 상태를 체크하는 플래그

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // 게임이 종료되지 않은 상태에서만 검사
        if (!isGameOver && player.deathCount <= 0)
        {
            isGameOver = true; // 게임 오버 상태로 설정
            Debug.Log("게임에서 패배하였습니다!");
            SceneManager.LoadScene("LoseScene"); // LoseScene 로드
        }
    }
}
