using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character 
{
    public string name;

    public Job job;

    public Race race;

    /*
    0-Força         1-Vitalidade    2-Resistencia
    3-Precisão      4-Evasão        5-Instinto
    6-Arcana        7-Mana          8-Sorte
    9-Foco          10-Estudo       11-Vontade
    12-Empatia      13-Persuasão    14-Enganação
    */
    public int[] attributes = new int[15];
    
    /*
    0-Vida          1-Defesa        2-Defesa Magica 3-              4-        
    5-Corpo         6-Senso         7-Alma          8-Mente         9-Social          
    */
    public int[] values = new int[10];

    /*
    0-Weapon
    1-Helmet
    2-Armor
    3-Boots
    4-Accesorie
    */
    public Equipment[] equipment = new Equipment[5];

    public void CalculateValues(){
        // Pontos de vida
        values[0] = attributes[1] * 10; 
        // Defesa
        values[1] = attributes[2] + attributes[4];
        // Defesa Mágica
        values[2] = attributes[7] + attributes[11];
        
        //Corpo
        values[5] = (int)(attributes[0] + attributes[1] + attributes[2])/3;
        //Senso
        values[5] = (int)(attributes[3] + attributes[4] + attributes[5])/3;
        //Alma
        values[5] = (int)(attributes[6] + attributes[7] + attributes[8])/3;
        //Mente
        values[5] = (int)(attributes[9] + attributes[10] + attributes[11])/3;
        //Social
        values[5] = (int)(attributes[12] + attributes[13] + attributes[14])/3;
    }


}
