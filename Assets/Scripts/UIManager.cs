using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // 씬 관리를 위해 꼭 필요합니다!

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;

    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void ShowGameOverUI(int score)
    {
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Final Score: " + score;
    }

    // <<< 추가된 부분 시작 >>>
    // Replay 버튼을 누르면 호출될 함수
    public void OnReplayButtonClicked()
    {
        // 현재 활성화된 씬을 다시 로드합니다.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // <<< 추가된 부분 끝 >>>
}