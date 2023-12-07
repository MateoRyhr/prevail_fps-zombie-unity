using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
     [SerializeField] private Material[] _materials;
     [SerializeField] private Renderer _renderer;

    public void ChangeMaterial(int materialIndex)
    {
        _renderer.sharedMaterial = _materials[materialIndex];
    }

    public void SetRandomMaterial()
    {
        int randomIndex = Random.Range(0,_materials.Length);
        ChangeMaterial(randomIndex);
    }
}
