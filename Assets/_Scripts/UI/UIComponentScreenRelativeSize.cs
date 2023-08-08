using UnityEngine;
using UnityEngine.UI;

public class UIComponentScreenRelativeSize : MonoBehaviour
{
    [SerializeField] private RectTransform _rect;
    [SerializeField] private CanvasScaler _canvas;
    [SerializeField] private FloatVariable _widthPercentage;
    [SerializeField] private FloatVariable _heightPercentage;

    private void Awake()
    {
        UpdateSize();
    }

    void UpdateSize()
    {
        float width = _canvas.referenceResolution.x * _widthPercentage.Value / 100f;
        float height = _canvas.referenceResolution.x * _heightPercentage.Value / 100f;
        _rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,width);
        _rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,height);
    }

    // private void OnDrawGizmos()
    // {
    //     UpdateSize();
    // }
}
