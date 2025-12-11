using UnityEngine;

public class UnitRotation : MonoBehaviour
{
    private readonly Quaternion RotationLookRight = Quaternion.identity;
    private readonly Quaternion RotationLookLeft = Quaternion.Euler(0, 180, 0);
    private readonly int _numberHorizontalX = 1;

    public Quaternion GetRotation(float direction) =>
        direction == _numberHorizontalX ? RotationLookRight : RotationLookLeft;
}
