using System;
using UnityEngine;

namespace UIPopups.EasingFunctions
{
    public class Easing
    {
        public static Func<float, float> GetEaseFunction(Ease type)
        {
            return type switch
            {
                Ease.InQuad => InQuad,
                Ease.OutQuad => OutQuad,
                Ease.InOutQuad => InOutQuad,

                Ease.InQuart => InQuart,
                Ease.OutQuart => OutQuart,
                Ease.InOutQuart => InOutQuart,
                
                Ease.InExpo => InExpo,
                Ease.OutExpo => OutExpo,
                Ease.InOutExpo => InOutExpo,

                Ease.InBack => InBack,
                Ease.OutBack => OutBack,
                Ease.InOutBack => InOutBack,

                Ease.InElastic => InElastic,
                Ease.OutElastic => OutElastic,
                Ease.InOutElastic => InOutElastic,

                Ease.InBounce => InBounce,
                Ease.OutBounce => OutBounce,
                Ease.InOutBounce => InOutBounce,

                _ => Linear
            };
        }

        public static float Calculate(float value, Func<float, float> easeFunction)
        {
            return easeFunction(value);
        }


        public static float Linear(float t)
        {
            return t;
        }

        public static float InQuad(float t)
        {
            return t * t;
        }
        public static float OutQuad(float t)
        {
            return 1 - InQuad(1 - t);
        }
        public static float InOutQuad(float t)
        {
            if (t < 0.5f)
                return InQuad(t * 2) / 2;
			return 1 - InQuad((1 - t) * 2) / 2;
        }

        public static float InQuart(float t)
        {
            return t * t * t * t;
        }
        public static float OutQuart(float t)
        {
            return 1 - InQuart(1 - t);
        }
        public static float InOutQuart(float t)
        {
            if (t < 0.5f)
                return InQuart(t * 2) / 2;
			return 1 - InQuart((1 - t) * 2) / 2;
        }

        public static float InExpo(float t)
        {
            return Mathf.Pow(2, 10 * (t - 1));
        }
        public static float OutExpo(float t)
        {
            return 1 - InExpo(1 - t);
        }
        public static float InOutExpo(float t)
        {
            if (t < 0.5f)
                return InExpo(t * 2) / 2;
			return 1 - InExpo((1 - t) * 2) / 2;
        }

        public static float InBack(float t)
        {
			float s = 1.70158f;
			return t * t * ((s + 1) * t - s);
        }
        public static float OutBack(float t)
        {
            return 1 - InBack(1 - t);
        }
        public static float InOutBack(float t)
        {
			if (t < 0.5f)
                return InBack(t * 2) / 2;
			return 1 - InBack((1 - t) * 2) / 2;
        }

        public static float InElastic(float t)
        {
            return 1 - OutElastic(1 - t);
        }
		public static float OutElastic(float t)
		{
			float p = 0.3f;
			return Mathf.Pow(2, -10 * t) * Mathf.Sin((t - p / 4) * (2 * Mathf.PI) / p) + 1;
		}
		public static float InOutElastic(float t)
		{
			if (t < 0.5f)
                return InElastic(t * 2) / 2;
			return 1 - InElastic((1 - t) * 2) / 2;
		}

        public static float InBounce(float t)
        {
            return 1 - OutBounce(1 - t);
        }
		public static float OutBounce(float t)
		{
			float div = 2.75f;
			float mult = 7.5625f;

			if (t < 1 / div)
			{
				return mult * t * t;
			}
			else if (t < 2 / div)
			{
				t -= 1.5f / div;
				return mult * t * t + 0.75f;
			}
			else if (t < 2.5 / div)
			{
				t -= 2.25f / div;
				return mult * t * t + 0.9375f;
			}
			else
			{
				t -= 2.625f / div;
				return mult * t * t + 0.984375f;
			}
		}
		public static float InOutBounce(float t)
		{
			if (t < 0.5f)
                return InBounce(t * 2) / 2;
			return 1 - InBounce((1 - t) * 2) / 2;
		}
    }
}
