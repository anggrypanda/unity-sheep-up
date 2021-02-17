using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioSource gameWin, gameLose, coinSound, jumpSound;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void GameWinSound()
    {
        gameWin.Play();
    }

    public void GameLoseSound()
    {
        gameLose.Play();
    }

    public void PickedUpCoin()
    {
        coinSound.Play();
    }

    public void JumpSound()
    {
        jumpSound.Play();
    }
}
