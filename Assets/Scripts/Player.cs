using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// プレイヤーのクラス
/// </summary>
public class Player : MonoBehaviour
{
   [SerializeField] private AudioClip[] audioClips; // 音声クリップの配列
   [SerializeField] private AudioSource audioSource; // AudioSourceコンポーネント

    private void Start()
    {
        // AudioSourceコンポーネントを取得
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
        
    }

    private void Update()
    {
        // スペースキーが押されたときに音声を再生
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayRandomAudio();
        }

        // 右矢印キーが押されたときに次の音声を再生
        if(input.GetKeyDown(KeyCode.RightArrow))
        {
            NextAudio();
        }

        // 左矢印キーが押されたときに前の音声を再生
        if(input.GetKeyDown(KeyCode.LeftArrow))
        {
            PreviousAudio();
        }

        // Sキーが押されたときに音声を停止
        if(input.GetKeyDown(KeyCode.S))
        {
            StopAudio();
        }

        // Shiftキーが押されたときに音声の順番をシャッフル
        if(input.GetKeyDown(KeyCode.Shift))
        {
            ShuffleAudio();
        }

        // 音声が再生されていない場合に次の音声を自動で再生
        AutoPlayNextAudio();
    }

    private void AutoPlayNextAudio()
    {
        if (!audioSource.isPlaying)
        {
            NextAudio();
        }
    }

    /// <summary>
    /// ランダムな音声を再生するメソッド
    /// </summary>
    private void PlayRandomAudio()
    {
        if(audioClips.Length == 0) return; // 音声クリップがない場合は処理を終了

        if (audioClips.Length > 0)
        {
            // ランダムなインデックスを生成
            int randomIndex = Random.Range(0, audioClips.Length);
            // ランダムな音声クリップを再生
            audioSource.PlayOneShot(audioClips[randomIndex]);
        }
    }

    /// <summary>
    /// 次の音声を再生するメソッド
    /// </summary>
    private void NextAudio()
    {
        if(audioClips.Length == 0) return; // 音声クリップがない場合は処理を終了

        if(audioClips.Length > 0)
        {
            // 次のインデックスを生成
            int nextIndex = (System.Array.IndexOf(audioClips, audioSource.clip) + 1) % audioClips.Length;
            // 次の音声クリップを再生
            audioSource.PlayOneShot(audioClips[nextIndex]);
        }
    }

    /// <summary>
    /// 前の音声を再生するメソッド
    /// </summary>
    private void PreviousAudio()
    {
        if(audioClips.Length == 0) return; // 音声クリップがない場合は処理を終了

        if (audioClips.Length > 0)
        {
            // 前のインデックスを生成
            int previousIndex = (System.Array.IndexOf(audioClips, audioSource.clip) - 1 + audioClips.Length) % audioClips.Length;
            // 前の音声クリップを再生
            audioSource.PlayOneShot(audioClips[previousIndex]);
        }
    }

    /// <summary>
    /// 音声の再生を停止するメソッド
    /// </summary>
    private void StopAudio()
    {
        audioSource.Stop(); // 音声の再生を停止
    }

    /// <summary>
    /// 音声クリップの順番をシャッフルするメソッド
    /// </summary>
    private void ShuffleAudio()
    {
        if(audioClips.Length == 0) return; // 音声クリップがない場合は処理を終了

        // 音声クリップの順番をシャッフル
        for (int i = 0; i < audioClips.Length; i++)
        {
            int randomIndex = Random.Range(0, audioClips.Length);
            AudioClip temp = audioClips[i];
            audioClips[i] = audioClips[randomIndex];
            audioClips[randomIndex] = temp;
        }
    }
}