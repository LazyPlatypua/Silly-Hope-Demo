//Класс отвечает за менеджмент декорации
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Level.Decoration
{
    [RequireComponent(typeof(SpawnDecorations))]
    public class DecorationsScript : MonoBehaviour
    {
        [NotNull] public SpawnDecorations spawnDecorations;    // Ссылка на спавнер декорации
        [NotNull] public GameObject postProcessing;    // Ссылка на игровой объект пост-процессинга
        [NotNull] public GameObject locationEffects;    //Ссылка на игровой объект эффекта локации

        public List<Sprite> randomDecorations;  //Префабы рандомноустанавливающихся декораций 

        // Функция включает эффекты сцены, если передана ложь и наоборот
        public void SetUpGraphics(bool isLow)
        { 
            postProcessing.SetActive(!isLow); 
            locationEffects.SetActive(!isLow);

            if (!isLow)
            {
                spawnDecorations.Spawn(randomDecorations);
            }
        }
    }
}
