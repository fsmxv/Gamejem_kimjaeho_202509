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

    // <<< 추가된 부분 시작 >>>
    [Header("Spawn Settings")] // Inspector 창에서 보기 좋게 헤더를 추가
    public float spawnXMin = -10f; // 생성될 X좌표의 최솟값
    public float spawnXMax = 10f;  // 생성될 X좌표의 최댓값
    public float spawnY = 15f;     // 생성될 Y좌표 (높이)
    // <<< 추가된 부분 끝 >>>


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
        // <<< 수정된 부분 시작 >>>
        // 설정된 범위 내에서 X좌표를 랜덤으로 정함
        float randomX = Random.Range(spawnXMin, spawnXMax);
        // 설정된 높이에서 생성되도록 Y좌표를 사용
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);
        // <<< 수정된 부분 끝 >>>

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