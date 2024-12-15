using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel; // Pause창 Panel 오브젝트
    private bool isPaused = false;

    void Update()
    {
        // ESC 키 입력 감지
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    // 게임 일시정지
    public void PauseGame()
    {
        isPaused = true;
        pausePanel.SetActive(true); // Pause창 활성화
        Time.timeScale = 0f; // 게임 일시정지
    }

    // 게임 재개
    public void ResumeGame()
    {
        isPaused = false;
        pausePanel.SetActive(false); // Pause창 비활성화
        Time.timeScale = 1f; // 게임 재개
    }

    // 메인화면 이동
    public void ExitToMainMenu()
    {
        Time.timeScale = 1f; // 게임 시간 재개
        SceneManager.LoadScene("MainMenu"); // 메인 메뉴 씬 이름을 사용
    }
}
