using System.Collections.Generic;
using UnityEngine;

public class SwordGenerator : MonoBehaviour
{
    [SerializeField] private InventoryScript inventory;

    [System.Serializable]
    public class SwordStat
    {
        public string nombre;
        public Color color;
        public float chance; 
    }

    [System.Serializable]
    public class SwordMaterial : SwordStat
    {
        public Sprite imagen;
        public int basePrice;
    }

    [System.Serializable]
    public class Multiplayers : SwordStat
    {
        public float multiplicador;
    }

    public List<Multiplayers> calidades;
    public List<SwordMaterial> materiales;
    public List<Multiplayers> encantamientos;

    [System.Serializable]
    public class SwordData
    {
        public SwordMaterial material;
        public Multiplayers calidad;
        public Multiplayers encantamiento;
        public float price;

        public SwordData(SwordMaterial mat, Multiplayers cal, Multiplayers enc, float p)
        {
            material = mat;
            calidad = cal;
            encantamiento = enc;
            price = p;
        }
    }

    // GENERAR ESPADA
    public SwordData GenerateSword()
    {
        SwordMaterial material = GetRandomSwordMaterial();
        Multiplayers calidad = GetRandomCalidad();
        Multiplayers encantamiento = GetRandomEncantamiento();

        float price = material.basePrice * calidad.multiplicador * encantamiento.multiplicador;

        return new SwordData(material, calidad, encantamiento, price);
    }

    
    public SwordMaterial GetRandomSwordMaterial()
    {
        int baseMaterials = 2;
        int unlocked = baseMaterials + inventory.NewMaterialUpgrade;

        unlocked = Mathf.Clamp(unlocked, 0, materiales.Count);

        List<SwordMaterial> availableMaterials = materiales.GetRange(0, unlocked);

        return GetRandomByWeight(availableMaterials);
    }

   
    public Multiplayers GetRandomCalidad()
    {
        int baseCalidades = 2;
        int unlocked = baseCalidades + inventory.NewQualityUpgrade;

        unlocked = Mathf.Clamp(unlocked, 0, calidades.Count);

        List<Multiplayers> available = calidades.GetRange(0, unlocked);

        return GetRandomByWeight(available);
    }

    
    public Multiplayers GetRandomEncantamiento()
    {
        int baseEncantamientos = 2;
        int unlocked = baseEncantamientos + inventory.NewEnchantmentUpgrade;

        unlocked = Mathf.Clamp(unlocked, 0, encantamientos.Count);

        List<Multiplayers> available = encantamientos.GetRange(0, unlocked);

        return GetRandomByWeight(available);
    }

    
    T GetRandomByWeight<T>(List<T> list) where T : SwordStat
    {
        float totalWeight = 0f;

        foreach (var item in list)
        {
            totalWeight += item.chance;
        }

        float randomValue = Random.Range(0f, totalWeight);

        foreach (var item in list)
        {
            randomValue -= item.chance;

            if (randomValue <= 0f)
            {
                return item;
            }
        }

        return list[list.Count - 1];
    }
}