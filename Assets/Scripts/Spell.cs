using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [Header("Properties")]
    string name;
    bool phys;
    bool heals;
    int power;
    int cost;
    float aoeRadius;

    //Doubt I need a full GameObject for something as small and dinky as a spell
    public Spell(string name, bool phys, bool heals, int power, int cost, float aoeRadius)
    {
        this.name = name;
        this.phys = phys;
        this.heals = heals;
        this.power = power;
        this.cost = cost;
        this.aoeRadius = aoeRadius;
    }

    public Spell(string name, bool phys, bool heals, int power, int cost)
    {
        this.name = name;
        this.phys = phys;
        this.heals = heals;
        this.power = power;
        this.cost = cost;
        this.aoeRadius = 0;
    }

    public Spell(string name, bool phys, int power, int cost, float aoeRadius)
    {
        this.name = name;
        this.phys = phys;
        this.heals = false;
        this.power = power;
        this.cost = cost;
        this.aoeRadius = aoeRadius;
    }

    public Spell(string name, bool phys, int power, float aoeRadius)
    {
        this.name = name;
        this.phys = phys;
        this.heals = false;
        this.power = power;
        this.cost = 0;
        this.aoeRadius = aoeRadius;
    }

    public Spell(string name, bool phys, int power)
    {
        this.name = name;
        this.phys = phys;
        this.heals = false;
        this.power = power;
        this.cost = 0;
        this.aoeRadius = 0;
    }

}
