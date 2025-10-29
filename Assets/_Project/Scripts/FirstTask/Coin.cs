using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private int _valueCoin;

    public int ValueCoin => _valueCoin;

    public void PickUp()
    {
        _particleSystem.transform.position = transform.position;
        _particleSystem.Play();
        gameObject.SetActive(false);
    }
}

