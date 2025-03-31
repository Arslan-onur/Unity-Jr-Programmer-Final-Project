using Unity.VisualScripting;
using UnityEngine;

public class StartPlatformController : AllPlatformController
{
    [SerializeField] float startPlatformDownSpeed = .5f;

    // Update is called once per frame
    void Update()
    {
        MovingDown(startPlatformDownSpeed);
        DestroyOnOutOfLimit();
    }
}
