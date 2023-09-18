using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] int winSceneIndex = 2;
    
    int numberOfBlocks;

    public void AddBlock()
    {
        numberOfBlocks++;
    }

    // Check if there are any blocks left and if not loads the appopreate scene
    public void RemoveBlock()
    {
        numberOfBlocks--;
        if (numberOfBlocks <= 0)
        {
            sceneLoader.LoadScene(winSceneIndex);
        }
    }
}
