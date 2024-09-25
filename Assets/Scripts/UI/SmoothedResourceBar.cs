using System.Collections;
using UnityEngine;

public class SmoothedResourceBar : ResourceBar
{
    [SerializeField] private AnimationCurve _fillSpeedCurve;

    private float _targetFillCoef;
    private Coroutine _updateFillCoroutine;

    public override void SetFillCoef(float fillCoef)
    {
        _targetFillCoef = fillCoef;
        _updateFillCoroutine ??= StartCoroutine(UpdateFill());
    }

    private IEnumerator UpdateFill()
    {
        while (enabled)
        {
            float fillSpeed = _fillSpeedCurve.Evaluate(Mathf.Abs(_targetFillCoef - FillCoef));
            float newFill = Mathf.MoveTowards(FillCoef, _targetFillCoef, fillSpeed * Time.deltaTime);
            base.SetFillCoef(newFill);
            yield return null;
        }

        _updateFillCoroutine = null;
    }
}
