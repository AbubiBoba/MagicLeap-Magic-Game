using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using MagicLeap.Core;
using MagicLeapTools;

public class HandCollider : MonoBehaviour
{
    public enum KeyPoint { None, RightHandCenter, RightWristCenter, RightThumbKnuckle, RightThumbJoint, 
                           RightThumbTip, RightIndexKnuckle, RightIndexJoint, RightIndexTip, RightMiddleKnuckle, 
                           RightMiddleJoint, RightMiddleTip, RightRingKnuckle, RightRingTip, RightPinkyKnuckle, RightPinkyTip, 
                           LeftHandCenter, LeftWristCenter, LeftThumbKnuckle, LeftThumbJoint, 
                           LeftThumbTip, LeftIndexKnuckle, LeftIndexJoint, LeftIndexTip, LeftMiddleKnuckle, 
                           LeftMiddleJoint, LeftMiddleTip, LeftRingKnuckle, LeftRingTip, LeftPinkyKnuckle, LeftPinkyTip }
    public KeyPoint keyPoint;
}
