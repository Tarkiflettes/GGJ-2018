using System.Collections;
using UnityEngine;

public class Switch : Trigger
{
    public Rotator Rotator;
    public Vector3 Axis;
    public int Angle = 70;

    private bool turnedOn;

    protected override void Action()
    {
        if(!turnedOn)
        {
            Rotator.Open(Axis, Angle);
        }
        else
        {
            Rotator.Close();
        }
        turnedOn = !turnedOn;
    }
}