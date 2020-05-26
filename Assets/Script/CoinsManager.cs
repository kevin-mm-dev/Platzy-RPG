﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsManager : MonoBehaviour
{
    public Text moneyText;
    public int currentGold;
    const string goldKey="CurrentGold";
    
    // Start is called before the first frame update
    void Start()
    {
        ///Guardar datos
        if (PlayerPrefs.HasKey(goldKey))
        {
            currentGold=PlayerPrefs.GetInt(goldKey);
        }else{
            currentGold=0;
            PlayerPrefs.SetInt(goldKey,0);
        }
        moneyText.text=currentGold.ToString();
    }

    public void AddMoney(int moneyCollected){
        currentGold +=moneyCollected;
        PlayerPrefs.SetInt(goldKey,currentGold);
        moneyText.text=currentGold.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
