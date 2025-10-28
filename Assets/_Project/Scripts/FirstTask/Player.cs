using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathEffect;

    public void Die()
    {
        _deathEffect.gameObject.transform.position = transform.position;
        _deathEffect.Play();
        gameObject.SetActive(false);
    }
}
