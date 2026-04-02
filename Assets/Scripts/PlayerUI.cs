using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Player player; // プレイヤーの参照
    [SerializeField] private Text titleText; // タイトルテキストの参照
    [SerializeField] private Text totalTimeText; // 総再生時間テキストの参照
    [SerializeField] private Text currentTimeText; // 現在の再生時間テキストの参照

    private void Update()
    {
        // プレイヤーが音声を再生しているかどうかをチェック
        if (player != null && player.IsPlayingAudio())
        {
            // タイトルテキストを更新
            titleText.text = "Playing: " + player.GetCurrentAudioTitle();
        }
        else
        {
            // タイトルテキストをリセット
            titleText.text = "No audio playing";
        }

        totalTimeText.text = "Total Time: " + player.GetTotalAudioTime().ToString("F2") + " seconds";
        currentTimeText.text = "Current Time: " + player.GetCurrentAudioTime().ToString("F2") + " seconds";
    }
}