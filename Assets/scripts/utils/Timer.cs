public class Timer
{
    public float timeRemaining;
    public delegate void TimerCallback();
    public TimerCallback OnTimerEnd;
    public TimerCallback OnTimerUpdate;

    public bool IsRunning { get; private set; } = false;

    public Timer(float duration, TimerCallback onEnd, TimerCallback onUpdate = null)
    {
        timeRemaining = duration;
        OnTimerEnd = onEnd;
        OnTimerUpdate = onUpdate;
        IsRunning = true;
    }

    public void UpdateTimer(float deltaTime)
    {
        if (IsRunning && timeRemaining > 0)
        {
            timeRemaining -= deltaTime;

            OnTimerUpdate?.Invoke();

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                IsRunning = false;
                OnTimerEnd?.Invoke();
            }
        }
    }
}
