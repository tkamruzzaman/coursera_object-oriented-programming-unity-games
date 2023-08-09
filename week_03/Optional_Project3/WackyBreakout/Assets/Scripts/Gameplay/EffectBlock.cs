using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// An effect block
/// </summary>	
public class EffectBlock : Block
{
    #region Fields

    [SerializeField]
    Sprite freezerSprite;
    [SerializeField]
    Sprite speedupSprite;

    // effect-specific values
    EffectName effect;

    float effectDuration;
    float effectFactor;

    FreezerEffectActivatedEvent freezerEffectActivatedEvent;
    SpeedupEffectActivatedEvent speedupEffectActivatedEvent;

    #endregion

    #region Properties

    /// <summary>
    /// Sets the effect for the pickup
    /// </summary>
    /// <value>pickup effect</value>
    public EffectName Effect
    {
        set
        {
            effect = value;

            // set sprite
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (effect == EffectName.Freezer)
            {
                spriteRenderer.sprite = freezerSprite;
                effectDuration = ConfigurationUtils.FreezerEffectDuration;
                freezerEffectActivatedEvent = new FreezerEffectActivatedEvent();
                EventManager.AddFreezerEffectActivateInvoker(this);
            }
            else
            {
                spriteRenderer.sprite = speedupSprite;
                effectDuration = ConfigurationUtils.SpeedupEffectDuration;
                effectFactor = ConfigurationUtils.SpeedupEffectFactor;
                speedupEffectActivatedEvent = new SpeedupEffectActivatedEvent();
                EventManager.AddSpeedupEffectActivateInvoker(this);
            }
        }
    }

    #endregion

    #region Unity methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>	
    protected override void Start()
    {
        Points = ConfigurationUtils.EffectBlockPoints;
        base.Start();
    }

    protected override void OnCollisionEnter2D(Collision2D coll)
    {
        if (effect == EffectName.Freezer)
        {
            freezerEffectActivatedEvent.Invoke(effectDuration);
            EventManager.RemoveFreezerEffectActivateInvoker(this);
        }
        else if (effect == EffectName.Speedup)
        {
            speedupEffectActivatedEvent.Invoke(effectDuration, effectFactor);
            EventManager.RemoveSpeedupEffectActivateInvoker(this);
        }
        base.OnCollisionEnter2D(coll);
    }

    #endregion

    public void AddFreezerEffectListener(UnityAction<float> listener)
    {
        freezerEffectActivatedEvent.AddListener(listener);
    }

    public void AddSpeedupEffectListener(UnityAction<float, float> listener)
    {
        speedupEffectActivatedEvent.AddListener(listener);
    }

    public void RemoveSpeedupEffectListener(UnityAction<float, float> listener)
    {
        speedupEffectActivatedEvent.RemoveListener(listener);
    }
}
