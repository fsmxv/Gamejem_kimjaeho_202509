using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // �� ������ ���� �� �ʿ��մϴ�!

public class UIManager : MonoBehaviour
{
    // ���� ǥ�ÿ� �ؽ�Ʈ
    public TextMeshProUGUI scoreText;
    // ���� ���� �г� ������Ʈ
    public GameObject gameOverPanel;
    // ���� ���� ǥ�ÿ� �ؽ�Ʈ
    public TextMeshProUGUI finalScoreText;

    // ���� �� ȣ��Ǵ� �Լ�
    void Start()
    {
        // ���� ���� �г��� ��Ȱ��ȭ
        gameOverPanel.SetActive(false);
    }

    // ���� UI�� �����ϴ� �Լ�
    public void UpdateScore(int score)
    {
        // ���� ������ �ؽ�Ʈ�� ǥ��
        scoreText.text = "Score: " + score;
    }

    // ���� ���� UI�� ǥ���ϴ� �Լ�
    public void ShowGameOverUI(int score)
    {
        // ���� ���� �г� Ȱ��ȭ
        gameOverPanel.SetActive(true);
        // ���� ���� ǥ��
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