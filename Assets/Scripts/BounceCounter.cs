using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BounceCounter : MonoBehaviour
{
    private int bounces = 0;
    private TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();   
    }

    public void updateCounter() {
        ++bounces;
        text.text = $"Bounces: {bounces / 2}";
    }
}
