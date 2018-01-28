using UnityEngine;

public class Chest : Triggered {

    public Rotator Rotator;
    private bool _opened;
    public Vector3 Axis;

    [ContextMenu("Open")]
    public override void Action()
    {
        if(!_opened)
        {
            Debug.Log("Rotate");
            Rotator.Open(Axis, 50);
        } else
        {
            Rotator.Close();
        }
        _opened = !_opened;
    }
}
