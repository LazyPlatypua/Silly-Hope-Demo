using Level.FightGame;
using UnityEngine;
using UnityEngine.Audio;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "CharmData", menuName = "ScriptableObjects/CharmData", order = 4)]
    public class CharmData : PurchasableItemData
    {
        [Tooltip("Number of additional health points for knight.")]
        public int additionalHealth;

        private void AddHealth()
        {
            KnightBehaviour knightBehaviour = (KnightBehaviour) FindObjectOfType(typeof(KnightBehaviour));
            knightBehaviour.defaultHealth += additionalHealth;
            knightBehaviour.currentHealth += additionalHealth;
        }

        [Tooltip("Number of additional damage to knight's sword.")]
        public int additionalDamage;

        private void AddDamage()
        {
            AttackMenu attackMenu = (AttackMenu) FindObjectOfType(typeof(AttackMenu));
            attackMenu.swordDamage += additionalDamage;
        }

        [Tooltip("Combometer increased or decreased points needed for one combometer sell.")]
        public int combometerSize;

        private void IncreaseCombometer()
        {
            AttackMenu attackMenu = (AttackMenu) FindObjectOfType(typeof(AttackMenu));
            attackMenu.combometerNeededPoints += combometerSize;
        }

        [Tooltip("Chance to miss sword hit.")] 
        public int missChance ;

        public void AddMissChance()
        {
            AttackMenu attackMenu = (AttackMenu) FindObjectOfType(typeof(AttackMenu));
            attackMenu.hitChance -= missChance;
        }

        [Tooltip("Name of GameObject, that will be activated")]
        public string objectName;

        private void ActivateObject()
        {
            GameObject activatedObject = GameObject.Find(objectName);
            if (!(activatedObject is null)) activatedObject.SetActive(true);
        }

        [Tooltip("Snapshot with overkilled values to make your years bleed.")]
        public AudioMixerSnapshot overkillSnapshot;

        private void ChangeSnapshot()
        {
            overkillSnapshot.TransitionTo(20f);
        }

        // Воспроизвести эффект талисмана
        public void ExecuteEffect()
        {
            if (additionalHealth != 0) AddHealth();
            if (additionalDamage != 0) AddDamage();
            if (combometerSize != 0) IncreaseCombometer();
            if (missChance != 0) AddMissChance();
            if (!string.IsNullOrEmpty(objectName)) ActivateObject();
            if (overkillSnapshot != null) ChangeSnapshot();
        }
    }
}