using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int _healthpoints;
    private int _ammo;

    private void Awake()
    {
        _healthpoints = 30;
        _ammo = 10;
    }

    public bool TakeHit()
    {
        _healthpoints -= 10;
        bool isDead = _healthpoints <= 0;
        if (isDead) _Die();
        return isDead;
    }

    private void _Die()
    {
        Destroy(gameObject);
    }
}