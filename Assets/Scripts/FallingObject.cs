using UnityEngine;

public class FallingObject : MonoBehaviour
{
    // 이 오브젝트가 똥인지 여부 (true면 똥, false면 아이템)
    public bool isPoop = true;
    // GameManager 인스턴스 참조 변수
    private GameManager gameManager;

    // 시작 시 호출되는 함수
    void Start()
    {
        // 씬에 있는 GameManager 오브젝트를 찾아 자동으로 연결
        gameManager = FindObjectOfType<GameManager>();
    }

    // 다른 콜라이더와 충돌 시 호출되는 함수
    private void OnCollisionEnter(Collision collision)
    {
        // 플레이어와 부딪혔을 때의 로직
        if (collision.gameObject.CompareTag("Player"))
        {
            // 똥이면 게임 오버 처리
            if (isPoop)
            {
                gameManager.GameOver();
            }
            // 아이템이면 점수 추가
            else
            {
                gameManager.AddScore();
            }
            // 플레이어와 닿으면 무조건 사라짐
            Destroy(gameObject);
        }
        // <<< 추가된 부분 시작 >>>
        // 바닥과 부딪혔을 때의 로직
        else if (collision.gameObject.CompareTag("Floor"))
        {
            // 그냥 사라지기만 함
            Destroy(gameObject);
        }
        // <<< 추가된 부분 끝 >>>
    }
}