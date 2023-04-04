using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item {
    public string name;
    public string description;
    public int amount;

    public Item(string _name, string _description, int _amount){
        name= _name;
        description = _description;
        amount = _amount;
    }
    public Item(){
     }
}