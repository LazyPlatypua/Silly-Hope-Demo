using UnityEngine;

namespace Scriptable_Objects
{
    public class PurchasableItemData : ItemData
    {
        [Tooltip("Item price.")]
        public int price;
        
        [Tooltip("Item sprite in equipment.")]
        public Sprite equipmentSprite;
    }
}
