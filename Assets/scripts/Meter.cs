using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum MeterType
{
    Health,
    Shield,
    Dash,
    SlowMotion,
}

public class Meter : MonoBehaviour
{
    public float value = 1.0f;
    public float minValue = 0.0f;
    public float maxValue = 1.0f;

    public Transform meterBar;
    public TextMeshProUGUI titleText;
    public Image fillImage;

    public MeterType type = MeterType.Health;

    static Color healthColor = new(0.8f, 0.1f, 0.1f);
    static Color shieldColor = new(0.1f, 0.1f, 0.8f);
    static Color dashColor = new(0.1f, 0.8f, 0.1f);
    static Color slowMotionColor = new(0.8f, 0.8f, 0.1f);


    public void Initialize()
    {
        switch (type)
        {
            case MeterType.Health:
                titleText.text = "Health";
                fillImage.color = healthColor;
                break;
            case MeterType.Shield:
                titleText.text = "Shield";
                fillImage.color = shieldColor;
                break;
            case MeterType.Dash:
                titleText.text = "Dash";
                fillImage.color = dashColor;
                break;
            case MeterType.SlowMotion:
                titleText.text = "Slow Motion";
                fillImage.color = slowMotionColor;
                break;
        }
        UpdateMeterBar();
    }

    public void SetValue(float value)
    {
        this.value = Mathf.Clamp(value, minValue, maxValue);
        UpdateMeterBar();
    }

    public void AddValue(float value)
    {
        SetValue(this.value + value);
    }

    public void SubtractValue(float value)
    {
        SetValue(this.value - value);
    }

    public void UpdateMeterBar()
    {
        float meterPercentage = (value - minValue) / (maxValue - minValue);
        meterBar.localScale = new Vector3(meterPercentage, 1, 1);
    }
}

