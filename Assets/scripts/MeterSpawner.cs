using System;
using UnityEngine;

public class MeterSpawner : MonoBehaviour
{
    public GameObject meterPrefab;
    public float meterSpacing = -32;

    // list of spawned meters
    public Meter[] meters;

    private void Start()
    {
        // create a health meter
        SpawnMeter(MeterType.Health);
    }

    public void SpawnMeter(MeterType type)
    {
        // create a new meter
        GameObject meterObject = Instantiate(meterPrefab, transform);
        Meter meter = meterObject.GetComponent<Meter>();
        meter.type = type;
        meter.Initialize();

        // add the new meter to the list
        Array.Resize(ref meters, meters.Length + 1);
        meters[^1] = meter;

        // position the new meter
        Vector3 position = meter.transform.localPosition;
        position.y = meterSpacing * (meters.Length - 1);
        meter.transform.localPosition = position;
    }

    public void UpdateMeter(MeterType type, float value)
    {
        // find the meter with the specified type
        foreach (Meter meter in meters)
        {
            if (meter.type == type)
            {
                meter.SetValue(value);
                break;
            }
        }
    }

    public void AddToMeter(MeterType type, float value)
    {
        // find the meter with the specified type
        foreach (Meter meter in meters)
        {
            if (meter.type == type)
            {
                meter.AddValue(value);
                break;
            }
        }
    }

    public float GetMeterValue(MeterType type)
    {
        // find the meter with the specified type
        foreach (Meter meter in meters)
        {
            if (meter.type == type)
            {
                return meter.value;
            }
        }
        return 0;
    }

    public void RemoveMeter(MeterType type)
    {
        // find the meter with the specified type
        for (int i = 0; i < meters.Length; i++)
        {
            if (meters[i].type == type)
            {
                // destroy the meter game object
                Destroy(meters[i].gameObject);

                // remove the meter from the list
                for (int j = i; j < meters.Length - 1; j++)
                {
                    meters[j] = meters[j + 1];
                }
                Array.Resize(ref meters, meters.Length - 1);

                // reposition the remaining meters
                for (int j = i; j < meters.Length; j++)
                {
                    Vector3 position = meters[j].transform.localPosition;
                    position.y = meterSpacing * j;
                    meters[j].transform.localPosition = position;
                }

                break;
            }
        }
    }
}