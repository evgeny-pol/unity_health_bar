using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TextMeshProUGUI _currentText;
    [SerializeField] private TextMeshProUGUI _maxText;

    private void Start()
    {
        _health.CurrentChanged += OnCurrentChanged;
        SetText(_currentText, _health.Current);
        SetText(_maxText, _health.Max);
    }

    private void OnDisable()
    {
        _health.CurrentChanged -= OnCurrentChanged;
    }

    private void OnCurrentChanged()
    {
        SetText(_currentText, _health.Current);
    }

    private void SetText(TextMeshProUGUI textMesh, float healthValue)
    {
        textMesh.text = Mathf.CeilToInt(healthValue).ToString();
    }
}
