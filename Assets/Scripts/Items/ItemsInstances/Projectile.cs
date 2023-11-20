using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    public Rigidbody2D Rigidbody => _rigidbody;

    public float CurrentDamage { get; set; }

    public void OnCollisionEnter2D(Collision2D collision) =>
        Destroy(gameObject);
}
