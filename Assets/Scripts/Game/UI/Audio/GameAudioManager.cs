using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    //SE

    //コマの衝突音
    static AudioSource s_hitSe;
    [SerializeField] AudioSource _hitSe;

    //ボタンの押したときの音
    static AudioSource s_buttonPushSe;
    [SerializeField] AudioSource _buttonPushSe;

    //勝利音
    static AudioSource s_winSe;
    [SerializeField] AudioSource _winSe;

    //敗北音
    static AudioSource s_loseSe;
    [SerializeField] AudioSource _loseSe;

    //カウントダウン
    static AudioSource s_countDownSe;
    [SerializeField] AudioSource _countDownSe;


    //BGM

    //タイトルBGM
    static AudioSource s_titleBgm;
    [SerializeField] AudioSource _titleBgm;

    //ゲームBGM
    static AudioSource s_gameBgm;
    [SerializeField] AudioSource _gameBgm;



    void Awake()
    {
        s_buttonPushSe = _buttonPushSe;
        s_hitSe = _hitSe;
        s_winSe = _winSe;
        s_loseSe = _loseSe;
        s_countDownSe = _countDownSe;
        s_titleBgm = _titleBgm;
        s_gameBgm = _gameBgm;
    }

    //SE
    public static void PlayHitSe()
    {
        s_hitSe.PlayOneShot(s_hitSe.clip);
    }

    public static void PlayPushButtonSe()
    {
        s_buttonPushSe.Play();
    }

    public static void PlayWinSe()
    {
        s_winSe.Play();
    }

    public static void PlayLoseSe()
    {
        s_loseSe.Play();
    }

    public static void PlayCountDownSe()
    {
        s_countDownSe.Play();
    }

    //BGM
    public static void PlayTitleBgm()
    {
        s_titleBgm.Play();
    }

    public static void PlayGameBgm()
    {
        s_gameBgm.Play();
    }



}
