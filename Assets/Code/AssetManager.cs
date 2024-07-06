using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetManager : MonoBehaviour
{
    [Header("PROJECT OR NO")]
    [SerializeField] bool Project;
    [SerializeField] GameObject number;
    [SerializeField] GameObject Tittle;
    [SerializeField] GameObject Description;
    private bool isActive, isAction, isProject;
    public void SetActive(bool active) => isActive = active;
    public void SetAction(bool action) => isAction = action;
    public void SetProject(bool project) => isProject = project;
    // Update is called once per frame
    void Update()
    {
        if (Project)
        {
            number.SetActive(isProject);
        }
        // Mengatur Tittle aktif atau nonaktif berdasarkan isActive
        Tittle.SetActive(isActive);

        // Mengatur Description aktif atau nonaktif berdasarkan isAction
        Description.SetActive(isAction);
    }
}
