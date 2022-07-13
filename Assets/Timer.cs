using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update

    TextMeshProUGUI timing;
    public float time;

    private void Awake()
    {
        timing = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timing.text = "Timer: " + time;
    }
}
