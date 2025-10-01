using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 똥 프리팹 오브젝트
    public GameObject poopPrefab;
    // 아이템 프리팹 오브젝트
    public GameObject itemPrefab;
    // 오브젝트 생성 간격(초)
    public float spawnInterval = 1f;
    // 생성 타이머
    private float spawnTimer = 0f;

    // UI 매니저 참조
    public UIManager uiManager;
    // 현재 점수
    private int score = 0;
    // 게임 오버 상태 여부
    public bool isGameOver = false;

    // <<< 추가된 부분 시작 >>>
    [Header("Spawn Settings")] // Inspector 창에서 보기 좋게 헤더를 추가
    public float spawnXMin = -10f; // 생성될 X좌표의 최솟값
    public float spawnXMax = 10f;  // 생성될 X좌표의 최댓값
    public float spawnY = 15f;     // 생성될 Y좌표 (높이)
    // <<< 추가된 부분 끝 >>>

    [Header("Audio Clips")]
    public AudioClip hitSound;   // 똥에 맞았을 때 재생할 오디오 클립
    public AudioClip scoreSound; // 아이템을 먹었을 때 재생할 오디오 클립

    // 효과음을 재생할 AudioSource 컴포넌트
    private AudioSource audioSource;


    // 게임 시작 시 호출되는 함수
    void Start()
    {
        isGameOver = false; // 게임 오버 상태 초기화
        Time.timeScale = 1f; // 시간 흐름 정상화
        score = 0; // 점수 초기화
        uiManager.UpdateScore(score); // UI에 점수 표시

        // GameManager 오브젝트에 있는 AudioSource 컴포넌트를 가져옴
        audioSource = GetComponent<AudioSource>();
    }

    // 매 프레임마다 호출되는 함수
    void Update()
    {
        // 게임 오버 상태면 아무것도 하지 않음
        if (isGameOver)
        {
            return;
        }

        // 타이머에 프레임 시간 누적
        spawnTimer += Time.deltaTime;
        // 생성 간격이 지나면 오브젝트 생성
        if (spawnTimer >= spawnInterval)
        {
            SpawnObject(); // 오브젝트 생성 함수 호출
            spawnTimer = 0f; // 타이머 초기화
        }
    }

    // 오브젝트(똥 또는 아이템) 생성 함수
    void SpawnObject()
    {
        // <<< 수정된 부분 시작 >>>
        // 설정된 범위 내에서 X좌표를 랜덤으로 정함
        float randomX = Random.Range(spawnXMin, spawnXMax);
        // 설정된 높이에서 생성되도록 Y좌표를 사용
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);
        // <<< 수정된 부분 끝 >>>

        // 70% 확률로 똥, 30% 확률로 아이템 생성
        if (Random.Range(0, 10) < 7)
        {
            Instantiate(poopPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Instantiate(itemPrefab, spawnPosition, Quaternion.identity);
        }
    }

    // 점수 추가 함수 (아이템 획득 시 호출)
    public void AddScore()
    {
        score += 10; // 점수 증가
        uiManager.UpdateScore(score); // UI에 점수 갱신

        audioSource.PlayOneShot(scoreSound); // 점수 획득 효과음 재생
    }

    // 게임 오버 처리 함수
    public void GameOver()
    {
        isGameOver = true; // 게임 오버 상태로 변경
        Time.timeScale = 0f; // 시간 정지
        uiManager.ShowGameOverUI(score); // 게임 오버 UI 표시
        audioSource.Stop(); // 기존 효과음 정지
        audioSource.PlayOneShot(hitSound); // 게임 오버 효과음 재생
    }
}