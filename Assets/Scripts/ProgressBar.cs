using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void SetMinMaxValue(int _maxValue)
    {
        slider.minValue = 0;
        slider.maxValue = _maxValue;
    }

    public void SetValue(int _value)
    {
        slider.value = _value;
    }
}
