using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class costume : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] costumeFrames;
    public bool isSpecial;

    public Sprite GetFrame1() {
        return costumeFrames[0];
    }

    public Sprite GetFrame2()
    {
        return costumeFrames[1];
    }
}
