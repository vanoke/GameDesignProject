using UnityEngine;

public class DayNight : MonoBehaviour
{
    public Light directionalLight;    // Свет, который будет менять направление
    public float rotationSpeed = 10f; // Скорость вращения света

    void Update()
    {
        // Вращаем свет по оси Х, чтобы симулировать движение солнца
        directionalLight.transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}
