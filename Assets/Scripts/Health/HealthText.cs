using TMPro;
using UnityEngine;

public class HealthText : HealthIndicator
{
    [SerializeField] private TextMeshProUGUI _currentText;
    [SerializeField] private TextMeshProUGUI _maxText;

    protected override void Start()
    {
        base.Start();
        SetText(_currentText, HealthComponent.Current);
        SetText(_maxText, HealthComponent.Max);
    }

    protected override void OnCurrentChanged()
    {
        SetText(_currentText, HealthComponent.Current);
    }

    private void SetText(TextMeshProUGUI textMesh, float healthValue)
    {
        textMesh.text = Mathf.CeilToInt(healthValue).ToString();
    }
}
