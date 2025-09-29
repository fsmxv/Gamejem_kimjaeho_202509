using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject poopPrefab;
    public GameObject itemPrefab;
    public float spawnInterval = 1f;
    private float spawnTimer = 0f;

    public UIManager uiManager; // UIManager ��ũ��Ʈ�� ������ ����
    private int score = 0;
    public bool isGameOver = false; // ���� ���� ���¸� ������ ����

    void Start()
    {
        isGameOver = false; // ���� ���� �� �ʱ�ȭ
        Time.timeScale = 1f;  // ���� �ð��� ���� �ӵ��� ���� (������� ����)
        score = 0;
        uiManager.UpdateScore(score); // ���� UI �ʱ�ȭ
    }

    void Update()
    {
        // ���� ���� ���¶�� �ƹ��͵� �������� ����
        if (isGameOver)
        {
            return;
        }

        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnObject();
            spawnTimer = 0f;
        }
    }

    void SpawnObject()
    {
        float randomX = Random.Range(-10f, 10f);
        Vector3 spawnPosition = new Vector3(randomX, 15f, 0f);

        if (Random.Range(0, 10) < 7)
        {
            Instantiate(poopPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Instantiate(itemPrefab, spawnPosition, Quaternion.identity);
        }
    }

    // ������ �߰��ϴ� �Լ�
    public void AddScore()
    {
        score += 10;
        uiManager.UpdateScore(score);
    }

    // ���� ���� ó�� �Լ�
    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f; // ���� �ð��� ����
        uiManager.ShowGameOverUI(score);
    }
}