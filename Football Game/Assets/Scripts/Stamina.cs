using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    [HideInInspector] public float stamina;
    [SerializeField] private Image staminaImage;
    private FootballMasterDataController controller;
    private bool isRegeneration;
    [SerializeField] private float timeBeforeRegeneration = 2;

    private void Awake()
    {
        controller = GetComponent<FootballMasterData>().controller;
        stamina = controller.stamina;
    }

    private void Update()
    {
        if (isRegeneration)
        {
            StaminaRegeneration();
        }
    }

    public void UseStamina(float quantity)
    {
        isRegeneration = false;
        AddStamina(quantity);
        StopAllCoroutines();
        StartCoroutine(UpdateStamina());
    }

    private void AddStamina(float quantity)
    {
        stamina -= quantity;
        staminaImage.fillAmount = stamina / controller.stamina;
        if (stamina<0)
        {
            stamina = 0;
        }
        else if(stamina>controller.stamina)
        {
            stamina = controller.stamina;
            isRegeneration = false;
        }
    }

    IEnumerator UpdateStamina()
    {
        yield return new WaitForSeconds(timeBeforeRegeneration);
        isRegeneration = true;
    }
    
    private void StaminaRegeneration()
    {
        AddStamina(-controller.staminaRegeneration);
    }
    
}
