using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLevelController : MonoBehaviour
{

    // 経験値とレベルの初期値を設定する
    [SerializeField] private int experience = 0;
    [SerializeField] private int level = 1;
    [SerializeField] private TMP_Text lvText;
    [SerializeField] private Slider expSlider;

    private void Start()
    {
        experience = 0;
        level = 1;
        expSlider.value = (float)experience / (float)LevelUpExperience(level);//スライダは0〜1.0で表現するため少数変換
        lvText.text = "LV " + level.ToString();
    }

    // 経験値を加算する
    public void AddExperience(int amount)
    {
        experience += amount;
        expSlider.value = (float)experience / (float)LevelUpExperience(level);//スライダは0〜1.0で表現するため少数変換

        // レベルアップの条件を満たす場合、レベルアップする
        if (experience >= LevelUpExperience(level))
        {
            level++;
            experience = 0;
            // レベルアップ時の報酬を処理する
            ProcessLevelUpRewards();
        }
        expSlider.value = (float)experience / (float)LevelUpExperience(level);//スライダは0〜1.0で表現するため少数変換
        lvText.text = "LV " + level.ToString();
    }

    // 次のレベルに必要な経験値を計算する
    private int LevelUpExperience(int level)
    {
        return level * 100;
    }

    // レベルアップ時の報酬を処理する
    private void ProcessLevelUpRewards()
    {
        // レベルアップ時の報酬を実装する
    }
}
