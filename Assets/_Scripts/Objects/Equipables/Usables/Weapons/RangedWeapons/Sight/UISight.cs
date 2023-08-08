using UnityEngine;

public class UISight : MonoBehaviour
{
    [SerializeField] RectTransform _sightRadiusImage;
    [SerializeField] RadiusSight _sight;

    private void Update()
    {
        _sightRadiusImage.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,_sight.SightRadius * 2 );
        _sightRadiusImage.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,_sight.SightRadius * 2 );
    }
}
