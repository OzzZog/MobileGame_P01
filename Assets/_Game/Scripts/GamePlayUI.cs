using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayUI : MonoBehaviour
{
    public static GameObject ShowUI(GameObject _gameUI)
    {
        _gameUI.SetActive(true);
        return _gameUI;
    }

    public static GameObject HideUI(GameObject _setupUI)
    {
        _setupUI.SetActive(false);
        return _setupUI;
    }
    // 0 = SetupUI, 1 = GamePlayUI, 2 = WinUI, 3 = LoseUI

    public void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
