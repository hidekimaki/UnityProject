using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Character : ScriptableObject
{
    public new string name;
    public int proficiency;
    public int Armor;
    public int Iniciative;
    public int desloc;
    public int DV;
    public int PVmax;
    public int PV;
    public Job job;
    public Race race;

    /*
        0-Força         1-Destreza      2-Constituição
        3-Inteligência  4-Sabedoria     5-Carisma
    */
    public int[] attributes = new int[6];
    
    /*
        0-Força         1-Destreza      2-Constituição
        3-Inteligência  4-Sabedoria     5-Carisma
    */
    public int[] resistances = new int[6];

    public int[] skills = new int[18];

    /*
    0-Weapon
    1-Armor
    2-Accesories
    */
    public Equipment[] equipment = new Equipment[5];


}
