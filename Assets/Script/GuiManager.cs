using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GuiManager : MonoBehaviour
{
    [SerializeField] private AudioManagerScript audioManager;
    [SerializeField] private ClickManager clickManager;
    [SerializeField] private Slider progressBar;
    [SerializeField] private TextMeshProUGUI money;
    [SerializeField] private SwordGenerator swordGenerator;
    [SerializeField] private InventoryScript inventory;

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;


    public GameObject RewardPanel;
    public GameObject ShopPanel;
    public GameObject OptionsPanel;


    public TextMeshProUGUI RewardMoneyText;
    public TextMeshProUGUI RewardQualityText;
    public TextMeshProUGUI RewardEnchantmentTXT;
    public TextMeshProUGUI RewardMaterialTXT;
    public TextMeshProUGUI RewardWeaponTXT;
    public Image RewardWeaponIMG;
    // Cambiar cosas de la recompensa, como el texto o la imagen del arma

    public void Start()
    {
        inventory.OnMoneyChanged += ActualizarDinero;
        money.text = "Dinero: " + inventory.Money + "€";

        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);

        musicSlider.onValueChanged.AddListener(OnMusicChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXChanged);
    }

    public void OnMusicChanged(float value)
    {
        AudioManagerScript.Instance.SetMusicVolume(value);
    }

    public void OnSFXChanged(float value)
    {
        AudioManagerScript.Instance.SetSFXVolume(value);
        AudioManagerScript.Instance.PlaySound(AudioManagerScript.Instance.UiClick);
    }

    public void ActualizarBarraProgreso(int progreso)
    {
        progressBar.value = progreso;
        print("Actualizando barra de progreso: " + progreso);
    }

    public void ActualizarDinero(float cantidad)
    {
        money.text = "Dinero: " + cantidad.ToString() + "€";
    }

    public void WeaponRewardChange()
    {
        SwordGenerator.SwordData swordData = swordGenerator.GenerateSword();

        RewardMoneyText.text = swordData.price.ToString() + "€";

        RewardQualityText.text = swordData.calidad.nombre;
        RewardQualityText.color = swordData.calidad.color;

        RewardEnchantmentTXT.text = swordData.encantamiento.nombre;
        RewardEnchantmentTXT.color = swordData.encantamiento.color;

        RewardMaterialTXT.text = swordData.material.nombre;
        RewardMaterialTXT.color = swordData.material.color;

        RewardWeaponTXT.text = "SWORD";

        RewardWeaponIMG.sprite = swordData.material.imagen;

        ShowReward();

        inventory.AddMoney(swordData.price);


        Debug.Log($"Espada generada: {swordData.material.nombre} con calidad {swordData.calidad.nombre} y encantamiento {swordData.encantamiento.nombre}. Precio: {swordData.price}");

    }













    public void ShowReward()
    {
        SwordGenerator.SwordData swordData = swordGenerator.GenerateSword();
        if (!RewardPanel.activeSelf)
        {


            if (swordData.price > 50)
            {
                audioManager.PlaySound(audioManager.PerfectSwordCreated);
            }

            else if (swordData.price > 20)
            {
                audioManager.PlaySound(audioManager.GoodSwordCreated);
            }

            else
            {
                audioManager.PlaySound(audioManager.NormalSwordCreated);
            }


            print("Mostrando recompensa");
            RewardPanel.SetActive(true);
        }
    }
    public void HideReward()
    {
        if (RewardPanel.activeSelf)
        {
            audioManager.StopSound();

            print("Ocultando recompensa");
            RewardPanel.SetActive(false);
        }
    }


    public void ShowShop()
    {
        if (!ShopPanel.activeSelf)
        {
            audioManager.PlaySound(audioManager.UiClick);
            print("Mostrando tienda");
            ShopPanel.SetActive(true);
        }

    }
    public void HideShop()
    {
        if (ShopPanel.activeSelf)
        {
            audioManager.PlaySound(audioManager.UiClick);
            print("Ocultando tienda");
            ShopPanel.SetActive(false);
        }
    }

    public void ShowOptions()
    {
        if (!OptionsPanel.activeSelf)
        {
            audioManager.PlaySound(audioManager.UiClick);
            print("Mostrando opciones");
            OptionsPanel.SetActive(true);
        }
    }
    public void HideOptions()
    {
        if (OptionsPanel.activeSelf)
        {
            audioManager.PlaySound(audioManager.UiClick);
            print("Ocultando opciones");
            OptionsPanel.SetActive(false);
        }
    }


  





}
