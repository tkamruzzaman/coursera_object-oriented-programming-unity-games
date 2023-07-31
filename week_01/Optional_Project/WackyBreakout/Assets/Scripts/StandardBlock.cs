using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlock : Block
{
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] Sprite[] standardBlockSprite;

    private void Start()
    {
        BlockPoints = ConfigurationUtils.StandardBlockPoints;
        spriteRenderer.sprite = standardBlockSprite[Random.Range(0, standardBlockSprite.Length)];
    }
}
