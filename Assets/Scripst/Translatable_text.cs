using TMPro;
using UnityEngine;

public class Translatable_text : MonoBehaviour
{
    public int textID;
    [HideInInspector] public TextMeshProUGUI UIText;

    private void Awake()
    {
        UIText = GetComponent<TextMeshProUGUI>();
        Translator.Add(this);
    }
    private void OnEnable()
    {
        Translator.Update_texts();
    }
    private void OnDestroy()
    {
        Translator.Destroy(this);
    }
}
