using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorCycle : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer spriteRend;
    private Image image;

    bool usingImage;

    Color lerpedColor = Color.white;
    void Start()
    {
        if (GetComponent<Image>() != null)
        {
            usingImage = true;
            image = GetComponent<Image>();
        }
        else
        {
            usingImage = false;
            spriteRend = GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        lerpedColor = Color.Lerp(Color.cyan, Color.yellow, Mathf.PingPong(Time.time * .8f, 1));
        if (usingImage)
        {
            image.color = lerpedColor;
        }
        else
        {
            spriteRend.color = lerpedColor;
        }
    }
}
