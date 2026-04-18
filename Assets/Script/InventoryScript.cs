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


    public void AddCreationSpeedUpgrade()
    {
        CreationSpeedUpgrade++;
        OnCreationSpeedUpgradeChanged?.Invoke(CreationSpeedUpgrade);
    }

    public void AddNewMaterialUpgrade()
    {
        NewMaterialUpgrade++;
        OnNewMaterialUpgradeChanged?.Invoke(NewMaterialUpgrade);
    }

    public void AddNewEnchantmentUpgrade()
    {
        NewEnchantmentUpgrade++;
        OnNewEnchantmentUpgradeChanged?.Invoke(NewEnchantmentUpgrade);
    }

    public void AddNewQualityUpgrade()
    {
        NewQualityUpgrade++;
        OnNewQualityUpgradeChanged?.Invoke(NewQualityUpgrade);
    }

    public void AddMoney(float amount)
    {
        Money += amount;
        OnMoneyChanged?.Invoke(Money);

        Debug.Log("Dinero actual: " + Money);
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
    }
}
