using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class RewardVid : MonoBehaviour
{
    [SerializeField] private Button RewardButton;
    private int HP;

    private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;
    private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;

    private void Awake()
    {
        RewardButton.onClick.AddListener(delegate { ExampleOpenRewardAd(1); });
    }
    private void Update()
    {
        HP = PlayerPrefs.GetInt("HP");
    }
    void Rewarded(int id)
    {
        if (id == 1)
        {
            Debug.LogWarning("Получено: " + HP);
        }
    }
    void ExampleOpenRewardAd(int id)
    {
       // PlayerPrefs.SetFloat("HP", 10);
        YandexGame.RewVideoShow(id);
        PlayerPrefs.SetFloat("HP", 10);

    }
}
