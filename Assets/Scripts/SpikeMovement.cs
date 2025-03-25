using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    Platform3Controller platform3Controller;

    float moveSpeedSpike = 2f;

 // Hareket hızı
    float maxDistance = 0.7f; // Maksimum hareket mesafesi
    Vector3 startPosition; // Başlangıç pozisyonu

    void Start()
    {
        platform3Controller = GetComponentInParent<Platform3Controller>();
        startPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (platform3Controller.isPlayerTouch == true)
        {
            // Ne kadar hareket ettiğimizi hesapla
            float movedDistance = Vector3.Distance(startPosition, transform.localPosition);

            if (movedDistance < maxDistance)
            {
                transform.localPosition += Vector3.up * 20f * Time.deltaTime;
            }
            else
            {
                // Maksimum mesafeye ulaşıldı, hareketi durdur
                transform.localPosition = startPosition + Vector3.up * maxDistance;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {   
            Destroy(other.gameObject);
        }
    }
}
