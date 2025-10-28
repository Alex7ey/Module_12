using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private ParticleSystem _particleSystem;

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up, _rotationSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _particleSystem.transform.position = transform.position;
            _particleSystem.Play();
            gameObject.SetActive(false);
        }
    }
}

