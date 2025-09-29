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
        // �÷��̾�� �ε����� ���� ����
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
            Destroy(gameObject); // �÷��̾�� ������ ������ �����
        }
        // <<< �߰��� �κ� ���� >>>
        // �ٴڰ� �ε����� ���� ����
        else if (collision.gameObject.CompareTag("Floor"))
        {
            // �׳� ������⸸ ��
            Destroy(gameObject);
        }
        // <<< �߰��� �κ� �� >>>
    }
}