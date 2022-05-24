using UnityEngine;
public class MutantAnimatorHandler : EnemyAnimatorHandler
{
    [field: SerializeField] public override float DyingAnimationDuration { get; protected set; }
    [HideInInspector] protected override Animator _animator { get; set; }
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void OnDie()
    {
        _animator.SetBool(isDiedAnimatorBoolParametr, true);
    }
    public void OnReadyToDamage()
    {
        _animator.SetTrigger(isNearToTargetAnimatorTriggerParametr);
    }
}
