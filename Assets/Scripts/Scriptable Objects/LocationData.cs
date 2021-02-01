using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "LocationData", menuName = "ScriptableObjects/LocationData", order = 1)]
    public class LocationData : ItemData
    {
        [Tooltip("Decoration prefab.")] [NotNull] public GameObject decorationPrefab;
        [Tooltip("Enemies prefab.")] [NotNull] public List<GameObject> enemiesPrefabs;
        [Tooltip("Point image.")] [NotNull] public Sprite pointSprite;
        
        [Tooltip("Music for location.")] [NotNull] public AudioClip audioClip;
        [Tooltip("Timestamps for changing beat tempo.")] [NotNull]
        public float[] timestamps;
        [Tooltip("Beat tempos for timestamps.")] [NotNull]
        public int[]  beatTempos;
        
        private void OnValidate()
        {
            int timestampsSize = timestamps.Length;
            if (timestampsSize != beatTempos.Length)
            {
                Debug.LogWarning("LocationData: Timestamps and beat tempos must be same array size!");
                Array.Resize(ref beatTempos, timestampsSize);
            }
        }
    }
}
