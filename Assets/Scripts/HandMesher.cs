using UnityEngine;
using UnityEngine.XR.MagicLeap;
public class HandMesher : MonoBehaviour
{
    private Vector3 _leftHandPosition;
    private Vector3 _rightHandPosition;
    [SerializeField] private GameObject _colliderPrefab;
    private GameObject _leftHandCollider;
    private GameObject _rightHandCollider;
    private void Start()
    {
        _leftHandCollider = Instantiate(_colliderPrefab, Vector3.zero, Quaternion.identity);
        _rightHandCollider = Instantiate(_colliderPrefab, Vector3.zero, Quaternion.identity);
    }
    private void FixedUpdate()
    {
        _leftHandCollider.transform.position = MagicLeapTools.HandInput.Left.Hand.Center;
        _rightHandCollider.transform.position = MagicLeapTools.HandInput.Right.Hand.Center;
    }
}
