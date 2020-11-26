using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Level.Load_and_Manager
{
    [CreateAssetMenu(fileName = "LocationData", menuName = "ScriptableObjects/LocationData", order = 1)]
    public class LocationData : ScriptableObject
    {
        [Tooltip("Location id")]
        public short id = 0;
        
        [Tooltip("Decoration prefab")]
        public GameObject decorationPrefab;
        [Tooltip("Enemies prefab")]
        public List<GameObject> enemiesPrefabs;
        [Tooltip("Point image")]
        public Sprite pointSprite;
        
        [Tooltip("Music for location")]
        public AudioClip audioClip;
        [Tooltip("Timestamps for changing beat tempo")]
        public float[] timestamps;
        [Tooltip("Beat tempos for timestamps")]
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
