using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public bool isPoop = true;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 플레이어와 부딪혔을 때의 로직
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isPoop)
            {
                gameManager.GameOver();
            }
            else
            {
                gameManager.AddScore();
            }
            Destroy(gameObject); // 플레이어와 닿으면 무조건 사라짐
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