using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    [field: SerializeField] public float Money { get; private set; } = 0;
    [field: SerializeField] public int CreationSpeedUpgrade { get; private set; } = 0;
    [field: SerializeField] public int NewMaterialUpgrade { get; private set; } = 0;
    [field: SerializeField] public int NewEnchantmentUpgrade { get; private set; } = 0;
    [field: SerializeField] public int NewQualityUpgrade { get; private set; } = 0;

    public System.Action<float> OnMoneyChanged;
    public System.Action<int> OnCreationSpeedUpgradeChanged;
    public System.Action<int> OnNewMaterialUpgradeChanged;
    public System.Action<int> OnNewEnchantmentUpgradeChanged;
    public System.Action<int> OnNewQualityUpgradeChanged;

    private void Start()
    {
        LoadGame();
    }
    public void AddCreationSpeedUpgrade()
    {
        CreationSpeedUpgrade++;
        OnCreationSpeedUpgradeChanged?.Invoke(CreationSpeedUpgrade);
        SaveGame();
    }

    public void AddNewMaterialUpgrade()
    {
        NewMaterialUpgrade++;
        OnNewMaterialUpgradeChanged?.Invoke(NewMaterialUpgrade);
        SaveGame();
    }

    public void AddNewEnchantmentUpgrade()
    {
        NewEnchantmentUpgrade++;
        OnNewEnchantmentUpgradeChanged?.Invoke(NewEnchantmentUpgrade);
        SaveGame();
    }

    public void AddNewQualityUpgrade()
    {
        NewQualityUpgrade++;
        OnNewQualityUpgradeChanged?.Invoke(NewQualityUpgrade);
        SaveGame();
    }

    public void AddMoney(float amount)
    {
        Money += amount;
        OnMoneyChanged?.Invoke(Money);

        Debug.Log("Dinero actual: " + Money);
        SaveGame();
    }

    public void SpendMoney(float amount)
    {
        if (Money >= amount)
        {
            Money -= amount;
            OnMoneyChanged?.Invoke(Money);

            Debug.Log("Dinero actual: " + Money);
        }
        else
        {
            Debug.Log("No tienes suficiente dinero para gastar.");
        }
        SaveGame();
    }


    public void SaveGame()
    {
        PlayerPrefs.SetFloat("Money", Money);

        PlayerPrefs.SetInt("CreationSpeed", CreationSpeedUpgrade);
        PlayerPrefs.SetInt("Material", NewMaterialUpgrade);
        PlayerPrefs.SetInt("Enchantment", NewEnchantmentUpgrade);
        PlayerPrefs.SetInt("Quality", NewQualityUpgrade);
        

        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        Money = PlayerPrefs.GetFloat("Money", 0);

        CreationSpeedUpgrade = PlayerPrefs.GetInt("CreationSpeed", 0);
        NewMaterialUpgrade = PlayerPrefs.GetInt("Material", 0);
        NewEnchantmentUpgrade = PlayerPrefs.GetInt("Enchantment", 0);
        NewQualityUpgrade = PlayerPrefs.GetInt("Quality", 0);

        OnMoneyChanged?.Invoke(Money);
    }

}
