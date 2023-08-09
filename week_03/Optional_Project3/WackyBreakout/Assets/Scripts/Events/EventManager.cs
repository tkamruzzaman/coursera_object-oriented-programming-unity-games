using System.Collections.Generic;
using UnityEngine.Events;

public static class EventManager
{
    static List<Ball> ballDiedInvokers = new List<Ball>();
    static List<UnityAction> ballDiedListeners = new List<UnityAction>();

    static List <Ball> ballLostInvokers = new List<Ball>();
    static List<UnityAction> ballLostListeners = new List<UnityAction>();

    static List<Block> addPointsInvokers = new List<Block>();
    static List<UnityAction<int>> addPointsListeners = new List<UnityAction<int>>();

    static List<EffectBlock> freezerEffectActivateInvokers = new List<EffectBlock>();
    static List<UnityAction<float>> freezerEffectActivateListeners = new List<UnityAction<float>>();

    static List<EffectBlock> speedupEffectActivateInvokers = new List<EffectBlock>();
    static List<UnityAction<float, float>> speedupEffectActivateListeners = new List<UnityAction<float, float>>();

    #region Ball Died

    public static void AddBallDiedInvoker(Ball invoker)
    {
        ballDiedInvokers.Add(invoker);

        foreach (var listener in ballDiedListeners)
        {
            invoker.AddBallDiedListener(listener);
        }
    }

    public static void RemoveBallDiedInvoker(Ball invoker)
    {
        ballDiedInvokers.Remove(invoker);
    }

    public static void AddBallDiedListener(UnityAction listener)
    {
        ballDiedListeners.Add(listener);

        foreach (var invoker in ballDiedInvokers)
        {
            invoker.AddBallDiedListener(listener);
        }
    }

    #endregion

    #region Ball Lost

    public static void AddBallLostInvoker(Ball invoker)
    {
        ballLostInvokers.Add(invoker);

        foreach(var listener in ballLostListeners)
        {
            invoker.AddBallLostListener(listener);
        }
    }

    public static void RemoveBallLostInvoker(Ball invoker)
    {
        ballLostInvokers.Remove(invoker);
    }

    public static void AddBallLostListener(UnityAction listener)
    {
        ballLostListeners.Add(listener);

        foreach (var invoker in ballLostInvokers)
        {
            invoker.AddBallLostListener(listener);
        }
    }

    #endregion

    #region Add Points

    public static void AddAddPointsInvoker(Block invoker) 
    {
        addPointsInvokers.Add(invoker);

        foreach (var listener in addPointsListeners)
        {
            invoker.AddAddPointsListener(listener);
        }
    }

    public static void RemoveAddPointsInvoker(Block invoker) 
    {
        addPointsInvokers.Remove(invoker);
    }

    public static void AddAddPointsListener(UnityAction<int> listener) 
    { 
        addPointsListeners.Add(listener);

        foreach (var invoker in addPointsInvokers)
        {
            invoker.AddAddPointsListener(listener);
        }
    }


    #endregion

    #region Freeze Effect

    public static void AddFreezerEffectActivateInvoker(EffectBlock invoker) 
    {
        freezerEffectActivateInvokers.Add(invoker);

        foreach (var listener in freezerEffectActivateListeners)
        {
            invoker.AddFreezerEffectListener(listener);
        }
    }

    public static void RemoveFreezerEffectActivateInvoker(EffectBlock invoker)
    {
        freezerEffectActivateInvokers.Remove(invoker);
    }

    public static void AddFreezerEffectActivateListener(UnityAction<float> listener)
    {
        freezerEffectActivateListeners.Add(listener);

        foreach (var invoker in freezerEffectActivateInvokers)
        {
            invoker.AddFreezerEffectListener(listener);
        }
    }

    #endregion

    #region Speedup Effect

    public static void AddSpeedupEffectActivateInvoker(EffectBlock invoker)
    {
        speedupEffectActivateInvokers.Add(invoker);

        foreach (var listener in speedupEffectActivateListeners)
        {
            invoker.AddSpeedupEffectListener(listener);
        }
    }

    public static void RemoveSpeedupEffectActivateInvoker(EffectBlock invoker)
    {
        speedupEffectActivateInvokers.Remove(invoker);
    }

    public static void AddSpeedupEffectActivateListener(UnityAction<float, float> listener)
    {
        speedupEffectActivateListeners.Add(listener);

        foreach (var invoker in speedupEffectActivateInvokers)
        {
            invoker.AddSpeedupEffectListener(listener);
        }
    }

    public static void RemoveSpeedupEffectActivateListener(UnityAction<float, float> listener)
    {
        speedupEffectActivateListeners.Remove(listener);

        foreach (var invoker in speedupEffectActivateInvokers)
        {
            invoker.RemoveSpeedupEffectListener(listener);
        }
    }

    #endregion
}
