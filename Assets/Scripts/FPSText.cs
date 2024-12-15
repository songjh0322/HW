using UnityEngine;
using UnityEngine.UI;

public class FPSText : MonoBehaviour
{
    public Text fpsText; // FPS를 표시할 UI Text
    private float deltaTime = 0.0f;

    void Update()
    {
        // Time.unscaledDeltaTime 사용 (일시정지 영향 X)
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;

        // 화면에 표시
        fpsText.text = $"FPS: {Mathf.Ceil(fps)}";
    }
}
