using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPanelManager : MonoBehaviour
{
    [SerializeField] private Button resetButton;
    [SerializeField] private Button titleButton;
    private void OnEnable()
    {
        resetButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("BattleScene");
        });

        titleButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("TitleScene");
        });
    }
}
