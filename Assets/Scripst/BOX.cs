using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BOX : MonoBehaviour
{
    TextMeshProUGUI text;
    public float x = 666;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    public void UpdateTime(float time)
    {
        int minutes = (int)(time / 60f);
        int seconds = (int)(time % 60f);

        text.text = minutes.ToString() + ":" + seconds.ToString("00");
    }
}