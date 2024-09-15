using UnityEngine;

public class GlobalSpeedManager : MonoBehaviour
{
    public static float blockSpeedModifier = 1f; // Default modifier is 1 (normal speed)

    public static float fallingBlockSpeed = 7f; // Default speed of falling blocks

    // Method to change speed (could be called when a power-up is collected)
    public static void SetBlockSpeed(float modifier)
    {
        blockSpeedModifier = modifier;
    }
}
