using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongLaser_weapon : MonoBehaviour
{
    public GameObject PlayerCharacter;
    private void Start()
    {
        PlayerCharacter = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        transform.position = PlayerCharacter.transform.position;
    }
    private void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (rotationZ < -90 || rotationZ > 90)
        {
            if (PlayerCharacter.transform.eulerAngles.y == 0)
            {
                transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);
            }    
            else if (PlayerCharacter.transform.eulerAngles.y == 180)
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);
            }
        }
    }
}
