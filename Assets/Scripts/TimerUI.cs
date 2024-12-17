using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerUI : MonoBehaviour
{
    public Text timerText;       // UI Text 컴포넌트
    public float countdownTime = 40f; // 타이머 시작 시간 (40초)
    private float currentTime;

    void Start()
    {
        currentTime = countdownTime; // 초기 시간 설정
    }

    void Update()
    {
        // 시간이 0초보다 클 때만 타이머 감소
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime; // 시간 감소
            timerText.text = "버티세요!: " + Mathf.Ceil(currentTime); // 화면에 시간 표시
        }
        else
        {
            // 시간이 0이 되면 WinScene으로 이동
            LoadWinScene();
        }
    }

    void LoadWinScene()
    {
        SceneManager.LoadScene("WinScene"); // WinScene 씬으로 이동
    }
}