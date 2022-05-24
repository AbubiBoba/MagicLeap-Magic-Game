using UnityEngine;
public abstract class EnemyAnimatorHandler : MonoBehaviour
{
    protected abstract Animator _animator { get; set; }
    protected const string isDiedAnimatorBoolParametr = "Died";
    protected const string isNearToTargetAnimatorTriggerParametr = "IsNearToTarget";
    [SerializeField] public abstract float DyingAnimationDuration { get; protected set; }
}
