using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text name;
    public Text level;
    public Text coin;

    public GameObject[] item;

    // Start is called before the first frame update
    void Start()
    {
        name.text += DataManager.instance.nowPlayer.name;
        level.text += DataManager.instance.nowPlayer.level.ToString();
        coin.text += DataManager.instance.nowPlayer.coin.ToString();
        ItemSetting(DataManager.instance.nowPlayer.item);
    }

    public void LevelUp()
    {
        DataManager.instance.nowPlayer.level++;
        level.text = "레벨 : " + DataManager.instance.nowPlayer.level.ToString();
    }

    public void CoinUp()
    {
        DataManager.instance.nowPlayer.coin += 100;
        coin.text = "코인 : " + DataManager.instance.nowPlayer.coin.ToString();
    }

    public void Save()
    {
        DataManager.instance.SaveData();
    }

    public void ItemSetting(int number)
    {
        for (int i = 0; i < item.Length; i++)
        {
            if (number == i)
            {
                item[i].SetActive(true);
                DataManager.instance.nowPlayer.item = number;
            }
            else
            {
                item[i].SetActive(false);
            }
        }
    }
}