using System.Collections;
using UnityEngine;

public class LightSystem : MonoBehaviour
{
    public int NbClignotements;
    public float TimeBetweenLights;
    public Fader Fader;

    public IEnumerator ChangeColor()
    {
        for (int i = 0; i<NbClignotements; i++)
        {
            Fader.Fade(255);
            yield return new WaitForSeconds(TimeBetweenLights);
            Fader.Fade(0);
            yield return new WaitForSeconds(TimeBetweenLights);

        }
    }

}
