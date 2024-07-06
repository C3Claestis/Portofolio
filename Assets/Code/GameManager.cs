using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int indexGender;
    [SerializeField] GameObject pria, wanita;
    [SerializeField] GameObject pause;
    // Start is called before the first frame update
    void Start()
    {
        indexGender = PlayerPrefs.GetInt("Gender");

        if (indexGender == 1)
        {
            Instantiate(wanita, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(pria, transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void FollowLink(string link)
    {
        Application.OpenURL(link);
    }
}
