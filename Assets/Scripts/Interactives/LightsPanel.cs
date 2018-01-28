using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsPanel : Triggered {

    public LightSystem[] Systemes;

    public override void Action()
    {
        StartCoroutine(Pattern());
    }

    IEnumerator Pattern()
    {
        while(true)
        {
            foreach (LightSystem light in Systemes)
            {
                StartCoroutine(light.ChangeColor());
                yield return new WaitForSeconds((1f+2*light.TimeBetweenLights)* light.NbClignotements);
            }
            yield return new WaitForSeconds(3f);
        }
    }
}
