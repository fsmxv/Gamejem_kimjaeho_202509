using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject poopPrefab;
    public GameObject itemPrefab;
    public float spawnInterval = 1f;
    private float spawnTimer = 0f;

    public UIManager uiManager;
    private int score = 0;
    public bool isGameOver = false;

    // <<< �߰��� �κ� ���� >>>
    [Header("Spawn Settings")] // Inspector â���� ���� ���� ����� �߰�
    public float spawnXMin = -10f; // ������ X��ǥ�� �ּڰ�
    public float spawnXMax = 10f;  // ������ X��ǥ�� �ִ�
    public float spawnY = 15f;     // ������ Y��ǥ (����)
    // <<< �߰��� �κ� �� >>>


    void Start()
    {
        isGameOver = false;
        Time.timeScale = 1f;
        score = 0;
        uiManager.UpdateScore(score);
    }

    void Update()
    {
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
        // <<< ������ �κ� ���� >>>
        // ������ ���� ������ X��ǥ�� �������� ����
        float randomX = Random.Range(spawnXMin, spawnXMax);
        // ������ ���̿��� �����ǵ��� Y��ǥ�� ���
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);
        // <<< ������ �κ� �� >>>

        if (Random.Range(0, 10) < 7)
        {
            Instantiate(poopPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Instantiate(itemPrefab, spawnPosition, Quaternion.identity);
        }
    }

    public void AddScore()
    {
        score += 10;
        uiManager.UpdateScore(score);
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        uiManager.ShowGameOverUI(score);
    }
}