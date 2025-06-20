using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScript : MonoBehaviour
{
    private int playerLevel = 1;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject levelsPanel;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private List<Button> levelButtons;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("playerLevel"))
        {
            PlayerPrefs.SetInt("playerLevel", 1);
            PlayerPrefs.Save();
        }
        playerLevel = PlayerPrefs.GetInt("playerLevel");

        for (int i = playerLevel; i < levelButtons.Count; i++)
        {
            levelButtons[i].interactable = false;
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(playerLevel);
    }

    public void Levels()
    {   
        mainPanel.SetActive(false);
        levelsPanel.SetActive(true);
    }

    public void Credits()
    {
        mainPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void openLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Back(GameObject panel)
    {
        panel.SetActive(false);
        mainPanel.SetActive(true);
    }
}
