using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestoy : MonoBehaviour
{
    [SerializeField] GameObject dropItemPrefab;
    [SerializeField][Range(0f, 1f)] float chanse = 1f;

    private void OnDestroy()
    {
        if (Random.value < chanse)
        {
            Transform t = Instantiate(dropItemPrefab).transform;
            t.position = transform.position;
        }
    }
}
