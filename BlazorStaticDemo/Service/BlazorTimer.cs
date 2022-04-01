//https://wellsb.com/csharp/aspnet/blazor-timer-navigate-programmatically
using System.Timers;
using Timer = System.Timers.Timer;

namespace BlazorStaticDemo.Service;

public class BlazorTimer
{
    private Timer _timer = new();

    public void SetTimer(double interval)
    {
        _timer = new Timer(interval);
        _timer.Elapsed += NotifyTimerElapsed;
        _timer.Enabled = true;
    }

    public event Action OnElapsed;

    private void NotifyTimerElapsed(Object source, ElapsedEventArgs e)
    {
        OnElapsed?.Invoke();
        _timer.Dispose();
    }
}
