using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageFade : MonoBehaviour
{
    [SerializeField] float _fadeTime = 1.0f;

    Image _image;

    void Awake()
    {
        _image = GetComponent<Image>();
    }

    // 0 alpha to 100 alpha
    public void FadeOut()
    {
        StopCoroutine(nameof(Fade));
        StartCoroutine(nameof(Fade), true);
    }

    // 100 alpha to 0
    public void FadeIn()
    {
        StopCoroutine(nameof(Fade));
        StartCoroutine(nameof(Fade), false);
    }

    IEnumerator Fade(bool fadeIn)
    {
        // Start color
        var startColor = new Color(
            _image.color.r,
            _image.color.g,
            _image.color.b,
            fadeIn ? 0 : 1f
        );

        var targetColor = new Color(
            _image.color.r,
            _image.color.g,
            _image.color.b,
            fadeIn ? 1f : 0
        );

        var elapsedTime = 0f;

        while (elapsedTime < _fadeTime)
        {
            _image.color = Color.Lerp(
                startColor, 
                targetColor, 
                elapsedTime / _fadeTime
            );
            yield return null;

            elapsedTime += Time.deltaTime;
        }

        _image.color = targetColor;
    }
}
