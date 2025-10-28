using UnityEngine;

public class GameTimer
{
    private float _timeLimit;

    public GameTimer(float timeLimit)
    {
        _timeLimit = timeLimit;
    }

    public int RemainingTime => (int)_timeLimit;

    public void TimeUpdate() => _timeLimit -= Time.deltaTime;

    public bool IsTimeUp()
    {
        if (_timeLimit <= 0)
            return true;

        return false;
    }
}
