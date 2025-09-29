using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject poopPrefab;
    public GameObject itemPrefab;
    public float spawnInterval = 1f;
    private float spawnTimer = 0f;

    public UIManager uiManager; // UIManager 스크립트를 연결할 변수
    private int score = 0;
    public bool isGameOver = false; // 게임 오버 상태를 저장할 변수

    void Start()
    {
        isGameOver = false; // 게임 시작 시 초기화
        Time.timeScale = 1f;  // 게임 시간을 정상 속도로 설정 (재시작을 위해)
        score = 0;
        uiManager.UpdateScore(score); // 점수 UI 초기화
    }

    void Update()
    {
        // 게임 오버 상태라면 아무것도 실행하지 않음
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

    // 점수를 추가하는 함수
    public void AddScore()
    {
        score += 10;
        uiManager.UpdateScore(score);
    }

    // 게임 오버 처리 함수
    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f; // 게임 시간을 멈춤
        uiManager.ShowGameOverUI(score);
    }
}