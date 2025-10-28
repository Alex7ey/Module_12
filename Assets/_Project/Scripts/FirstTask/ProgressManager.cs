using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    [SerializeField] private float _timeLimit;
    [SerializeField] private PickupItem[] _gameItems;
    [SerializeField] private Player _player;

    private GameTimer _gameTimer;
    private ItemCounter _itemCounter;

    private bool _isRunning = true;

    private void Awake()
    {
        _gameTimer = new(_timeLimit);
        _itemCounter = new(_gameItems);
    }

    private void Update()
    {
        if (_isRunning)
        {
            _gameTimer.TimeUpdate();
            ShowProgress();

            if (_itemCounter.IsGameItemsCollected())
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
        Debug.Log($"Осталось собрать {_itemCounter.GetActiveItemsCount()} энергии");
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
