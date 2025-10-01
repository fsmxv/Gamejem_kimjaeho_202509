using UnityEngine;

public class FallingObject : MonoBehaviour
{
    // �� ������Ʈ�� ������ ���� (true�� ��, false�� ������)
    public bool isPoop = true;
    // GameManager �ν��Ͻ� ���� ����
    private GameManager gameManager;

    // ���� �� ȣ��Ǵ� �Լ�
    void Start()
    {
        // ���� �ִ� GameManager ������Ʈ�� ã�� �ڵ����� ����
        gameManager = FindObjectOfType<GameManager>();
    }

    // �ٸ� �ݶ��̴��� �浹 �� ȣ��Ǵ� �Լ�
    private void OnCollisionEnter(Collision collision)
    {
        // �÷��̾�� �ε����� ���� ����
        if (collision.gameObject.CompareTag("Player"))
        {
            // ���̸� ���� ���� ó��
            if (isPoop)
            {
                gameManager.GameOver();
            }
            // �������̸� ���� �߰�
            else
            {
                gameManager.AddScore();
            }
            // �÷��̾�� ������ ������ �����
            Destroy(gameObject);
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