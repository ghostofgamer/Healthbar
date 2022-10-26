public class Bar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Health _health;

    private float _speed = 13f;
    private Coroutine _coroutine;

    private void Start()
    {
        _healthBar.value = _health.GetHealth;
        _healthBar.maxValue = _health.GetMaxHealth;
    }

    private void OnEnable()
    {
        _health.Reached += CorutineGo;
    }

    private void OnDisable()
    {
        _health.Reached -= CorutineGo;
    }

    public void CorutineGo(int target)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(ChangeHealthbar(target));
    }

    public IEnumerator ChangeHealthbar(int target)
    {
        while (_healthBar.value != target)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, target, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
