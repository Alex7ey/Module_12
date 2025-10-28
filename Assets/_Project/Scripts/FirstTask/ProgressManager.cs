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
        Debug.Log($"� ��� �������� {_gameTimer.RemainingTime} ������");
    }

    private void ShowNumberActiveObjects()
    {
        Debug.Log($"�������� ������� {_itemCounter.GetActiveItemsCount()} �������");
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
        Debug.Log("�� ���������!");
    }

    private void WinGame()
    {
        _isRunning = false;
        Debug.Log("�� ��������!");
    }
}
