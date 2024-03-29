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
            Debug.LogWarning("������ ��������� ��������� ����");
            return;
        }

        if (Random.value < chanse)
        {
            GameObject toDrop = dropItemPrefab[Random.Range(0, dropItemPrefab.Count)];

            if (toDrop == null)
            {
                Debug.LogWarning("DropOnDestroy ������ �� ��������� ������� ����� ����! ������� ������, ������� ���������� �������� ��� ����������� Prefab!");
                return;
            }

            SpawnManager.instance.SpawnObject(transform.position, toDrop);
        }
    }
}
