using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int levelDifficulty;
    [SerializeField] int storyLevel;
    [SerializeField] int chapter;
    [SerializeField] List<GameObject> levels, stories;
    [SerializeField] List<LevelButtons> buttons;
    [SerializeField] GameObject levelPanel, levelMenu, warMenu, environment;
    [SerializeField] Button play, autoRestart, close, next, previous;
    [SerializeField] TMP_Dropdown difficulty;
    int storyIndex;
    void Start()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            for (int j = 0; j < buttons[i].buttons.Count; j++)
            {
                string name = buttons[i].buttons[j].transform.parent.name;
                int chapterId = j;
                int levelId = int.Parse(name.Substring(name.Length - 1, 1)) - 1;
                buttons[i].buttons[j].onClick.AddListener(delegate { LevelPanelShow(difficulty.value, levelId, chapterId); });
            }
        }
        play.onClick.AddListener(PlayGame);
        close.onClick.AddListener(CloseGamePanel);
        next.onClick.AddListener(NextStory);
        previous.onClick.AddListener(PreviousStory);
    }
    void Update()
    {
        
    }
    void LevelPanelShow(int levelDifficulty, int storyLevel, int chapter)
    {
        this.levelDifficulty = levelDifficulty;
        this.storyLevel = storyLevel;
        this.chapter = chapter;
        levelPanel.SetActive(true);
    }
    void PlayGame() 
    {
        levelMenu.SetActive(false);
        warMenu.SetActive(true);
        environment.SetActive(true);
        foreach (var level in levels)
        {
            level.SetActive(false);
        }
        levels[chapter].SetActive(true);
    }
    void CloseGamePanel()
    {
        levelPanel.SetActive(false);
    }
    void StoryClose()
    {
        foreach (var story in stories)
        {
            story.SetActive(false);
        }
    }
    void NextStory()
    {
        StoryClose();
        storyIndex++;
        storyIndex = storyIndex > stories.Count - 1 ? stories.Count - 1 : storyIndex;
        stories[storyIndex].SetActive(true);
    }
    void PreviousStory()
    {
        StoryClose();
        storyIndex--;
        storyIndex = storyIndex < 0 ? 0 : storyIndex;
        stories[storyIndex].SetActive(true);
    }
}
[Serializable]
public class LevelButtons
{
    public List<Button> buttons;
}
