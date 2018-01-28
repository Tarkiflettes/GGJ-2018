using System.Collections;
using UnityEngine;

public class Switch : Trigger
{
<<<<<<< HEAD
    private bool _busy = false;
    private bool on = false;
=======
    //private bool _busy = false;
>>>>>>> Florian

    public Rotator Rotator;
    public Vector3 Axis;
    public int Angle = 70;

    private bool turnedOn;

    protected override void Action()
    {
<<<<<<< HEAD
        var vector = Vector3.forward;

        Debug.Log(transform.rotation);

        if (on)
=======
        if(!turnedOn)
>>>>>>> Florian
        {
            Rotator.Open(Axis, Angle);
        }
        else
        {
<<<<<<< HEAD
            _busy = true;
            on = !on;
            var continuousRotation = ContinuousRotation(vector);
            StartCoroutine(continuousRotation);
=======
            Rotator.Close();
>>>>>>> Florian
        }
        turnedOn = !turnedOn;
    }
}