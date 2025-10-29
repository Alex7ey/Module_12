using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    [SerializeField] private float _timeLimit;
    [SerializeField] private Coin[] _gameItems;
    [SerializeField] private Player _player;
    [SerializeField] private Wallet _wallet;

    private GameTimer _gameTimer;

    private bool _isRunning = true;
    private int _coinsQuota;

    private void Awake()
    {
        _gameTimer = new(_timeLimit);
        _coinsQuota = _gameItems.Length;
    }

    private void Update()
    {
        if (_isRunning)
        {
            _gameTimer.TimeUpdate();
            ShowProgress();

            if (_wallet.GetCoinCount() >= _coinsQuota)
            {
                WinGame();
                return;
            }
            else if (_gameTimer.IsTimeUp())
            {
                LoseGame();
                return;
            }
        }
    }

    private void ShowTime()
    {
        Debug.Log($"У вас осталось {_gameTimer.RemainingTime} секунд");
    }

    private void ShowNumberActiveObjects()
    {
        Debug.Log($"Осталось собрать {_coinsQuota - _wallet.GetCoinCount()} энергии");
    }

    private void ShowProgress()
    {
        ShowTime();
        ShowNumberActiveObjects();
    }

    private void LoseGame()
    {
        _isRunning = false;
        _player.Die();
        Debug.Log("Вы проиграли!");
    }

    private void WinGame()
    {
        _isRunning = false;
        Debug.Log("Вы победили!");
    }
}
