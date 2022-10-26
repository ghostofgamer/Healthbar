public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _health = 50;
    [SerializeField] private int _minHealth = 0;

    public event UnityAction<int> Reached;

    public int GetHealth => _health;
    public int GetMaxHealth => _maxHealth;

    public void Healing(int heal)
    {
        _health += heal;
        _health = Mathf.Clamp(_health, _minHealth, _maxHealth);
        Reached?.Invoke(_health);
    }

    public void Damage(int damage)
    {
        _health -= damage;
        _health = Mathf.Clamp(_health, _minHealth, _maxHealth);
        Reached?.Invoke(_health);
    }
}
