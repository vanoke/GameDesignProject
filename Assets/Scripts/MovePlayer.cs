using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 10.0f;
    public float maxSpeed = 5.0f;
    public float rotationSpeed = 240.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Получаем ввод от клавиатуры
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Получаем ввод от мыши
        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.localEulerAngles = new Vector3(0, rotationX, 0);

        // Применяем силу для перемещения в горизонтальной и вертикальной плоскостях
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddRelativeForce(movement * speed);

        // Ограничение скорости чтобы игрок не разгонялся больше значения maxSpeed
        Vector3 clampedVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxSpeed);
        rb.linearVelocity = clampedVelocity;
    }
}

