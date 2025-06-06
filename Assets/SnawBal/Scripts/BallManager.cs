using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallManager : MonoBehaviour
{
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Ground"))
        {

            // ������� ��������� ���� �� X, ���� ��������
            RigidbodyConstraints2D current = _rb.constraints;

            // ���� ��������� �� X ���� �������� � �������� ����
            if ((current & RigidbodyConstraints2D.FreezePositionX) == RigidbodyConstraints2D.FreezePositionX)
            {
                _rb.constraints = current & ~RigidbodyConstraints2D.FreezePositionX;
                Debug.Log("X-�ovement unlocked due to collision with: " + collision.collider.name);
            }
        }
    }
}
