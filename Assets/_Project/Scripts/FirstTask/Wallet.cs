using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _balance;
    private int _ñoinCount;

    public void AddCoin(int value)
    {
        _balance += value;
        _ñoinCount++;
    }

    public int GetBalance() => _balance;
 
    public int GetCoinCount() => _ñoinCount;
}
