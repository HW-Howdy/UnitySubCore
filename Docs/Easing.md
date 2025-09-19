# Easing
___
Easing Library For Unity

# How To Use
___
> using UnitySubCore.Easing
>
> SCEasing.EasingByType(EEasingType type, float t)

t must be between \[0f, 1f\] for normal operation.
The definition of EEasingType is as follows:
> 	public enum EEasingType
	{
		None = 0,
		Linear,
		InQuad,
		OutQuad,
		InOutQuad,
		InCubic,
		OutCubic,
		InOutCubic,
		InQuart,
		OutQuart,
		InOutQuart,
		InQuint,
		OutQuint,
		InOutQuint,
		InSine,
		OutSine,
		InOutSine,
		InExpo,
		OutExpo,
		InOutExpo,
		InCirc,
		OutCirc,
		InOurCirc,
		InElastic,
		OutElastic,
		InOutElastic,
		InBack,
		OutBack,
		InOutBack,
		InBounce,
		OutBounce,
		InOutBounce
	}