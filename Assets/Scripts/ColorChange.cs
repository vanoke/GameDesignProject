using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Color[] colors;
    private Renderer objRenderer;
    private int currentColorIndex = 0;


    void Start()
    {
        objRenderer = GetComponent<Renderer>();
        InvokeRepeating("ChangeColor", 1f, 1f);
    }

    void ChangeColor()
    {
        currentColorIndex = (currentColorIndex + 1) % colors.Length;
        objRenderer.material.color = colors[currentColorIndex];
    }
}
