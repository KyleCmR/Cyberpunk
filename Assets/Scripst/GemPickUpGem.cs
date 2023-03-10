using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickUpGem : MonoBehaviour, PickUpObject
{
    [SerializeField] int amount;

    public void OnPickUp(Character character)
    {
        character.level.AddExperience(amount);
    }
}
