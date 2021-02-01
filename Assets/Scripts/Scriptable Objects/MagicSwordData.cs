using Temp;
using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "MagicSwordData", menuName = "ScriptableObjects/MagicSwordData", order = 3)]
    public class MagicSwordData : SwordData
    {
        [Tooltip("The figure to be casted for magical effect.")] 
        public Figures figure;
        [Tooltip("Magic effect, that will be used on figure cast.")] 
        public MagicEffect magicEffect;
    }
}
