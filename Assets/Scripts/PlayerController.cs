using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �÷��̾� �̵� �ӵ�
    public float moveSpeed = 10f;
    // GameManager �ν��Ͻ� ���� ����
    private GameManager gameManager; 

    
    void Start()
    {
        // ���� �ִ� GameManager ������Ʈ�� ã�� �ڵ����� ����
        gameManager = FindObjectOfType<GameManager>();
    }

   
    void Update()
    {
        // ���� ���� �����̸� ���� �Ұ�
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