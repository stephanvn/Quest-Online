using UnityEngine;
using System.Collections;

public class Slime : Monster {

    public Slime()
    {
        name = "Slime";
        lvl = 1;
        atk = 2;
        str = 1;
        intl= 0;
        vit = 1;
        agi = 1;
        dex = 1;
    }

    public int DecideTurn()
    {
        return atk + str;
    }

}
