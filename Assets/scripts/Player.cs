using System;
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;


    private TimerManager timerManager;

    private Timer shieldTimer;
    private Timer slowMotionTimer;

    public bool IsShielded { get; private set; }

    public float slowFactor = 0.7f;
    private MeterSpawner meterSpawner;



    void Start()
    {
        meterSpawner = FindObjectOfType<MeterSpawner>();
        timerManager = FindObjectOfType<TimerManager>();
        Time.timeScale = 1;
    }


    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(moveX, 0, 0);

        // keep the player within the screen bounds
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -8f, 8f);
        transform.position = viewPos;
    }

    // make a coroutine to handle the shield
    internal void ShieldUp(float duration)
    {
        if (shieldTimer == null)
        {
            Color originalColor = GetComponent<SpriteRenderer>().color;
            GetComponent<SpriteRenderer>().color = Color.blue;
            meterSpawner.SpawnMeter(MeterType.Shield);
            IsShielded = true;

            shieldTimer = timerManager.CreateTimer(duration, () =>
            {
                meterSpawner.RemoveMeter(MeterType.Shield);
                GetComponent<SpriteRenderer>().color = originalColor;
                IsShielded = false;
                shieldTimer = null;  // Or shieldTimer = null for shield timer
            }, onUpdate: () =>
        {
            meterSpawner.UpdateMeter(MeterType.Shield, shieldTimer.timeRemaining / duration);
        });
        }
        else if (shieldTimer.IsRunning)
        {
            shieldTimer.timeRemaining = duration;
            return;
        }
    }


    internal void Dash()
    {
        throw new NotImplementedException();
    }
    private IEnumerator DashCoroutine(float dashDistance, float dashDuration)
    {
        float startTime = Time.time;
        while (Time.time < startTime + dashDuration)
        {
            transform.Translate(Vector3.right * dashDistance * Time.deltaTime / dashDuration);
            yield return null;
        }
    }
    internal void Heal()
    {
        meterSpawner.AddToMeter(MeterType.Health, 0.1f);
    }



    internal void SlowGame(float duration)
    {
        if (slowMotionTimer == null)
        {
            GlobalSpeedManager.SetBlockSpeed(slowFactor);
            meterSpawner.SpawnMeter(MeterType.SlowMotion);

            slowMotionTimer = timerManager.CreateTimer(duration, () =>
            {
                meterSpawner.RemoveMeter(MeterType.SlowMotion);
                GlobalSpeedManager.SetBlockSpeed(1);
                slowMotionTimer = null;
            }, onUpdate: () =>
        {
            meterSpawner.UpdateMeter(MeterType.SlowMotion, slowMotionTimer.timeRemaining / duration);
        });
        }
        else if (slowMotionTimer.IsRunning)
        {
            slowMotionTimer.timeRemaining = duration;
            return;
        }
    }
}
