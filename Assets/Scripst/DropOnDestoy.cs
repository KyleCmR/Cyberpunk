using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestoy : MonoBehaviour
{
    [SerializeField] List<GameObject> dropItemPrefab;
    [SerializeField][Range(0f, 1f)] float chanse = 1f;

    bool isQuitting = false;

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    public void CheckDrop()
    {
        if (isQuitting) { return; }

        if(dropItemPrefab.Count <=0)
        {
            Debug.LogWarning("список удаляемых элементов пуст");
            return;
        }

        if (Random.value < chanse)
        {
            GameObject toDrop = dropItemPrefab[Random.Range(0, dropItemPrefab.Count)];

            if (toDrop == null)
            {
                Debug.LogWarning("DropOnDestroy ссылка на удаляемый элемент равна нулю! Проверь объект, который сбрасывает предметы при уничтожении Prefab!");
                return;
            }

            SpawnManager.instance.SpawnObject(transform.position, toDrop);
        }
    }
}
