using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChoose : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OpenCarosLevel()
    {
        SceneManager.LoadScene("CarosLevel");
    }

    void OpenPerosLevel()
    {
        SceneManager.LoadScene("PerosLevel");
    }
}
