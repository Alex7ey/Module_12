using UnityEngine;

[RequireComponent(typeof(Wallet))]
public class CoinCollector : MonoBehaviour
{
    private Wallet _wallet;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Coin coin))
        {
            coin.PickUp();
            _wallet.AddCoin(coin.ValueCoin);
        }
    }
}
