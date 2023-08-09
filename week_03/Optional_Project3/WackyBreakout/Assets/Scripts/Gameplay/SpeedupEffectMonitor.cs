using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SpeedupEffectMonitor : MonoBehaviour
{
    Timer speedupTimer;
    float speedupFactor;

    public bool SpeedupActive
    {
        get { return speedupTimer.Running; }
    }

    public float SpeedupSecondsLeft
    {
        get { return speedupTimer.SecondsLeft; }
    }

    public float SpeedupFactor
    {
        get { return speedupFactor; }
    }

    void Start()
    {
        speedupTimer = gameObject.AddComponent<Timer>();
        EventManager.AddSpeedupEffectActivateListener(
            (float duration, float factor) =>
            {
                if (!speedupTimer.Running)
                {
                    speedupFactor = factor;
                    speedupTimer.Duration = duration;
                    speedupTimer.Run();
                }
                else
                {
                    speedupTimer.AddTime(duration);
                }
            });
    }

    void Update()
    {
        if (speedupTimer.Finished)
        {
            speedupTimer.Stop();
            speedupFactor = 1;
        }
    }
}
