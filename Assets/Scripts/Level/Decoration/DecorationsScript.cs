using System.Collections.Generic;
using UnityEngine;

public class DecorationsScript : MonoBehaviour
{
    public SpawnDecorations spawnDecorations;
    public GameObject postProcessing;
    public GameObject locationEffects;

    public List<GameObject>random_decorations;  //Префабы рандомноустанавливающихся декораций 

    private void Start()
    {
        if (spawnDecorations == null)
        {
            spawnDecorations = SpawnDecorations.instance;
        }
    }

    public void SetUpGraphics(bool enable)
    {
        if(postProcessing != null) 
            postProcessing.SetActive(!enable);

        if (locationEffects != null) 
            locationEffects.SetActive(!enable);

        if (!enable)
        {
            spawnDecorations.Spawn(random_decorations);
        }
    }
}
