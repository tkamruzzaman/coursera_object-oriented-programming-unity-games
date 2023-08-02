using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Builds a level
/// </summary>	
public class LevelBuilder : MonoBehaviour
{
    #region Fields

    [SerializeField]
    GameObject prefabPaddle;

    [SerializeField]
    GameObject prefabStandardBlock;

    [SerializeField] 
    GameObject prefabBonusBlock;

    [SerializeField]
    GameObject prefabEffectBlock;

    #endregion

    #region Unity methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>	
    void Start()
    {
        Instantiate(prefabPaddle);

        PlaceBlock();
    }

    void PlaceBlock()
    {
        // retrieve block size
        GameObject tempBlock = Instantiate(prefabStandardBlock);
        BoxCollider2D collider = tempBlock.GetComponent<BoxCollider2D>();
        float blockWidth = collider.size.x;
        float blockHeight = collider.size.y;
        Destroy(tempBlock);

        // calculate blocks per row and make sure left block position centers row
        float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        int blocksPerRow = (int)(screenWidth / blockWidth);
        float totalBlockWidth = blocksPerRow * blockWidth;
        float leftBlockOffset = ScreenUtils.ScreenLeft +
            (screenWidth - totalBlockWidth) / 2 +
            blockWidth / 2;

        float topRowOffset = ScreenUtils.ScreenTop -
            (ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom) / 5 -
            blockHeight / 2;

        // add rows of blocks
        Vector2 currentPosition = new Vector2(leftBlockOffset, topRowOffset);
        for (int row = 0; row < 3; row++)
        {
            for (int column = 0; column < blocksPerRow; column++)
            {
                SpawnRandomizedBlock(currentPosition); 
                currentPosition.x += blockWidth;
            }

            // move to next row
            currentPosition.x = leftBlockOffset;
            currentPosition.y += blockHeight;
        }
    }

    void SpawnRandomizedBlock(Vector2 currentPosition)
    {
        int randomValue = Random.Range(0, 100);

        if(randomValue <= ConfigurationUtils.StandardBlocksProbability)
        {     
            Instantiate(prefabStandardBlock, currentPosition, Quaternion.identity);
        }
        else if (randomValue <= ConfigurationUtils.StandardBlocksProbability 
            + ConfigurationUtils.BonusBlocksProbability)
        {
            Instantiate(prefabBonusBlock, currentPosition, Quaternion.identity);
        }
        else if(randomValue <= ConfigurationUtils.StandardBlocksProbability 
            + ConfigurationUtils.BonusBlocksProbability
            + ConfigurationUtils.FreezerBlocksProbability)
        {
            Instantiate(prefabEffectBlock, currentPosition, Quaternion.identity)
                .GetComponent<EffectBlock>().EffectBlockName = EffectName.Freezer;
        }
        else
        {      
            Instantiate(prefabEffectBlock, currentPosition, Quaternion.identity)
                .GetComponent<EffectBlock>().EffectBlockName = EffectName.Speedup;
        }
    }

    #endregion
}
