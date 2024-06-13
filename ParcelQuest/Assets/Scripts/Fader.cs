using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    public static Fader i { get; private set; }
    Image image;
    private void Awake()
    {
        i = this;
        image = GetComponent<Image>();
    }

    public IEnumerator FadeIn(float time)
    {
        yield return image.DOFade(2f, time).WaitForCompletion();
    }

    public IEnumerator FadeOut(float time)
    {
        yield return image.DOFade(0f, time).WaitForCompletion();
    }

    public void FadeIn()
    {
        StartCoroutine(FadeIn(2f));
    }
    public void FadeOut()
    {
        StartCoroutine(FadeOut(2f));
    }

}
