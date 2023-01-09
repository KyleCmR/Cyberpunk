using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealUpPickUpObject : MonoBehaviour, PickUpObject
{
    [SerializeField] int healAmount;
    public void OnPickUp(Character character)
    {
        character.Heal(healAmount);
    }
}
