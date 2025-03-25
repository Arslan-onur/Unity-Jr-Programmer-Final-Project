using UnityEngine;

public class Platform3Controller : MonoBehaviour
{
    public Material targetMaterial;
    public Color startColor = Color.white;
    public Color endColor = Color.red;
    public float duration = 1f;
    public bool isPlayerTouch = false;
    private float elapsedTime = 0f;

    void Start()
    {
        targetMaterial.color = startColor; // Başlangıç rengini ayarla
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ChangeColor();
        }
    }

    private void ChangeColor()
    {
        if (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration; // 0 ile 1 arasında değer üret
            targetMaterial.color = Color.Lerp(startColor, endColor, t);
        }
        if (elapsedTime > duration)
        {
            isPlayerTouch = true;
        }
    }
}
