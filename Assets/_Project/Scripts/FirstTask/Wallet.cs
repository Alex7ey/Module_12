using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _balance;
    private int _�oinCount;

    public void AddCoin(int value)
    {
        _balance += value;
        _�oinCount++;
    }

    public int GetBalance() => _balance;
 
    public int GetCoinCount() => _�oinCount;
}
