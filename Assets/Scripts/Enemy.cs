using UnityEngine;
public class Enemy : MonoBehaviour
{
    [SerializeField] private MutantAnimatorHandler _animatorHandler;
    [SerializeField, Range(0, 100)]
    private int _maxHealth;
    private int _curHealth;
    [SerializeField, Range(0, 50)]
    private int _damage;
    [SerializeField, Range(0, 10)]
    private float _attackCooldownTime;
    [SerializeField, Range(0, 10)]
    private float _distanceToTarget;
    [SerializeField, Range(0, 5)] private float _speed;
    public MainTarget Target { get; set; }
    private Transform _targetTransform;
    private CharacterController _characterController;
    private Rigidbody _rigidbody;
    public void Start()
    {
        //_characterController = GetComponent<CharacterController>();
        _rigidbody = GetComponent<Rigidbody>();
        _curHealth = _maxHealth;
        _targetTransform = Target.gameObject.transform;
        
    }
    public void TakeDamage(int damage)
    {
        if (_curHealth > damage)
        {
            _curHealth -= damage;
        }
        else if (_curHealth <= damage)
        {
            _curHealth = 0;
            Die();
        }
    }
    private void Die()
    {
        _animatorHandler.OnDie();
        Destroy(gameObject, _animatorHandler.DyingAnimationDuration);
    }
    private void Update()
    {
        Hunt();
    }
    private enum EnemyState { Hunting, Damaging, Died }
    private EnemyState _state = EnemyState.Hunting;
    private void Hunt()
    {
        _state = IsNearToTarget();
        switch (_state)
        {
            case EnemyState.Hunting:
                transform.LookAt(_targetTransform);
                transform.position = Vector3.MoveTowards(transform.position, _targetTransform.position, Time.deltaTime * _speed);
                break;
            case EnemyState.Damaging:
                _animatorHandler.OnReadyToDamage();
                transform.LookAt(_targetTransform);
                TryGiveDamage(Target, _damage);
                break;
            case EnemyState.Died:
                Die();
                break;
            default:
                break;
        }
    }
    bool isCooldownPassed = true;
    private void TryGiveDamage(MainTarget target, int damage)
    {
        if (isCooldownPassed)
        {
            target.TakeDamage(damage);
            isCooldownPassed = false;
            Invoke(nameof(SetCooldown), _attackCooldownTime);
        }
    }
    private void SetCooldown() { isCooldownPassed = true; }
    private void GiveDamage(MainTarget target, int damage) { target.TakeDamage(damage); }
    private EnemyState IsNearToTarget()
    {
        return ((_targetTransform.position - transform.position).magnitude <= _distanceToTarget) ? EnemyState.Damaging : EnemyState.Hunting;
    }
}