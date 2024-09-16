using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace BBExtensions.DOTweenExt
{
    public static class DOTweenExt
    {
        /// <summary>Tweens a Transform's position through the given path waypoints, using the chosen path algorithm.
        /// Also stores the transform as the tween's target so it can be used for filtered operations</summary>
        /// <param name="path">The waypoints to go through</param>
        /// <param name="params">The duration of the tween and Ease</param>
        /// <param name="pathType">The type of path: Linear (straight path), CatmullRom (curved CatmullRom path) or CubicBezier (curved with control points)</param>
        /// <param name="pathMode">The path mode: 3D, side-scroller 2D, top-down 2D</param>
        /// <param name="resolution">The resolution of the path (useless in case of Linear paths): higher resolutions make for more detailed curved paths but are more expensive.
        /// Defaults to 10, but a value of 5 is usually enough if you don't have dramatic long curves between waypoints</param>
        /// <param name="gizmoColor">The color of the path (shown when gizmos are active in the Play panel and the tween is running)</param>
        public static TweenerCore<Vector3, Path, PathOptions> DOPath(this Transform target, Vector3[] path, DOTweenParams @params, PathType pathType = PathType.Linear, PathMode pathMode = PathMode.Full3D, int resolution = 10, Color? gizmoColor = null)
        {
            var t = target.DOPath(path, @params.Duration, pathType, pathMode, resolution, gizmoColor);
            SetEaseInternal(t, @params);
            return t;
        }

        /// <summary>Tweens a Transform's rotation to the given value.
        /// Also stores the transform as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param>
        /// <param name="params">The duration of the tween and Ease</param>
        /// <param name="mode">Rotation mode</param>
        public static TweenerCore<Quaternion, Vector3, QuaternionOptions> DORotate(this Transform target, Vector3 endValue, DOTweenParams @params, RotateMode mode = RotateMode.Fast)
        {
            var t = target.DORotate(endValue, @params.Duration, mode);
            SetEaseInternal(t, @params);
            return t;
        }

        /// <summary>Tweens a Transform's rotation to the given value using pure quaternion values.
        /// Also stores the transform as the tween's target so it can be used for filtered operations.
        /// <para>PLEASE NOTE: DORotate, which takes Vector3 values, is the preferred rotation method.
        /// This method was implemented for very special cases, and doesn't support LoopType.Incremental loops
        /// (neither for itself nor if placed inside a LoopType.Incremental Sequence)</para>
        /// </summary>
        /// <param name="endValue">The end value to reach</param>
        /// <param name="params">The duration of the tween and Ease</param>
        public static TweenerCore<Quaternion, Quaternion, NoOptions> DORotateQuaternion(this Transform target, Quaternion endValue, DOTweenParams @params)
        {
            var t = target.DORotateQuaternion(endValue, @params.Duration);
            SetEaseInternal(t, @params);
            return t;
        }

        /// <summary>Tweens a Transform's position to the given value.
        /// Also stores the transform as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param>
        /// <param name="params">The duration of the tween and Ease</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static TweenerCore<Vector3, Vector3, VectorOptions> DOMove(this Transform target, Vector3 endValue, DOTweenParams @params, bool snapping = false)
        {
            var t = target.DOMove(endValue, @params.Duration);
            SetEaseInternal(t, @params);
            return t;
        }

        /// <summary>Tweens a Transform's localScale to the given value.
        /// Also stores the transform as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param>
        /// <param name="params">The duration of the tween and Ease</param>
        public static TweenerCore<Vector3, Vector3, VectorOptions> DOScale(this Transform target, Vector3 endValue, DOTweenParams @params)
        {
            var t = target.DOScale(endValue, @params.Duration);
            SetEaseInternal(t, @params);
            return t;
        }

        /// <summary>Tweens a Transform's localScale uniformly to the given value.
        /// Also stores the transform as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param>
        /// <param name="params">The duration of the tween and Ease</param>
        public static TweenerCore<Vector3, Vector3, VectorOptions> DOScale(this Transform target, float endValue, DOTweenParams @params)
        {
            var t = target.DOScale(endValue, @params.Duration);
            SetEaseInternal(t, @params);
            return t;
        }

        /// <summary>Punches a Transform's localScale towards the given size and then back to the starting one
        /// as if it was connected to the starting scale via an elastic.</summary>
        /// <param name="punch">The punch strength (added to the Transform's current scale)</param>
        /// <param name="params">The duration of the tween and Ease</param>
        /// <param name="vibrato">Indicates how much will the punch vibrate</param>
        /// <param name="elasticity">Represents how much (0 to 1) the vector will go beyond the starting size when bouncing backwards.
        /// 1 creates a full oscillation between the punch scale and the opposite scale,
        /// while 0 oscillates only between the punch scale and the start scale</param>
        public static Tweener DOPunchScale(this Transform target, Vector3 punch, DOTweenParams @params, int vibrato = 10, float elasticity = 1f)
        {
            var t = target.DOPunchScale(punch, @params.Duration, vibrato, elasticity);
            SetEaseInternal(t, @params);
            return t;
        }

        /// <summary>Punches a Transform's localRotation towards the given size and then back to the starting one
        /// as if it was connected to the starting rotation via an elastic.</summary>
        /// <param name="punch">The punch strength (added to the Transform's current rotation)</param>
        /// <param name="params">The duration of the tween and Ease</param>
        /// <param name="vibrato">Indicates how much will the punch vibrate</param>
        /// <param name="elasticity">Represents how much (0 to 1) the vector will go beyond the starting rotation when bouncing backwards.
        /// 1 creates a full oscillation between the punch rotation and the opposite rotation,
        /// while 0 oscillates only between the punch and the start rotation</param>
        public static Tweener DOPunchRotation(this Transform target, Vector3 punch, DOTweenParams @params, int vibrato = 10, float elasticity = 1f)
        {
            var t = target.DOPunchRotation(punch, @params.Duration, vibrato, elasticity);
            SetEaseInternal(t, @params);
            return t;
        }

        /// <summary>Punches a Transform's localPosition towards the given direction and then back to the starting one
        /// as if it was connected to the starting position via an elastic.</summary>
        /// <param name="punch">The direction and strength of the punch (added to the Transform's current position)</param>
        /// <param name="params">The duration of the tween and Ease</param>
        /// <param name="vibrato">Indicates how much will the punch vibrate</param>
        /// <param name="elasticity">Represents how much (0 to 1) the vector will go beyond the starting position when bouncing backwards.
        /// 1 creates a full oscillation between the punch direction and the opposite direction,
        /// while 0 oscillates only between the punch and the start position</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static Tweener DOPunchPosition(this Transform target, Vector3 punch, DOTweenParams @params, int vibrato = 10, float elasticity = 1f, bool snapping = false)
        {
            var t = target.DOPunchPosition(punch, @params.Duration, vibrato, elasticity);
            SetEaseInternal(t, @params);
            return t;
        }

        /// <summary>Shakes a Transform's localPosition with the given values.</summary>
        /// <param name="params">The duration of the tween and Ease</param>
        /// <param name="strength">The shake strength</param>
        /// <param name="vibrato">Indicates how much will the shake vibrate</param>
        /// <param name="randomness">Indicates how much the shake will be random (0 to 180 - values higher than 90 kind of suck, so beware).
        /// Setting it to 0 will shake along a single direction.</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        /// <param name="fadeOut">If TRUE the shake will automatically fadeOut smoothly within the tween's duration, otherwise it will not</param>
        public static Tweener DOShakePosition(this Transform target, DOTweenParams @params, float strength = 1f, int vibrato = 10, float randomness = 90f, bool snapping = false, bool fadeOut = true)
        {
            var t = target.DOShakePosition(@params.Duration, strength, vibrato, randomness, snapping, fadeOut);
            SetEaseInternal(t, @params);
            return t;
        }

        /// <summary>Shakes a Transform's localRotation.</summary>
        /// <param name="params">The duration of the tween and Ease</param>
        /// <param name="strength">The shake strength</param>
        /// <param name="vibrato">Indicates how much will the shake vibrate</param>
        /// <param name="randomness">Indicates how much the shake will be random (0 to 180 - values higher than 90 kind of suck, so beware).
        /// Setting it to 0 will shake along a single direction.</param>
        /// <param name="fadeOut">If TRUE the shake will automatically fadeOut smoothly within the tween's duration, otherwise it will not</param>
        public static Tweener DOShakeRotation(this Transform target, DOTweenParams @params, float strength = 90f, int vibrato = 10, float randomness = 90f, bool fadeOut = true)
        {
            var t = target.DOShakeRotation(@params.Duration, strength, vibrato, randomness, fadeOut);
            SetEaseInternal(t, @params);
            return t;
        }

        /// <summary>Shakes a Transform's localScale.</summary>
        /// <param name="params">The duration of the tween and Ease</param>
        /// <param name="strength">The shake strength</param>
        /// <param name="vibrato">Indicates how much will the shake vibrate</param>
        /// <param name="randomness">Indicates how much the shake will be random (0 to 180 - values higher than 90 kind of suck, so beware).
        /// Setting it to 0 will shake along a single direction.</param>
        /// <param name="fadeOut">If TRUE the shake will automatically fadeOut smoothly within the tween's duration, otherwise it will not</param>
        public static Tweener DOShakeScale(this Transform target, DOTweenParams @params, float strength = 1f, int vibrato = 10, float randomness = 90f, bool fadeOut = true)
        {
            var t = target.DOShakeScale(@params.Duration, strength, vibrato, randomness, fadeOut);
            SetEaseInternal(t, @params);
            return t;
        }

        /// <summary>
        /// Tweens a Transform's localPosition to the given value, while also applying a jump effect along the Y axis.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="endValue">The end value to reach</param>
        /// <param name="jumpPower">Power of the jump (the max height of the jump is represented by this plus the final Y offset)</param>
        /// <param name="numJumps">Total number of jumps</param>
        /// <param name="params"></param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        /// <returns>Sequence instead of a Tweener.</returns>
        public static Sequence DOLocalJump(this Transform target, Vector3 endValue, float jumpPower, int numJumps, DOTweenParams @params, bool snapping = false)
        {
            var t = target.DOLocalJump(endValue, jumpPower, numJumps, @params.Duration, snapping);
            SetEaseInternal(t, @params);
            return t;
        }

        /// <summary>
        /// Tweens a Transform's localPosition to the given value. Also stores the transform as the tween's target so it can be used for filtered operations.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="endValue">The end value to reach</param>
        /// <param name="params">The duration of the tween and Ease</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        /// <returns></returns>
        public static TweenerCore<Vector3, Vector3, VectorOptions> DOLocalMove(this Transform target, Vector3 endValue, DOTweenParams @params, bool snapping = false)
        {
            var t = target.DOLocalMove(endValue, @params.Duration, snapping);
            SetEaseInternal(t, @params);
            return t;
        }

        /// <summary>Tweens a Transform's X localPosition to the given value.
        /// Also stores the transform as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param>
        /// <param name="params">The duration of the tween and Ease</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static TweenerCore<Vector3, Vector3, VectorOptions> DOLocalMoveX(this Transform target, float endValue, DOTweenParams @params, bool snapping = false)
        {
            var t = target.DOLocalMoveX(endValue, @params.Duration, snapping);
            SetEaseInternal(t, @params);
            return t;
        }

        /// <summary>Tweens a Transform's Y localPosition to the given value.
        /// Also stores the transform as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param>
        /// <param name="params">The duration of the tween and Ease</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static TweenerCore<Vector3, Vector3, VectorOptions> DOLocalMoveY(this Transform target, float endValue, DOTweenParams @params, bool snapping = false)
        {
            var t = target.DOLocalMoveY(endValue, @params.Duration, snapping);
            SetEaseInternal(t, @params);
            return t;
        }

        /// <summary>Tweens a Transform's Z localPosition to the given value.
        /// Also stores the transform as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param>
        /// <param name="params">The duration of the tween and Ease</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static TweenerCore<Vector3, Vector3, VectorOptions> DOLocalMoveZ(this Transform target, float endValue, DOTweenParams @params, bool snapping = false)
        {
            var t = target.DOLocalMoveZ(endValue, @params.Duration, snapping);
            SetEaseInternal(t, @params);
            return t;
        }

        /// <summary>
        /// Sets the ease of the tween.<br/>
        /// If applied to Sequences eases the whole sequence animation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="params"></param>
        /// <returns></returns>
        public static T SetEase<T>(this T t, DOTweenParams @params) where T : Tween
        {
            SetEaseInternal(t, @params);
            return t;
        }

        private static void SetEaseInternal(Tween t, DOTweenParams @params)
        {
            if (@params.CustomEase)
                t.SetEase(@params.AnimationCurve);
            else
                t.SetEase(@params.StandardEase);
        }
    }
}