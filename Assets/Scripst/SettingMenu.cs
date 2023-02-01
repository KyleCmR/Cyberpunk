using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TextMeshProUGUI text;

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    
    private void Start()
    {
        if (PlayerPrefs.HasKey("Language") == false)
        {
            if (Application.systemLanguage == SystemLanguage.Russian) PlayerPrefs.SetInt("Language", 1);
            //else if (Application.systemLanguage == SystemLanguage.ChineseSimplified || Application.systemLanguage == SystemLanguage.ChineseTraditional) PlayerPrefs.SetInt("Language", 2); 
            else PlayerPrefs.SetInt("Language", 0); // английский
        }
        Translator.Select_Language(PlayerPrefs.GetInt("Language"));
    }
    public void Language_change(int languageID) //Смена языка
    {
        PlayerPrefs.SetInt("Language", languageID);
        Translator.Select_Language(PlayerPrefs.GetInt("Language"));
    }
    public void Show_text() //Вывод текста по нажатию кнопки
    {
        text.enabled = true;
        text.text = Translator.Get_text(4);
    }
}
