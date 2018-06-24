using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class SpriteOutline : MonoBehaviour
{
    public Color color = Color.white;
    private Image spriteRenderer;

    void OnEnable()
    {
        spriteRenderer = GetComponent<Image>();

        UpdateOutline(true);
    }

    void OnDisable()
    {
        UpdateOutline(false);
    }

    void Update()
    {
        UpdateOutline(true);
    }

    void UpdateOutline(bool outline)
    {
       
        Material mpb = new Material(Shader.Find("Custom/Sprite Outline"));
        spriteRenderer.material = mpb;
        mpb.SetFloat("_Distance", outline ? 5f : 0f);
        mpb.SetColor("_Color", color);
    }
}
