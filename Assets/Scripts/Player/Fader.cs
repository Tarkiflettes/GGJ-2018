using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour {

    public float Speed = 5f;
    private float _fadeIntensity;
    private Color _color;
    private bool _fadeIn;

    // Use this for initialization
    void Start () {
        _color = GetComponent<Renderer>().material.color;
    }

    public void Fade(float fadeIntensity)
    {
        _fadeIntensity = fadeIntensity/255f;
        if (_color.a < fadeIntensity)
        {
            StartCoroutine(FadeIn());
        } else
        {
            StartCoroutine(FadeOut());
        }
    }

    private void FadeColor(float sens)
    {
        _color.a += sens * (1f / 255f) * Speed;
        GetComponent<Renderer>().material.color = _color;
        
    }

    IEnumerator FadeIn()
    {
        _fadeIn = true;
        while (_color.a < _fadeIntensity && _fadeIn)
        {
            FadeColor(0.5f);
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator FadeOut()
    {
        _fadeIn = false;
        while (_color.a > _fadeIntensity && !_fadeIn)
        {
            FadeColor(-1);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
