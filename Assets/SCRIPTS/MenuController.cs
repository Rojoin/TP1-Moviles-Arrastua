using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]private CanvasGroup credits;
    [SerializeField]private CanvasGroup Menu;
    [SerializeField]private CanvasGroup ChooseDifficulty;

    private void Start()
    {
        SoundManager.Instance.PlayMainMenuMusic();
    }

    public void SetSinglePlayer()
    {
        GameControllerSettings.Instance.setGameMode(GameControllerSettings.GameMode.Single);
    }
    public void SetDoublePlayer()
    {
        GameControllerSettings.Instance.setGameMode(GameControllerSettings.GameMode.Double);
    }
    public void SetEasyDifficulty()
    {
        GameControllerSettings.Instance.setDifficulty(GameControllerSettings.Difficulty.Easy);
    }
    public void SetMediumDifficulty()
    {
        GameControllerSettings.Instance.setDifficulty(GameControllerSettings.Difficulty.Medium);
    } 
    public void SetHardDifficulty()
    {
        GameControllerSettings.Instance.setDifficulty(GameControllerSettings.Difficulty.Hard);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("ESCENAS/conduccion9");
    }
    public void OpenCredits()
    {
        ChangeSettings(credits,true);
        ChangeSettings(Menu,false);
        ChangeSettings(ChooseDifficulty,false);
    }
    public void OpenMenu()
    {
        ChangeSettings(Menu,true);
        ChangeSettings(credits,false);
        ChangeSettings(ChooseDifficulty,false);
    }
    public void OpenDifficulty()
    {
        ChangeSettings(Menu,false);
        ChangeSettings(credits,false);
        ChangeSettings(ChooseDifficulty,true);
    }
    

    private void ChangeSettings(CanvasGroup canvas, bool state)
    {
        canvas.interactable = state;
        canvas.blocksRaycasts = state;
        canvas.alpha = state ? 1 : 0;
    }
}