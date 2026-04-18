using TMPro;
using UnityEngine;

public class ShopButtonScript : MonoBehaviour
{
    [SerializeField] private InventoryScript inventory;

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI priceText;

    public string upgradeName;

    [SerializeField] private float price = 100;
    [SerializeField] private int maxLevel = 3;

    private int currentLevel = 0;

    public enum UpgradeType
    {
        CreationSpeed,
        NewMaterial,
        NewQuality,
        NewEnchantment
    }

    [SerializeField] private UpgradeType upgradeType;

    void Start()
    {
        UpdateText();
    }

    public void BuyUpgrade()
    {
        if (currentLevel >= maxLevel)
        {
            levelText.text = "MAX";
            return;
        }

        if (inventory.Money < price)
        {
            Debug.Log("No hay dinero suficiente");
            return;
        }

        inventory.SpendMoney(price);

        price *= 2;

        currentLevel++;

        ApplyUpgrade();

        UpdateText();
    }

    void ApplyUpgrade()
    {
        switch (upgradeType)
        {
            case UpgradeType.CreationSpeed:
                inventory.AddCreationSpeedUpgrade();
                break;

            case UpgradeType.NewMaterial:
                inventory.AddNewMaterialUpgrade();
                break;

            case UpgradeType.NewQuality:
                inventory.AddNewQualityUpgrade();
                break;

            case UpgradeType.NewEnchantment:
                inventory.AddNewEnchantmentUpgrade();
                break;
        }
    }

    void UpdateText()
    {
        nameText.text = upgradeName;

        if (currentLevel >= maxLevel)
        {
            levelText.text = "MAX";
            priceText.text = "";
        }
        else
        {
            levelText.text = currentLevel + "/" + maxLevel;
            priceText.text = price + "€";
        }
    }
}
