using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.NetworkSystem;

public class Scale : Trigger
{
    
    public int WaitingTime = 500;
    public float IntervalAngle = 0.2f;
    public float MaxAngle = 45;

    private bool _busy = false;

    void Update()
    {
        Debug.Log(transform.eulerAngles.x);
        if (transform.eulerAngles.x > MaxAngle && transform.eulerAngles.x < 180)
            transform.eulerAngles = new Vector3(MaxAngle, 0, 0);
        if (transform.eulerAngles.x < -MaxAngle && transform.eulerAngles.x > 180)
            transform.eulerAngles = new Vector3(-MaxAngle, 0, 0);

        if (Equals() && !_busy)
        {
            var timer = Timer();
            StartCoroutine(timer);
        }
    }

    private IEnumerator Timer()
    {
        for (var i = 0; i < WaitingTime; i++)
        {
            if (!Equals())
            yield break;
            yield return new WaitForSeconds(0.01f);
        }
        Action();
    }

    private bool Equals()
    {
        if (transform.rotation.eulerAngles.x > -IntervalAngle && transform.rotation.eulerAngles.x < IntervalAngle)
            return true;
        return false;
    }

    protected override void Action()
    {
        Triggering();
    }
}
