using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public int levelDifficulty;
    public int storyLevel;
    public int chapter;
    [SerializeField] List<GameObject> stories;
    public List<StoryLevels> levels;
    [SerializeField] List<LevelButtons> buttons;
    [SerializeField] List<Image> stars;
    [SerializeField] List<int> storyStars;
    [SerializeField] GameObject levelPanel, levelMenu, warMenu, environment;
    [SerializeField] Button play, autoRestart, close, next, previous;
    public TMP_Dropdown difficulty;
    int storyIndex;
    void Start()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            for (int j = 0; j < buttons[i].buttons.Count; j++)
            {
                LevelUIInfo levelUIInfo = buttons[i].buttons[j].GetComponent<LevelUIInfo>();
                //string name = buttons[i].buttons[j].transform.parent.name;
                //int chapterId = j;
                //int storyLevelId = int.Parse(name.Substring(name.Length - 1, 1)) - 1;
                buttons[i].buttons[j].onClick.AddListener(delegate { LevelPanelShow(difficulty.value, levelUIInfo); });
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
    public void ValueChanged()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            for (int j = 0; j < buttons[i].buttons.Count; j++)
            {
                LevelUIInfo levelUIInfo = buttons[i].buttons[j].GetComponent<LevelUIInfo>();
                if (levelUIInfo.completed[difficulty.value])
                {
                    levelUIInfo.transform.GetChild(0).gameObject.SetActive(false);
                }
                else
                {
                    levelUIInfo.transform.GetChild(0).gameObject.SetActive(true);
                }
            }
        }
    }
    void LevelPanelShow(int levelDifficulty, LevelUIInfo levelUIInfo)
    {
        //Oyun bitince eklenecek
        levels[levelUIInfo.storyLevel].levels[levelUIInfo.chapter].SetActive(false);
        //
        //int newChapter = 0;
        //int newStoryLevel = 0;
        //if (chapter == 0)
        //{
        //    newStoryLevel--;
        //    newStoryLevel = Math.Clamp(newStoryLevel, 0, stories.Count);
        //}
        //else
        //{
        //    c
        //}
        if (!levelUIInfo.transform.GetChild(0).gameObject.activeSelf)
        {
            this.levelDifficulty = levelDifficulty;
            storyLevel = levelUIInfo.storyLevel;
            chapter = levelUIInfo.chapter;

            for (int i = 0; i < stars.Count; i++)
            {
                if (i < levelUIInfo.star)
                {
                    stars[i].fillAmount = 1;
                }
                else
                {
                    stars[i].fillAmount = 0;
                }
            }
            levelPanel.SetActive(true);
        }
    }
    void PlayGame() 
    {
        levelMenu.SetActive(false);
        warMenu.SetActive(true);
        environment.SetActive(true);
        levels[storyLevel].levels[chapter].SetActive(true);
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
[Serializable]
public class StoryLevels
{
    public List<GameObject> levels;
}
