using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneTable : RayReceiver {

    public GameObject[] Runes;
    public Pickable[] RunesPickables;
    public Animator TableCenterAnimator;
    public Player Player;

    private int _nbRunePlaced;

    protected override void OnRayEnter()
    {

    }

    protected override void OnRayExit()
    {
    }

    protected override void OnRaySelect()
    {
        foreach (Pickable rune in RunesPickables)
        {
            if(Player.Inventory.Contains(rune))
            {
                Player.Inventory.RemovePickable(rune); 
                Runes[_nbRunePlaced++].SetActive(true);
                if(_nbRunePlaced == Runes.Length)
                {
                    new WaitForSeconds(1f);
                    TableCenterAnimator.SetTrigger("Open");
                }
            }

        }
    }
}
