using HiddenWorld.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HiddenWorld.Journal
{
public class Journal : MonoBehaviour
{
    public GameObject enemyButton;
    public GameObject plantButton;
    public GameObject animalButton;

    public GameObject enemyStartPage;
    public GameObject plantStartPage;
    public GameObject animalStartPage;

    private HiddenWorldInputs _input;

    void Start()
    {
       _input = GetComponent<HiddenWorldInputs>();
    }

    // Update is called once per frame
    void Update()
    {
            if (_input.journal)
            {
                _input.journal = false;
            }
    }

    public void HideAllPages()
    {
        enemyStartPage.SetActive(false);
        plantStartPage.SetActive(false);
        animalStartPage.SetActive(false);
    }

    public void ShowEnemyStartPage()
    {
        HideAllPages();
        enemyStartPage.SetActive(true);
    }

    public void ShowPlantStartPage()
    {
        HideAllPages();
        plantStartPage.SetActive(true);
    }

    public void ShowAnimalStartPage()
    {
        HideAllPages();
        animalStartPage.SetActive(true);
    }
}
}

