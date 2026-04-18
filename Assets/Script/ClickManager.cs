using UnityEngine;
using UnityEngine.UI;
using System;

public class ClickManager : MonoBehaviour
{
    [SerializeField] private AudioManagerScript audioManager;

    [SerializeField] private GuiManager guiManager;

    [SerializeField] private InventoryScript inventory;

    [SerializeField] private SwordGenerator swordGenerator;

    [SerializeField] private int progressMax = 10;
    [field: SerializeField] public int Progress { get; private set; } = 0;
    [field: SerializeField] public int Increment { get; set; } = 1;

   



    public void Pulsar()
    {
        audioManager.PlaySound(audioManager.AnvilClick);
        Pulse(Increment + inventory.CreationSpeedUpgrade);
        Debug.Log("Progreso actual: " + Progress);
    }


    public void Pulse(int cantidad)
    {
        
        Progress += cantidad;
        guiManager.ActualizarBarraProgreso(Progress);

        if (Progress >= progressMax)
        {
            ProgressComplete();

        }
    }
    
    
    public void ProgressComplete()
    {
        Debug.Log ("¡Progreso completo!");

        
        Reward();

        ResetProgress();

    }
    
    
    public void ResetProgress()
    {
        Progress = 0;
        guiManager.ActualizarBarraProgreso(Progress);
    }


    public void Reward()
    {
         guiManager.WeaponRewardChange();
    }
}
