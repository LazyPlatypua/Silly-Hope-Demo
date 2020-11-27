using UnityEngine;

namespace Save_System.Scriptable_Objects
{
    public class ItemData : ScriptableObject
    {
        [Tooltip("Item index.")]
        public short id = 0;
    }
}
