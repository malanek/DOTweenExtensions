#if true && (UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_5 || UNITY_2017_1_OR_NEWER) // MODULE_MARKER
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace BBExtensions.DOTweenExt
{
    public static class DOTweenExtRigidbody
    {
        #region Shortcuts

        #region Rigidbody2D Shortcuts

        /// <summary>Tweens a Rigidbody2D's position to the given value.
        /// Also stores the Rigidbody2D as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="params">The duration of the tween and Ease</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static TweenerCore<Vector2, Vector2, VectorOptions> DOMove(this Rigidbody2D target, Vector2 endValue, DOTweenParams @params, bool snapping = false)
        {
            var t = target.DOMove(endValue, @params.Duration, snapping);
            if (@params.CustomEase)
                t.SetEase(@params.AnimationCurve);
            else
                t.SetEase(@params.StandardEase);
            return t;
        }

        /// <summary>Tweens a Rigidbody2D's X position to the given value.
        /// Also stores the Rigidbody2D as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="params">The duration of the tween and Ease</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static TweenerCore<Vector2, Vector2, VectorOptions> DOMoveX(this Rigidbody2D target, float endValue, DOTweenParams @params, bool snapping = false)
        {
            var t = target.DOMoveX(endValue, @params.Duration, snapping);
            if (@params.CustomEase)
                t.SetEase(@params.AnimationCurve);
            else
                t.SetEase(@params.StandardEase);
            return t;
        }

        /// <summary>Tweens a Rigidbody2D's Y position to the given value.
        /// Also stores the Rigidbody2D as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="params">The duration of the tween and Ease</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static TweenerCore<Vector2, Vector2, VectorOptions> DOMoveY(this Rigidbody2D target, float endValue, DOTweenParams @params, bool snapping = false)
        {
            var t = target.DOMoveY(endValue, @params.Duration, snapping);
            if (@params.CustomEase)
                t.SetEase(@params.AnimationCurve);
            else
                t.SetEase(@params.StandardEase);
            return t;
        }

        /// <summary>Tweens a Rigidbody2D's rotation to the given value.
        /// Also stores the Rigidbody2D as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="params">The duration of the tween and Ease</param>
        public static TweenerCore<float, float, FloatOptions> DORotate(this Rigidbody2D target, float endValue, DOTweenParams @params)
        {
            var t = target.DORotate(endValue, @params.Duration);
            if (@params.CustomEase)
                t.SetEase(@params.AnimationCurve);
            else
                t.SetEase(@params.StandardEase);
            return t;
        }

        #region Special

        /// <summary>Tweens a Rigidbody2D's position to the given value, while also applying a jump effect along the Y axis.
        /// Returns a Sequence instead of a Tweener.
        /// Also stores the Rigidbody2D as the tween's target so it can be used for filtered operations.
        /// <para>IMPORTANT: a rigidbody2D can't be animated in a jump arc using MovePosition, so the tween will directly set the position</para></summary>
        /// <param name="endValue">The end value to reach</param>
        /// <param name="jumpPower">Power of the jump (the max height of the jump is represented by this plus the final Y offset)</param>
        /// <param name="numJumps">Total number of jumps</param>
        /// <param name="params">The duration of the tween and Ease</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static Sequence DOJump(this Rigidbody2D target, Vector2 endValue, float jumpPower, int numJumps, DOTweenParams @params, bool snapping = false)
        {
            var t = target.DOJump(endValue, jumpPower, numJumps, @params.Duration, snapping);
            if (@params.CustomEase)
                t.SetEase(@params.AnimationCurve);
            else
                t.SetEase(@params.StandardEase);
            return t;
        }

        /// <summary>Tweens a Rigidbody2D's position through the given path waypoints, using the chosen path algorithm.
        /// Also stores the Rigidbody2D as the tween's target so it can be used for filtered operations.
        /// <para>NOTE: to tween a Rigidbody2D correctly it should be set to kinematic at least while being tweened.</para>
        /// <para>BEWARE: doesn't work on Windows Phone store (waiting for Unity to fix their own bug).
        /// If you plan to publish there you should use a regular transform.DOPath.</para></summary>
        /// <param name="path">The waypoints to go through</param>
        /// <param name="params">The duration of the tween and Ease</param>
        /// <param name="pathType">The type of path: Linear (straight path), CatmullRom (curved CatmullRom path) or CubicBezier (curved with control points)</param>
        /// <param name="pathMode">The path mode: 3D, side-scroller 2D, top-down 2D</param>
        /// <param name="resolution">The resolution of the path (useless in case of Linear paths): higher resolutions make for more detailed curved paths but are more expensive.
        /// Defaults to 10, but a value of 5 is usually enough if you don't have dramatic long curves between waypoints</param>
        /// <param name="gizmoColor">The color of the path (shown when gizmos are active in the Play panel and the tween is running)</param>
        public static TweenerCore<Vector3, Path, PathOptions> DOPath(this Rigidbody2D target, Vector2[] path, DOTweenParams @params, PathType pathType = PathType.Linear,
            PathMode pathMode = PathMode.Full3D, int resolution = 10, Color? gizmoColor = null)
        {
            var t = target.DOPath(path, @params.Duration, pathType, pathMode, resolution, gizmoColor);
            if (@params.CustomEase)
                t.SetEase(@params.AnimationCurve);
            else
                t.SetEase(@params.StandardEase);
            return t;
        }

        /// <summary>Tweens a Rigidbody2D's localPosition through the given path waypoints, using the chosen path algorithm.
        /// Also stores the Rigidbody2D as the tween's target so it can be used for filtered operations
        /// <para>NOTE: to tween a Rigidbody2D correctly it should be set to kinematic at least while being tweened.</para>
        /// <para>BEWARE: doesn't work on Windows Phone store (waiting for Unity to fix their own bug).
        /// If you plan to publish there you should use a regular transform.DOLocalPath.</para></summary>
        /// <param name="path">The waypoint to go through</param>
        /// <param name="params">The duration of the tween and Ease</param>
        /// <param name="pathType">The type of path: Linear (straight path), CatmullRom (curved CatmullRom path) or CubicBezier (curved with control points)</param>
        /// <param name="pathMode">The path mode: 3D, side-scroller 2D, top-down 2D</param>
        /// <param name="resolution">The resolution of the path: higher resolutions make for more detailed curved paths but are more expensive.
        /// Defaults to 10, but a value of 5 is usually enough if you don't have dramatic long curves between waypoints</param>
        /// <param name="gizmoColor">The color of the path (shown when gizmos are active in the Play panel and the tween is running)</param>
        public static TweenerCore<Vector3, Path, PathOptions> DOLocalPath(this Rigidbody2D target, Vector2[] path, DOTweenParams @params, PathType pathType = PathType.Linear,
            PathMode pathMode = PathMode.Full3D, int resolution = 10, Color? gizmoColor = null)
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