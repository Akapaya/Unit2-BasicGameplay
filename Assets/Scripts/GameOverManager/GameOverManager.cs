using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOver;

    public delegate void GameOverEvent();
    public static GameOverEvent GameOverHandle;

    private void OnEnable()
    {
        GameOverHandle += GameOverShow;
    }

    private void OnDisable()
    {
        GameOverHandle -= GameOverShow;
    }

    public void GameOverShow()
    {
        _gameOver.SetActive(true);
    }
}