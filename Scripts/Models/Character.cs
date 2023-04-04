using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Character : ScriptableObject
{
    public new string name;
    public string description;

    public int level;

    public int proficiency;

    public int physicalAttack;
    public int physicalDefense;

    public int psychicAttack;
    public int psychicDefense;

    public int magicAttack;
    public int magicDefense;

    public int iniciative;
    public int desloc;

    public int PVmax;
    public int PV;

    public int criticalChance;
    public int criticalDamage;

    public Job job;
    public List<Action> JobActions;

    public Race race;

    /*
        0-Força         1-vitalidade    2-Constituição
        3-precisão      4-agilidade     5-instinto
        6-foco          7-conhecimento  8-vontade
        9-Arcana        10-Mana         11-Fortuna
        12-Empatia      13-Persuasão    14-Enganação
    */
    public int[] attributes = new int[15];

    public List<Item> itemList;



    public Action raceAction;
    public Action IdealsAction;
    public Action FlawAction;
    public Action BackgroundAction;
    public Action BoundsAction;
    public Action PersonalityAction;


}
