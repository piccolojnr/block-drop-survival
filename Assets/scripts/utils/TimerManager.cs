using UnityEngine;
using System.Collections.Generic;

public class TimerManager : MonoBehaviour
{
    private List<Timer> timers = new List<Timer>();

    void Update()
    {
        // Update all timers
        foreach (var timer in timers)
        {
            timer.UpdateTimer(Time.deltaTime);
        }
    }

    public Timer CreateTimer(float duration, Timer.TimerCallback onEnd, Timer.TimerCallback onUpdate = null)
    {
        Timer timer = new Timer(duration, onEnd, onUpdate);
        timers.Add(timer);
        return timer;
    }
}
