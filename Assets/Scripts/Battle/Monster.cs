﻿using UnityEngine;
using System.Collections;

public class Monster
{
    public string name;
    public Sprite mySprite;
    public string path = "Sprites/Combat/";
    public int lvl, atk, str, vit, dex, intl, luk, agi;

    public Monster()
    {
        // N I G G E R S 
    }

    public int DecideTurn()
    {
        return 1;
    }

}
