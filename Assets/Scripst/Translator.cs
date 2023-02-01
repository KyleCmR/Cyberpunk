using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Translator : MonoBehaviour
{
    private static int LanguageID;

    private static List<Translatable_text> listID = new List<Translatable_text>();

    #region Весь текст [двухмерный массив]
    private static string[,] LineText =
    {
        #region Английский
        {
            "New Game", //0
            "Continue", //1
            "Options",  //2
            "Quit",     //3
            "Back",     //4
            "Game Over",//5
            "Volume",   //6
            "Hero",     //7
            "Upgrade",  //8
            "Event",    //9
            "Store",    //10
            "Coins"     //11
        },
        #endregion

        #region Русский
        {
            "Новая Игра",
            "Продолжить",
            "Настройки",
            "Выход",
            "Назад",
            "Поражение",
            "Громкость",
            "Герой",
            "Улучшение",
            "Событие",
            "Магазин",
            "Монеты"
        },
        #endregion
    };
    #endregion


    static public void Select_Language (int id) // Выбор языка - Вызывается в скрипте стартового меню при старте и в функции выбора языка в настройках
    {
        LanguageID = id;
        Update_texts();
    }

    static public string Get_text(int textKey) // Получаем айди нашего текста из текущего языка (для вывода подсказок и т.д.) - пишем text.text = Translator.GetText(2);
    {
        return LineText[LanguageID, textKey];
    }

    static public void Add(Translatable_text idtext) // Добавляем в список
    {
        listID.Add(idtext);
    }
    
    static public void Delete(Translatable_text idtext) // Удаляем из списка
    {
        listID.Remove(idtext);
    }
    static public void Update_texts()
    {
        for (int i = 0; i < listID.Count; i++)
        {
            listID[i].UIText.text = LineText[LanguageID, listID[i].textID];
            //if (PlayerPrefs.GetInt("Language") == 1) listID[i].UIText.font = Resources.Load<TMP_FontAsset>("RU_font_asset");
            //else if (PlayerPrefs.GetInt("Language") == 2) listID[i].UIText.font = Resources.Load<TMP_FontAsset>("CH_font_asset");
            //else listID[i].UIText.font = Resources.Load<TMP_FontAsset>("EN_font_asset");
        }
    }
}
