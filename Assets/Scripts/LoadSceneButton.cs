using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    // 이동할 씬의 이름
    public string sceneName = "Ilgamho Lake";

    // 씬을 로드하는 함수
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void MainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    
}