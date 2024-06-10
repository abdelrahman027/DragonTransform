using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] int sceneNumber;
    // Start is called before the first frame update
    void Start()
    {
        sceneNumber = System.Convert.ToInt32(SceneManager.GetActiveScene().name);
        if (PlayerPrefs.GetInt("LastLevel") == 0)
        {
            PlayerPrefs.SetInt("LastLevel", 1);
        }
        if (PlayerPrefs.GetInt("LastLevel")!=sceneNumber)
        {
           SceneManager.LoadScene(PlayerPrefs.GetInt("LastLevel").ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(sceneNumber.ToString());
    }
    public void NextScene()
    {
        int LastLevel =PlayerPrefs.GetInt("LastLevel");
        if (sceneNumber+1 > LastLevel)
        {
            PlayerPrefs.SetInt("LastLevel", sceneNumber + 1);
        }
        SceneManager.LoadScene((sceneNumber + 1).ToString());
    }
}
