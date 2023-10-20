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
    int currentEXP = 0;
    int cHP;
    int cAtk;
    int cMag;
    int cDef;
    int cMDef;
    int cSpd;

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

        cHP = baseHP + (level*5);
        cAtk = baseAttack + (level*5);
        cDef = baseDefense + (level*3);
        cMag = baseMagic + (level);
        cMDef = baseMagicDefense + (level*2);
        cSpd = baseSpeed + ((int)Mathf.Round((float)level*0.15f));

    }

    void mageGrowth(){

        cHP = baseHP + (level*3);
        cAtk = baseAttack + (level*2);
        cDef = baseDefense + (level*2);
        cMag = baseMagic + (level*5);
        cMDef = baseMagicDefense + (level*3);
        cSpd = baseSpeed + ((int)Mathf.Round((float)level*0.1f));

    }

    void healerGrowth(){

        cHP = baseHP + (level*2);
        cAtk = baseAttack + (level);
        cDef = baseDefense + (level*2);
        cMag = baseMagic + (level*4);
        cMDef = baseMagicDefense + (level*2);
        cSpd = baseSpeed + ((int)Mathf.Round((float)level*0.05f));

    }




}
