using UnityEngine;

public static class LayerUtil
{
    public static bool LayerContains(this LayerMask layerMask, int layer)
    {
        return layerMask == (layerMask | (1 << layer));
    }
}
