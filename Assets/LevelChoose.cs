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

    public void OpenCarosLevel()
    {
        SceneManager.LoadScene("CaroLevel");
    }

    public void OpenPerosLevel()
    {
        SceneManager.LoadScene("PeroLevel");
    }


}