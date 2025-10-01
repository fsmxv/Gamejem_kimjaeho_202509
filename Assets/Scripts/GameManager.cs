using UnityEngine;

public class GameManager : MonoBehaviour
{
    // �� ������ ������Ʈ
    public GameObject poopPrefab;
    // ������ ������ ������Ʈ
    public GameObject itemPrefab;
    // ������Ʈ ���� ����(��)
    public float spawnInterval = 1f;
    // ���� Ÿ�̸�
    private float spawnTimer = 0f;

    // UI �Ŵ��� ����
    public UIManager uiManager;
    // ���� ����
    private int score = 0;
    // ���� ���� ���� ����
    public bool isGameOver = false;

    // <<< �߰��� �κ� ���� >>>
    [Header("Spawn Settings")] // Inspector â���� ���� ���� ����� �߰�
    public float spawnXMin = -10f; // ������ X��ǥ�� �ּڰ�
    public float spawnXMax = 10f;  // ������ X��ǥ�� �ִ�
    public float spawnY = 15f;     // ������ Y��ǥ (����)
    // <<< �߰��� �κ� �� >>>

    [Header("Audio Clips")]
    public AudioClip hitSound;   // �˿� �¾��� �� ����� ����� Ŭ��
    public AudioClip scoreSound; // �������� �Ծ��� �� ����� ����� Ŭ��

    // ȿ������ ����� AudioSource ������Ʈ
    private AudioSource audioSource;


    // ���� ���� �� ȣ��Ǵ� �Լ�
    void Start()
    {
        isGameOver = false; // ���� ���� ���� �ʱ�ȭ
        Time.timeScale = 1f; // �ð� �帧 ����ȭ
        score = 0; // ���� �ʱ�ȭ
        uiManager.UpdateScore(score); // UI�� ���� ǥ��

        // GameManager ������Ʈ�� �ִ� AudioSource ������Ʈ�� ������
        audioSource = GetComponent<AudioSource>();
    }

    // �� �����Ӹ��� ȣ��Ǵ� �Լ�
    void Update()
    {
        // ���� ���� ���¸� �ƹ��͵� ���� ����
        if (isGameOver)
        {
            return;
        }

        // Ÿ�̸ӿ� ������ �ð� ����
        spawnTimer += Time.deltaTime;
        // ���� ������ ������ ������Ʈ ����
        if (spawnTimer >= spawnInterval)
        {
            SpawnObject(); // ������Ʈ ���� �Լ� ȣ��
            spawnTimer = 0f; // Ÿ�̸� �ʱ�ȭ
        }
    }

    // ������Ʈ(�� �Ǵ� ������) ���� �Լ�
    void SpawnObject()
    {
        // <<< ������ �κ� ���� >>>
        // ������ ���� ������ X��ǥ�� �������� ����
        float randomX = Random.Range(spawnXMin, spawnXMax);
        // ������ ���̿��� �����ǵ��� Y��ǥ�� ���
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);
        // <<< ������ �κ� �� >>>

        // 70% Ȯ���� ��, 30% Ȯ���� ������ ����
        if (Random.Range(0, 10) < 7)
        {
            Instantiate(poopPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Instantiate(itemPrefab, spawnPosition, Quaternion.identity);
        }
    }

    // ���� �߰� �Լ� (������ ȹ�� �� ȣ��)
    public void AddScore()
    {
        score += 10; // ���� ����
        uiManager.UpdateScore(score); // UI�� ���� ����

        audioSource.PlayOneShot(scoreSound); // ���� ȹ�� ȿ���� ���
    }

    // ���� ���� ó�� �Լ�
    public void GameOver()
    {
        isGameOver = true; // ���� ���� ���·� ����
        Time.timeScale = 0f; // �ð� ����
        uiManager.ShowGameOverUI(score); // ���� ���� UI ǥ��
        audioSource.Stop(); // ���� ȿ���� ����
        audioSource.PlayOneShot(hitSound); // ���� ���� ȿ���� ���
    }
}