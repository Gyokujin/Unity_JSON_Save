using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Select : MonoBehaviour
{
    public GameObject creat;
    public Text[] slotText;
    public Text newPlayerName;

    bool[] savefile = new bool[3];

    // Start is called before the first frame update
    void Start()
    {
        // 슬롯별로 저장된 데이터가 존재하는지 판단.
        for (int i = 0; i < 3; i++)
        {
            if (File.Exists(DataManager.instance.path + $"{i}"))
            {
                savefile[i] = true;
                DataManager.instance.nowSlot = i;
                DataManager.instance.LoadData();
                slotText[i].text = DataManager.instance.nowPlayer.name;
            }
            else
            {
                slotText[i].text = "비어있음";
            }
        }
        DataManager.instance.DataClear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // 슬롯이 3개인데 어떻게 알맞게 불러오느냐?
    public void Slot(int number)
    {
        DataManager.instance.nowSlot = number;

        if (savefile[number])
        {
            DataManager.instance.LoadData();
            GoGame();
        }
        else
        {
            Creat();
        }
    }

    public void Creat()
    {
        creat.gameObject.SetActive(true);
    }

    public void GoGame()
    {
        if (!savefile[DataManager.instance.nowSlot])
        {
            DataManager.instance.nowPlayer.name = newPlayerName.text;
            DataManager.instance.SaveData();
        }

        SceneManager.LoadScene(1);
    }
}