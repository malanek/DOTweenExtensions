#if true // MODULE_MARKER
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace BBExtensions.DOTweenExt
{
    public static class DOTweenModulePhysics
    {
        #region Shortcuts

        #region Rigidbody

        /// <summary>Tweens a Rigidbody's position to the given value.
        /// Also stores the rigidbody as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static TweenerCore<Vector3, Vector3, VectorOptions> DOMove(this Rigidbody target, Vector3 endValue, DOTweenParams @params, bool snapping = false)
        {
            var t = target.DOMove(endValue, @params.Duration, snapping);
            if (@params.CustomEase)
                t.SetEase(@params.AnimationCurve);
            else
                t.SetEase(@params.StandardEase);
            return t;
        }

        /// <summary>Tweens a Rigidbody's X position to the given value.
        /// Also stores the rigidbody as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="params">The duration of the tween and Ease</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static TweenerCore<Vector3, Vector3, VectorOptions> DOMoveX(this Rigidbody target, float endValue, DOTweenParams @params, bool snapping = false)
        {
            var t = target.DOMoveX(endValue, @params.Duration, snapping);
            if (@params.CustomEase)
                t.SetEase(@params.AnimationCurve);
            else
                t.SetEase(@params.StandardEase);
            return t;
        }

        /// <summary>Tweens a Rigidbody's Y position to the given value.
        /// Also stores the rigidbody as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="params">The duration of the tween and Ease</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static TweenerCore<Vector3, Vector3, VectorOptions> DOMoveY(this Rigidbody target, float endValue, DOTweenParams @params, bool snapping = false)
        {
            var t = target.DOMoveY(endValue, @params.Duration, snapping);
            if (@params.CustomEase)
                t.SetEase(@params.AnimationCurve);
            else
                t.SetEase(@params.StandardEase);
            return t;
        }

        /// <summary>Tweens a Rigidbody's Z position to the given value.
        /// Also stores the rigidbody as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="params">The duration of the tween and Ease</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static TweenerCore<Vector3, Vector3, VectorOptions> DOMoveZ(this Rigidbody target, float endValue, DOTweenParams @params, bool snapping = false)
        {
            var t = target.DOMoveZ(endValue, @params.Duration, snapping);
            if (@params.CustomEase)
                t.SetEase(@params.AnimationCurve);
            else
                t.SetEase(@params.StandardEase);
            return t;
        }

        /// <summary>Tweens a Rigidbody's rotation to the given value.
        /// Also stores the rigidbody as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="params">The duration of the tween and Ease</param>
        /// <param name="mode">Rotation mode</param>
        public static TweenerCore<Quaternion, Vector3, QuaternionOptions> DORotate(this Rigidbody target, Vector3 endValue, DOTweenParams @params, RotateMode mode = RotateMode.Fast)
        {
            var t = target.DORotate(endValue, @params.Duration);
            if (@params.CustomEase)
                t.SetEase(@params.AnimationCurve);
            else
                t.SetEase(@params.StandardEase);
            return t;
        }

        /// <summary>Tweens a Rigidbody's rotation so that it will look towards the given position.
        /// Also stores the rigidbody as the tween's target so it can be used for filtered operations</summary>
        /// <param name="towards">The position to look at</param><param name="params">The duration of the tween and Ease</param>
        /// <param name="axisConstraint">Eventual axis constraint for the rotation</param>
        /// <param name="up">The vector that defines in which direction up is (default: Vector3.up)</param>
        public static TweenerCore<Quaternion, Vector3, QuaternionOptions> DOLookAt(this Rigidbody target, Vector3 towards, DOTweenParams @params, AxisConstraint axisConstraint = AxisConstraint.None, Vector3? up = null)
        {
            var t = target.DOLookAt(towards, @params.Duration, axisConstraint, up);
            if (@params.CustomEase)
                t.SetEase(@params.AnimationCurve);
            else
                t.SetEase(@params.StandardEase);
            return t;
        }

        #region Special

        /// <summary>Tweens a Rigidbody's position to the given value, while also applying a jump effect along the Y axis.
        /// Returns a Sequence instead of a Tweener.
        /// Also stores the Rigidbody as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param>
        /// <param name="jumpPower">Power of the jump (the max height of the jump is represented by this plus the final Y offset)</param>
        /// <param name="numJumps">Total number of jumps</param>
        /// <param name="params">The duration of the tween and Ease</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static Sequence DOJump(this Rigidbody target, Vector3 endValue, float jumpPower, int numJumps, DOTweenParams @params, bool snapping = false)
        {
            var t = target.DOJump(endValue, jumpPower, numJumps, @params.Duration, snapping);
            if (@params.CustomEase)
                t.SetEase(@params.AnimationCurve);
            else
                t.SetEase(@params.StandardEase);
            return t;
        }

        /// <summary>Tweens a Rigidbody's position through the given path waypoints, using the chosen path algorithm.
        /// Also stores the Rigidbody as the tween's target so it can be used for filtered operations.
        /// <para>NOTE: to tween a rigidbody correctly it should be set to kinematic at least while being tweened.</para>
        /// <para>BEWARE: doesn't work on Windows Phone store (waiting for Unity to fix their own bug).
        /// If you plan to publish there you should use a regular transform.DOPath.</para></summary>
        /// <param name="path">The waypoints to go through</param>
        /// <param name="params">The duration of the tween and Ease</param>
        /// <param name="pathType">The type of path: Linear (straight path), CatmullRom (curved CatmullRom path) or CubicBezier (curved with control points)</param>
        /// <param name="pathMode">The path mode: 3D, side-scroller 2D, top-down 2D</param>
        /// <param name="resolution">The resolution of the path (useless in case of Linear paths): higher resolutions make for more detailed curved paths but are more expensive.
        /// Defaults to 10, but a value of 5 is usually enough if you don't have dramatic long curves between waypoints</param>
        /// <param name="gizmoColor">The color of the path (shown when gizmos are active in the Play panel and the tween is running)</param>
        public static TweenerCore<Vector3, Path, PathOptions> DOPath(
            this Rigidbody target, Vector3[] path, DOTweenParams @params, PathType pathType = PathType.Linear,
            PathMode pathMode = PathMode.Full3D, int resolution = 10, Color? gizmoColor = null
        )
        {
            var t = target.DOPath(path, @params.Duration, pathType, pathMode, resolution, gizmoColor);
            if (@params.CustomEase)
                t.SetEase(@params.AnimationCurve);
            else
                t.SetEase(@params.StandardEase);
            return t;
        }

        /// <summary>Tweens a Rigidbody's localPosition through the given path waypoints, using the chosen path algorithm.
        /// Also stores the Rigidbody as the tween's target so it can be used for filtered operations
        /// <para>NOTE: to tween a rigidbody correctly it should be set to kinematic at least while being tweened.</para>
        /// <para>BEWARE: doesn't work on Windows Phone store (waiting for Unity to fix their own bug).
        /// If you plan to publish there you should use a regular transform.DOLocalPath.</para></summary>
        /// <param name="path">The waypoint to go through</param>
        /// <param name="params">The duration of the tween and Ease</param>
        /// <param name="pathType">The type of path: Linear (straight path), CatmullRom (curved CatmullRom path) or CubicBezier (curved with control points)</param>
        /// <param name="pathMode">The path mode: 3D, side-scroller 2D, top-down 2D</param>
        /// <param name="resolution">The resolution of the path: higher resolutions make for more detailed curved paths but are more expensive.
        /// Defaults to 10, but a value of 5 is usually enough if you don't have dramatic long curves between waypoints</param>
        /// <param name="gizmoColor">The color of the path (shown when gizmos are active in the Play panel and the tween is running)</param>
        public static TweenerCore<Vector3, Path, PathOptions> DOLocalPath(
            this Rigidbody target, Vector3[] path, DOTweenParams @params, PathType pathType = PathType.Linear,
            PathMode pathMode = PathMode.Full3D, int resolution = 10, Color? gizmoColor = null
        )
        {
            var t = target.DOLocalPath(path, @params.Duration, pathType, pathMode, resolution, gizmoColor);
            if (@params.CustomEase)
                t.SetEase(@params.AnimationCurve);
            else
                t.SetEase(@params.StandardEase);
            return t;
        }

        #endregion

        #endregion

        #endregion
    }
}
#endif
