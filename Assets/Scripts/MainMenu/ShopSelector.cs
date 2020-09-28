using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopSelector : MonoBehaviour
{
    private struct ShopItem {
        public string name;
        public string description;
        public bool isPurchase;

        public ShopItem(string name, string description)
        {
            this.name = name;
            this.description = description;
            this.isPurchase = false;
        }
    }

    public enum ShopType {
        Content,
        Weapon,
        Armor,
        Talisman,
    }

    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;
    public TextMeshProUGUI nextButtonText;
    public TextMeshProUGUI backButtonText;
    public TextMeshProUGUI purchaseButtonText;
    public Image itemImage;
    private ShopType currentShopType;

    [Header("Content")]
    public Sprite[] contentSprites;
    private ShopItem[] contentItems;
    private byte contentIndex;

    [Header("Weapon")]
    public Sprite[] weaponSprites;
    private ShopItem[] weaponItems;
    private byte weaponIndex;

    [Header("Armor")]
    public Sprite[] armorSprites;
    private ShopItem[] armorItems;
    private byte armorIndex;

    [Header("Talisman")]
    public Sprite[] talismanSprites;
    private ShopItem[] talismanItems;
    private byte talismanIndex;

    private Vector2 startPostition; // start swipe position

    void Update() {
        DetectSwipe();
    }

    public void SetStrings(int language)
    {
        StringSettings temp = new StringSettings(language);

        nextButtonText.text = temp.next;
        backButtonText.text = temp.back;
        purchaseButtonText.text = temp.purchase;

        contentItems = new ShopItem[8] {
            new ShopItem(temp.longsword, temp.longsword_description),
            new ShopItem(temp.broken_sword, temp.broken_sword_description),
            new ShopItem(temp.falchion, temp.falchion_description),
            new ShopItem(temp.zweichender, temp.zweichender_description),
            new ShopItem(temp.peter_sword, temp.peter_sword_description),
            new ShopItem(temp.januarius_dagger, temp.januarius_dagger_description),
            new ShopItem(temp.spear, temp.spear_description),
            new ShopItem(temp.russian_sword, temp.russian_sword_description),
        };

        weaponItems = new ShopItem[8] {
            new ShopItem(temp.longsword, temp.longsword_description),
            new ShopItem(temp.broken_sword, temp.broken_sword_description),
            new ShopItem(temp.falchion, temp.falchion_description),
            new ShopItem(temp.zweichender, temp.zweichender_description),
            new ShopItem(temp.peter_sword, temp.peter_sword_description),
            new ShopItem(temp.januarius_dagger, temp.januarius_dagger_description),
            new ShopItem(temp.spear, temp.spear_description),
            new ShopItem(temp.russian_sword, temp.russian_sword_description),
        };

        armorItems = new ShopItem[4] {
            new ShopItem(temp.light_armor, temp.light_armor_description),
            new ShopItem(temp.chain_mail, temp.chain_mail_description),
            new ShopItem(temp.strengthened_chain_mail, temp.strengthened_chain_mail_description),
            new ShopItem(temp.heavy_armor, temp.heavy_armor_description),
        };

        talismanItems = new ShopItem[8] {
            new ShopItem(temp.no_charm, ""),
            new ShopItem(temp.welfare_charm, temp.welfare_charm_description),
            new ShopItem(temp.heretics_charm, temp.heretics_charm_description),
            new ShopItem(temp.orders_charm, temp.orders_charm_description),
            new ShopItem(temp.crucifix, temp.crucifix_description),
            new ShopItem(temp.ivory_pommel, temp.ivory_pommel_description),
            new ShopItem(temp.popes_seal, temp.popes_seal_description),
            new ShopItem(temp.traitors_pendant, temp.traitors_pendant_description),
        };
    }

    private byte NextIndex(byte currentIndex, int length) {
        if (currentIndex < length) {
            return ++currentIndex;
        } else {
            return 0;
        }
    }

    private byte PrevIndex(byte currentIndex, int length) {
        if (currentIndex > 0) {
            return --currentIndex;
        } else {
            return (byte)length;
        }
    }

    public void NextEquipWeapon() {
        if (currentShopType == ShopType.Content) {
            contentIndex = NextIndex(contentIndex, contentItems.Length - 1);
        } else if (currentShopType == ShopType.Weapon) {
            weaponIndex = NextIndex(weaponIndex, weaponItems.Length - 1);
        } else if (currentShopType == ShopType.Armor) {
            armorIndex = NextIndex(armorIndex, armorItems.Length - 1);
        } else if (currentShopType == ShopType.Talisman) {
            talismanIndex = NextIndex(talismanIndex, talismanItems.Length - 1);
        }
        
        UpdateSelectorInfo();
    }

    public void PrevEquipWeapon() {
        if (currentShopType == ShopType.Content) {
            contentIndex = PrevIndex(weaponIndex, contentItems.Length - 1);
        } else if (currentShopType == ShopType.Weapon) {
            weaponIndex = PrevIndex(weaponIndex, weaponItems.Length - 1);
        } else if (currentShopType == ShopType.Armor) {
            armorIndex = PrevIndex(armorIndex, armorItems.Length - 1);
        } else if (currentShopType == ShopType.Talisman) {
            talismanIndex = PrevIndex(talismanIndex, talismanItems.Length - 1);
        }

        UpdateSelectorInfo();
    }

    public void UpdateSelectorInfo() {
        if (currentShopType == ShopType.Content) {
            Debug.LogWarning("Test");
            Debug.LogWarning($"Contet name: {contentItems}, {contentIndex}");
            itemName.text = contentItems[contentIndex].name;
            itemDescription.text = contentItems[contentIndex].description;
            itemImage.sprite = contentSprites[contentIndex];
        } else if (currentShopType == ShopType.Weapon) {
            itemName.text = weaponItems[weaponIndex].name;
            itemDescription.text = weaponItems[weaponIndex].description;
            itemImage.sprite = weaponSprites[weaponIndex];
        } else if (currentShopType == ShopType.Armor) {
            itemName.text = armorItems[armorIndex].name;
            itemDescription.text = armorItems[armorIndex].description;
            itemImage.sprite = armorSprites[armorIndex];
        } else if (currentShopType == ShopType.Talisman) {
            itemName.text = talismanItems[talismanIndex].name;
            itemDescription.text = talismanItems[talismanIndex].description;
            itemImage.sprite = talismanSprites[talismanIndex];
        }
    }

    public void PurchaseItem() {

    }

    public void SetActive(bool visible) {
        if (visible) {
            UpdateSelectorInfo();
        }
        
        gameObject.SetActive(visible);   
    }

    public void SetShopItemType(ShopType type) {
        currentShopType = type;
        contentIndex = 0;
        weaponIndex = 0;
        armorIndex = 0;
        talismanIndex = 0;
    }

    public void DetectSwipe() {
        if (Input.GetMouseButtonDown(0)) {
            //save began touch 2d point
            startPostition = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0)) {
            swipeHandle(new Vector2(Input.mousePosition.x,Input.mousePosition.y));
        }

        if (Input.touches.Length > 0) {
            Touch t = Input.GetTouch(0);
            
            if (t.phase == TouchPhase.Began) {
                //save began touch 2d point
                startPostition = new Vector2(t.position.x,t.position.y);
            }

            if (t.phase == TouchPhase.Ended) {
                swipeHandle(new Vector2(t.position.x,t.position.y));
            }
        }
    }

    private void swipeHandle(Vector2 endPosition) {
        //create vector from the two points
        Vector2 currentSwipe = new Vector2(endPosition.x - startPostition.x, endPosition.y - startPostition.y);

        //normalize the 2d vector
        currentSwipe.Normalize();

        //swipe left
        if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
            NextEquipWeapon();
            Debug.Log("left swipe");
        }

        //swipe right
        if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
            PrevEquipWeapon();
            Debug.Log("right swipe");
        }
    }
}