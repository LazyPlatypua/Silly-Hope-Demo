using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquipmentManager {
    public string[] names;
    public string[] descriptions;
    public Sprite[] sprites;
    public byte currentId;
    public bool[] purchased;
    public string currentString;
    public TextMeshProUGUI equipmentText;
    public int[] cost;

    public void UpdateCurrentText() {
        equipmentText.text = currentString + names[currentId];
    }

    public string GetName() {
        return names[currentId];
    }

    public string GetDescription() {
        return descriptions[currentId];
    }

    public Sprite GetSprite() {
        return sprites[currentId];
    }

    public int GetCost() {
        return cost[currentId];
    }

    public bool IsPurchased() {
        return purchased[currentId];
    }

    public void Purchase() {
        purchased[currentId] = true;
    }

    public void SetCurrentId(byte id) {
        if (currentId != id && 0 < id && id < (names.Length - 1)) {
            currentId = id;
        }
    }

    public void NextIndex() {
        if (currentId < (names.Length - 1)) {
            currentId = ++currentId;
        } else {
            currentId = 0;
        }
    }

    public void PrevIndex() {
        if (currentId > 0) {
            currentId = --currentId;
        } else {
            currentId = (byte)(names.Length - 1);
        }
    }

}

public class EquipSelector : MonoBehaviour
{
    public enum EquipType {
        Weapon,
        Armor,
        Talisman1,
        Talisman2,
        Talisman3,
        TotalItems, // Use to count total number of enum item
    }

    private EquipmentManager[] equipment;

    public TextMeshProUGUI equipName;
    public TextMeshProUGUI equipDescription;
    public TextMeshProUGUI actionButtonText; // Select or Buy
    public TextMeshProUGUI costText;
    public Button actionButton;
    public Image equipImage;
    public InkwellsManager inkwells;
    private EquipType currentEquipType;

    private string buttonTextSelect;
    private string buttonTextPurchase;

    [Header("Weapon")]
    public TextMeshProUGUI currentWeaponText;
    public Sprite[] weaponSprites;

    [Header("Armor")]
    public TextMeshProUGUI currentArmorText;
    public Sprite[] armorSprites;

    [Header("Talisman")]
    public TextMeshProUGUI currentTalismanText1;
    public TextMeshProUGUI currentTalismanText2;
    public TextMeshProUGUI currentTalismanText3;
    public Sprite[] talismanSprites;

    public void Init() {
        equipment = new EquipmentManager[(int)EquipType.TotalItems];

        for (int i = 0; i < equipment.Length; i++) {
            equipment[i] = new EquipmentManager();
        }

        equipment[(int)EquipType.Weapon].equipmentText = currentWeaponText;
        equipment[(int)EquipType.Armor].equipmentText = currentArmorText;
        equipment[(int)EquipType.Talisman1].equipmentText = currentTalismanText1;
        equipment[(int)EquipType.Talisman2].equipmentText = currentTalismanText2;
        equipment[(int)EquipType.Talisman3].equipmentText = currentTalismanText3;

        equipment[(int)EquipType.Weapon].sprites = weaponSprites;
        equipment[(int)EquipType.Armor].sprites = armorSprites;
        equipment[(int)EquipType.Talisman1].sprites = talismanSprites;
        equipment[(int)EquipType.Talisman2].sprites = talismanSprites;
        equipment[(int)EquipType.Talisman3].sprites = talismanSprites;
    }

    public void SetStrings(int language) {
        StringSettings temp = new StringSettings(language);

        buttonTextSelect = temp.select;
        buttonTextPurchase = temp.purchase;
        actionButtonText.text = temp.select;

        equipment[(int)EquipType.Weapon].currentString = temp.current_weapon;
        equipment[(int)EquipType.Armor].currentString = temp.current_armor;
        equipment[(int)EquipType.Talisman1].currentString = temp.current_talisman;
        equipment[(int)EquipType.Talisman2].currentString = temp.current_talisman;
        equipment[(int)EquipType.Talisman3].currentString = temp.current_talisman;

        // Set Weapon strings
        equipment[(int)EquipType.Weapon].names = new string[8] {
            temp.longsword, temp.broken_sword, temp.falchion, temp.zweichender, 
            temp.peter_sword, temp.januarius_dagger, temp.spear, temp.russian_sword
        };

        equipment[(int)EquipType.Weapon].descriptions = new string[8] {
            temp.longsword_description, temp.broken_sword_description, temp.falchion_description, 
            temp.zweichender_description, temp.peter_sword_description, temp.januarius_dagger_description, 
            temp.spear_description, temp.russian_sword_description
        };

        equipment[(int)EquipType.Weapon].cost = new int[8] {
            0,20,30,40,50,60,70,80
        };

        equipment[(int)EquipType.Weapon].purchased = new bool[8];
        equipment[(int)EquipType.Weapon].purchased[0] = true;

        equipment[(int)EquipType.Weapon].UpdateCurrentText();

        // Set Armor strings
        equipment[(int)EquipType.Armor].names = new string[4] {
            temp.light_armor, temp.chain_mail, temp.strengthened_chain_mail, temp.heavy_armor
        };

        equipment[(int)EquipType.Armor].descriptions = new string[4] {
            temp.light_armor_description, temp.chain_mail_description, 
            temp.strengthened_chain_mail_description, temp.heavy_armor_description
        };

        equipment[(int)EquipType.Armor].cost = new int[4] {
            0,20,30,40
        };

        equipment[(int)EquipType.Armor].purchased = new bool[4];
        equipment[(int)EquipType.Armor].purchased[0] = true;

        equipment[(int)EquipType.Armor].UpdateCurrentText();

        // Set Talisman strings
        equipment[(int)EquipType.Talisman1].names = new string[8] {
            temp.no_charm, temp.welfare_charm, temp.heretics_charm, temp.orders_charm,
            temp.crucifix, temp.ivory_pommel, temp.popes_seal, temp.traitors_pendant
        };

        equipment[(int)EquipType.Talisman1].descriptions = new string[8] {
            "", temp.welfare_charm_description, temp.heretics_charm_description, temp.orders_charm_description,
            temp.crucifix_description, temp.ivory_pommel_description, temp.popes_seal_description, 
            temp.traitors_pendant_description
        };

        equipment[(int)EquipType.Talisman1].purchased = new bool[8];
        equipment[(int)EquipType.Talisman1].purchased[0] = true;

        equipment[(int)EquipType.Talisman1].cost = new int[8] {
            0,20,30,40,50,60,70,80
        };

        equipment[(int)EquipType.Talisman2].names = equipment[(int)EquipType.Talisman1].names;
        equipment[(int)EquipType.Talisman3].names = equipment[(int)EquipType.Talisman1].names;

        equipment[(int)EquipType.Talisman2].descriptions = equipment[(int)EquipType.Talisman1].descriptions;
        equipment[(int)EquipType.Talisman3].descriptions = equipment[(int)EquipType.Talisman1].descriptions;

        equipment[(int)EquipType.Talisman2].purchased = equipment[(int)EquipType.Talisman1].purchased;
        equipment[(int)EquipType.Talisman3].purchased = equipment[(int)EquipType.Talisman1].purchased;

        equipment[(int)EquipType.Talisman2].cost = equipment[(int)EquipType.Talisman1].cost;
        equipment[(int)EquipType.Talisman3].cost = equipment[(int)EquipType.Talisman1].cost;

        equipment[(int)EquipType.Talisman1].UpdateCurrentText();
        equipment[(int)EquipType.Talisman2].UpdateCurrentText();
        equipment[(int)EquipType.Talisman3].UpdateCurrentText();
    }

    public void NextEquipment() {
        equipment[(int)currentEquipType].NextIndex();
        UpdateSelectorInfo();
    }

    public void PrevEquipment() {
        equipment[(int)currentEquipType].PrevIndex();
        UpdateSelectorInfo();
    }

    public void UpdateSelectorInfo() {
        equipName.text = equipment[(int)currentEquipType].GetName();
        equipDescription.text = equipment[(int)currentEquipType].GetDescription();
        equipImage.sprite = equipment[(int)currentEquipType].GetSprite();

        if (equipment[(int)currentEquipType].IsPurchased()) {
            costText.text = "";
            actionButtonText.text = buttonTextSelect;
        } else {
            costText.text = equipment[(int)currentEquipType].GetCost().ToString();
            actionButtonText.text = buttonTextPurchase;
        }
    }

    public void onAction() {
        if (equipment[(int)currentEquipType].IsPurchased()) {
            equipment[(int)currentEquipType].UpdateCurrentText();
        } else {
            if (equipment[(int)currentEquipType].GetCost() <= inkwells.getInkCount()) {
                inkwells.InkUpdate(inkwells.getInkCount() - equipment[(int)currentEquipType].GetCost());
                equipment[(int)currentEquipType].Purchase();
            }
        }
    }

    public byte GetCurrentEquipId(EquipType type) {
        return equipment[(int)type].currentId;
    }

    public void SetCurrentEquipId(EquipType type, byte id) {
        equipment[(int)type].SetCurrentId(id);
        equipment[(int)type].UpdateCurrentText();
    }

    public void SetActive(bool visible) {
        if (visible) {
            UpdateSelectorInfo();
        }
        
        gameObject.SetActive(visible);   
    }

    public void ChangeEquipType(EquipType type) {
        currentEquipType = type;
    }
}