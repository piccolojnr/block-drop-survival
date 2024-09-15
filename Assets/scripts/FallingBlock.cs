using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public bool InFrame { get; private set; } = true;

    void Update()
    {
        float currentSpeed = GlobalSpeedManager.fallingBlockSpeed * GlobalSpeedManager.blockSpeedModifier;
        transform.Translate(currentSpeed * Time.deltaTime * Vector2.down);

        if (transform.position.y < -10f)
        {
            InFrame = false;
        }
    }
}
