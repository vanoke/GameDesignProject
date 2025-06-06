using UnityEngine;

public class DayNight : MonoBehaviour
{
    public Light directionalLight;    // ����, ������� ����� ������ �����������
    public float rotationSpeed = 10f; // �������� �������� �����

    void Update()
    {
        // ������� ���� �� ��� �, ����� ������������ �������� ������
        directionalLight.transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}
