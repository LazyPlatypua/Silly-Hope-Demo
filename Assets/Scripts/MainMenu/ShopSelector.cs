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
            new ShopItem(temp.longsword, temp.longswordDescription),
            new ShopItem(temp.brokenSword, temp.brokenSwordDescription),
            new ShopItem(temp.falchion, temp.falchionDescription),
            new ShopItem(temp.zweichender, temp.zweichenderDescription),
            new ShopItem(temp.peterSword, temp.peterSwordDescription),
            new ShopItem(temp.januariusDagger, temp.januariusDaggerDescription),
            new ShopItem(temp.spear, temp.spearDescription),
            new ShopItem(temp.russianSword, temp.russianSwordDescription),
        };

        weaponItems = new ShopItem[8] {
            new ShopItem(temp.longsword, temp.longswordDescription),
            new ShopItem(temp.brokenSword, temp.brokenSwordDescription),
            new ShopItem(temp.falchion, temp.falchionDescription),
            new ShopItem(temp.zweichender, temp.zweichenderDescription),
            new ShopItem(temp.peterSword, temp.peterSwordDescription),
            new ShopItem(temp.januariusDagger, temp.januariusDaggerDescription),
            new ShopItem(temp.spear, temp.spearDescription),
            new ShopItem(temp.russianSword, temp.russianSwordDescription),
        };

        armorItems = new ShopItem[4] {
            new ShopItem(temp.lightArmor, temp.lightArmorDescription),
            new ShopItem(temp.chainMail, temp.chainMailDescription),
            new ShopItem(temp.strengthenedChainMail, temp.strengthenedChainMailDescription),
            new ShopItem(temp.heavyArmor, temp.heavyArmorDescription),
        };

        talismanItems = new ShopItem[8] {
            new ShopItem(temp.noCharm, ""),
            new ShopItem(temp.welfareCharm, temp.welfareCharmDescription),
            new ShopItem(temp.hereticCharm, temp.hereticCharmDescription),
            new ShopItem(temp.orderCharm, temp.orderCharmDescription),
            new ShopItem(temp.crucifix, temp.crucifixDescription),
            new ShopItem(temp.ivoryPommel, temp.ivoryPommelDescription),
            new ShopItem(temp.popeSeal, temp.popeSealDescription),
            new ShopItem(temp.traitorPendant, temp.traitorPendantDescription),
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
            SwipeHandle(new Vector2(Input.mousePosition.x,Input.mousePosition.y));
        }

        if (Input.touches.Length > 0) {
            Touch t = Input.GetTouch(0);
            
            if (t.phase == TouchPhase.Began) {
                //save began touch 2d point
                startPostition = new Vector2(t.position.x,t.position.y);
            }

            if (t.phase == TouchPhase.Ended) {
                SwipeHandle(new Vector2(t.position.x,t.position.y));
            }
        }
    }

    private void SwipeHandle(Vector2 endPosition) {
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