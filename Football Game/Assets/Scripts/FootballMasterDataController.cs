using System;
using UnityEngine;

[CreateAssetMenu(fileName = "FootballMasterDataController", menuName = "My Game/FootballMaster/FootballMasterDataController")]
public class FootballMasterDataController : ScriptableObject
{
    public String name;
    public String description;
    public float speed;
    public float stamina;
    public float staminaRegeneration;
    public float power;
}
