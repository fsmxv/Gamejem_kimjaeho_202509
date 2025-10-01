using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // 씬 관리를 위해 꼭 필요합니다!

public class UIManager : MonoBehaviour
{
    // 점수 표시용 텍스트
    public TextMeshProUGUI scoreText;
    // 게임 오버 패널 오브젝트
    public GameObject gameOverPanel;
    // 최종 점수 표시용 텍스트
    public TextMeshProUGUI finalScoreText;

    // 시작 시 호출되는 함수
    void Start()
    {
        // 게임 오버 패널을 비활성화
        gameOverPanel.SetActive(false);
    }

    // 점수 UI를 갱신하는 함수
    public void UpdateScore(int score)
    {
        // 현재 점수를 텍스트로 표시
        scoreText.text = "Score: " + score;
    }

    // 게임 오버 UI를 표시하는 함수
    public void ShowGameOverUI(int score)
    {
        // 게임 오버 패널 활성화
        gameOverPanel.SetActive(true);
        // 최종 점수 표시
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