using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ImageFill : MonoBehaviour
{
    Image _image;

    [SerializeField, Range(0,1)]
    float _fillValue = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        _image.type = Image.Type.Filled;
    }

    // Update is called once per frame
    void Update()
    {
        _image.fillAmount = _fillValue;
    }
}
