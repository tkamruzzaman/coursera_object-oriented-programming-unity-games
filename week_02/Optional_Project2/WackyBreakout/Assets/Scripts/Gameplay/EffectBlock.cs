using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBlock : Block
{
    [SerializeField]
    EffectName effectBlockName;

    [SerializeField]
    Sprite freezerBlockSprite;
    [SerializeField]
    Sprite speedupBlockSprite;

    public EffectName EffectBlockName
    {
        get { return effectBlockName; }
        set
        {
            effectBlockName = value;

            if (effectBlockName == EffectName.Freezer)
            {
                GetComponent<SpriteRenderer>().sprite = freezerBlockSprite;
            }
            else if (effectBlockName == EffectName.Speedup)
            {
                GetComponent<SpriteRenderer>().sprite = speedupBlockSprite;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Points = ConfigurationUtils.EffectBlockPoints;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
