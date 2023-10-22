using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //Default base stats - changeable in editor for objects
    [Header("Base Stats (at level 1)")]
    public int baseHP = 28;
    public int baseAttack = 6;
    public int baseMagic = 6;
    public int baseDefense = 6;
    public int baseMagicDefense = 6;
    public int baseSpeed = 4;

    [Header("Stat Growth")]
    public int growthFunction = 1;

    [Header("Current Stats")]
    public int level = 1;
    public int currentEXP = 0;
    public int cHP;
    public int cAtk;
    public int cMag;
    public int cDef;
    public int cMDef;
    public int cSpd;

    ///This script mainly contains stat calculation-related methods - Very little it'd be running in realtime

    //Initialises stats based on stat calculation function on object initialisation
    void Awake(){
        calcStats();
    }

    void levelUp(){
        if(canLevel()){
            level++;
            currentEXP = 0;
            calcStats();
        }
    }

    bool canLevel(){
        //Checks if character can level up or not
        int nextLevel = level*level*level;

        if(currentEXP>=nextLevel)
            return true;
        else
            return false;
                
    }


    ////STAT CALCULATION/////

    void calcStats(){
        //Decides which stat growth function to use and uses it
        switch(growthFunction){
            case 1:
                fighterGrowth();
                break;
            case 2:
                mageGrowth();
                break;
            case 3:
                healerGrowth();
                break;
        }
    }

    void fighterGrowth(){

        int over1 = level-1;

        cHP = baseHP + (over1*5);
        cAtk = baseAttack + (over1*5);
        cDef = baseDefense + (over1*3);
        cMag = baseMagic + (over1);
        cMDef = baseMagicDefense + (over1*2);
        cSpd = baseSpeed + ((int)Mathf.Round((float)over1*0.15f));

    }

    void mageGrowth(){

        int over1 = level-1;

        cHP = baseHP + (over1*3);
        cAtk = baseAttack + (over1*2);
        cDef = baseDefense + (over1*2);
        cMag = baseMagic + (over1*5);
        cMDef = baseMagicDefense + (over1*3);
        cSpd = baseSpeed + ((int)Mathf.Round((float)over1*0.1f));

    }

    void healerGrowth(){

        int over1 = level-1;

        cHP = baseHP + (over1*2);
        cAtk = baseAttack + (over1);
        cDef = baseDefense + (over1*2);
        cMag = baseMagic + (over1*4);
        cMDef = baseMagicDefense + (over1*2);
        cSpd = baseSpeed + ((int)Mathf.Round((float)over1*0.05f));

    }




}
