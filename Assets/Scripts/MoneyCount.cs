using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCount : MonoBehaviour
{
    //Singleton
    public static MoneyCount current;

    //UI
    public Text moneyNeededTxt;
    public Text HammerLevel;

    //Money count
    int currentMoney = 0;
    int moneyNeeded;

    //HammerLvl
    public int hammerLvl = 0;

    //MoneyLvl
    int lvl1 = 500;
    int lvl2 = 1000;
    int lvl3 = 1750;

    private void Awake()
    {
        current = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        moneyNeeded = lvl1 - currentMoney;
        moneyNeededTxt.text = "Money needed to \n reach next level : " + moneyNeeded;
    }

    public void GiveMoney(int amout)
    {

        currentMoney += amout;

        if(hammerLvl < 1)
        {
            if(currentMoney >= lvl1)
            {
                currentMoney = 0;
                moneyNeeded = lvl2 - currentMoney;
                hammerLvl = 1;
                HammerLevel.text = "Hammer level : " + hammerLvl;
            }
            else
            {
                moneyNeeded = lvl1 - currentMoney;
            }
            moneyNeededTxt.text = "Money needed to \n reach next level : " + moneyNeeded;
        }
        if (hammerLvl == 1)
        {
            if (currentMoney >= lvl2)
            {
                currentMoney = 0;
                moneyNeeded = lvl3 - currentMoney;
                hammerLvl = 2;
                HammerLevel.text = "Hammer level : " + hammerLvl;
            }
            else
            {
                moneyNeeded = lvl2 - currentMoney;
            }
            moneyNeededTxt.text = "Money needed to \n reach next level : " + moneyNeeded;
        }
        if (hammerLvl == 2)
        {
            if (currentMoney >= lvl3)
            {
                currentMoney = 0;
                moneyNeededTxt.text = "Hammer max level";
                hammerLvl = 3;
                HammerLevel.text = "Hammer level : " + hammerLvl;
            }
            else
            {
                moneyNeeded = lvl3 - currentMoney;
                moneyNeededTxt.text = "Money needed to \n reach next level : " + moneyNeeded;
            }

        }
    }
}
