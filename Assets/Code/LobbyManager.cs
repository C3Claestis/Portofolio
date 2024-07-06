using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LobbyManager : MonoBehaviour
{
    [Header("CORRECT GENDER")]
    [SerializeField] GameObject correctMale, correctFemale;
    [Header("CORRECT TIME")]
    [SerializeField] GameObject correctSun, correctMoon, correctSunset;

    void Start()
    {
        if (PlayerPrefs.GetInt("Time") == 0)
        {
            PlayerPrefs.SetInt("Time", 1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        GenderUpdate();

        TimeUpdate();
    }
    void GenderUpdate()
    {
        if (PlayerPrefs.GetInt("Gender") == 0)
        {
            correctMale.SetActive(true);
            correctFemale.SetActive(false);
        }
        else
        {
            correctMale.SetActive(false);
            correctFemale.SetActive(true);
        }
    }
    void TimeUpdate()
    {
        if (PlayerPrefs.GetInt("Time") == 1)
        {
            correctMoon.SetActive(false);
            correctSun.SetActive(true);
            correctSunset.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Time") == 2)
        {
            correctMoon.SetActive(true);
            correctSun.SetActive(false);
            correctSunset.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Time") == 3)
        {
            correctMoon.SetActive(false);
            correctSun.SetActive(false);
            correctSunset.SetActive(true);
        }
    }
    public void ScenePlay()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Time"));
    }

    public void Gender(int index)
    {
        PlayerPrefs.SetInt("Gender", index);
    }
    public void Time(int index)
    {
        PlayerPrefs.SetInt("Time", index);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
