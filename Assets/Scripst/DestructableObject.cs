using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour, IDamagleble
{
    public void TakeDamage(int damage)
    {
        Destroy(gameObject);
        GetComponent<DropOnDestoy>().CheckDrop();
    }
}
