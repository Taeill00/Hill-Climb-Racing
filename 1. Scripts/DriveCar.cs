using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCar : MonoBehaviour
{
    [SerializeField] private Collider2D headCollider;

    [SerializeField] private Rigidbody2D frontTireRB;
    [SerializeField] private Rigidbody2D backTireRB;
    [SerializeField] private Rigidbody2D carRB;

    [SerializeField] private float speed = 150f;
    [SerializeField] private float rotationSpeed = 300f;

    [SerializeField] private GameManager gameManager;

    public Vector2 startPos;

    private float moveInput;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        GameManager.Instance.distance = Vector2.Distance(transform.position, startPos);

        if (moveInput != 0)
        {
            GameManager.Instance.curFuel -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        // + torque => �ݽð���� - torque => �ð����
        frontTireRB.AddTorque(-moveInput * speed * Time.fixedDeltaTime);
        backTireRB.AddTorque(-moveInput* speed * Time.fixedDeltaTime);

        // ��ü�� ȸ���� �ְ�. +���� �ݽð� -���� �ð�
        carRB.AddTorque(moveInput * rotationSpeed * Time.fixedDeltaTime);

    }
}
