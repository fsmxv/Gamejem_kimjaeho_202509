using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // �� ������ ���� �� �ʿ��մϴ�!

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

    // <<< �߰��� �κ� ���� >>>
    // Replay ��ư�� ������ ȣ��� �Լ�
    public void OnReplayButtonClicked()
    {
        // ���� Ȱ��ȭ�� ���� �ٽ� �ε��մϴ�.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // <<< �߰��� �κ� �� >>>
}