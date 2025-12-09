using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private const string IsRun = nameof(IsRun);

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnIdledAnimation() =>
        _animator.SetBool(IsRun, false);

    public void OnMovableAnimation() =>
        _animator.SetBool(IsRun, true);
}