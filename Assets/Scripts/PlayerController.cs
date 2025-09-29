using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    private GameManager gameManager; // 게임 매니저 변수 추가

    void Start()
    {
        // 씬에 있는 GameManager 오브젝트를 찾아 자동으로 연결
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        // 게임 오버 상태이면 조작 불가
        if (gameManager.isGameOver) return;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }
}