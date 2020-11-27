using Save_System.Scriptable_Objects;
using UnityEngine;

namespace Save_System
{
    [CreateAssetMenu(fileName = "SwordData", menuName = "ScriptableObjects/SwordData", order = 2)]
    public class SwordData : PurchasableItemData
    {
        [Tooltip("Base sword damage.")]
        public int damage = 1;
        [Tooltip("Size of point capture zones.")]
        public float captureZoneSize = 1f;
        [Tooltip("Minimal distance between points in seconds.")]
        public float timeBetweenPoints = 1f;
    }
}
