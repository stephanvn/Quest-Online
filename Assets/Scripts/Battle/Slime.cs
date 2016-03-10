using UnityEngine;
using System.Collections;

public class Slime : Monster {
    public GameObject myMob;

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
        GameObject obj = new GameObject("Monster");
        obj.transform.Translate(1, 0, 1);

        Sprite mySprite= Resources.Load("mob_slime") as Sprite;
        Debug.Log(mySprite);
        SpriteRenderer spr = obj.AddComponent<SpriteRenderer>();
        spr.sprite = mySprite;
    }

    public int DecideTurn()
    {
        return atk + str;
    }

}
