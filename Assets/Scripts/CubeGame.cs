using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameScript : MonoBehaviour
{
    public GameObject Cube1;
    public GameObject Cube2;
    public GameObject Cube3;
    public Button Button1;
    public Button Button2;
    public Button Button3;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI TextScene;

    private GameObject[] cubes;
    private int correctCubeIndex;

    void Start()
    {
        // Инициализация массива кубов
        cubes = new GameObject[] { Cube1, Cube2, Cube3 };

        // Случайно выбираем, какой куб не упадёт
        correctCubeIndex = Random.Range(0, 3);
        resultText.gameObject.SetActive(false);
        TextScene.text = "Guess the Cube";

        // Назначаем обработчики кнопок
        Button1.onClick.AddListener(() => OnCubeSelected(0));
        Button2.onClick.AddListener(() => OnCubeSelected(1));
        Button3.onClick.AddListener(() => OnCubeSelected(2));

        // Переименовываем кнопки для ясности
        Button1.GetComponentInChildren<TextMeshProUGUI>().text = "Куб 1";
        Button2.GetComponentInChildren<TextMeshProUGUI>().text = "Куб 2";
        Button3.GetComponentInChildren<TextMeshProUGUI>().text = "Куб 3";
    }

    void OnCubeSelected(int selectedIndex)
    {
        // Делаем все кубы динамическими (могут падать)
        foreach (var cube in cubes)
        {
            Rigidbody rb = cube.GetComponent<Rigidbody>();
            if (rb == null) rb = cube.AddComponent<Rigidbody>();
            rb.isKinematic = false;
        }

        // "Правильный" куб остаётся на месте
        cubes[correctCubeIndex].GetComponent<Rigidbody>().isKinematic = true;

        // Проверка победы
        if (selectedIndex == correctCubeIndex)
        {
            resultText.text = "YOU WIN!";
        }
        else
        {
            resultText.text = "TRY AGAIN!";
        }

        resultText.gameObject.SetActive(true);

        // Блокируем кнопки после выбора
        Button1.interactable = false;
        Button2.interactable = false;
        Button3.interactable = false;
    }
}