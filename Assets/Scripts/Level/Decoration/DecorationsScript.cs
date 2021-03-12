//Класс отвечает за менеджмент декорации
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Level.Decoration
{
    public class DecorationsScript : MonoBehaviour
    {
        [NotNull] [Tooltip("Link to PP Volume gameObject.")] public GameObject postProcessing;
        [NotNull] [Tooltip("Link to location particle effect gameObject.")] public GameObject locationEffects;
        [NotNull] [Tooltip("List of decorations sprites for this location.")] public List<Sprite> randomDecorations;
        
        // Функция включает эффекты сцены, если передана ложь и наоборот
        public void SetUpGraphics(bool isLow)
        { 
            postProcessing.SetActive(!isLow); 
            locationEffects.SetActive(!isLow);
        }
    }
}
