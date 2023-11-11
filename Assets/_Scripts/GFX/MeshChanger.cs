using UnityEngine;

public class MeshChanger : MonoBehaviour
{
    [SerializeField] private Mesh[] _meshes;
    private MeshFilter _meshFilter;

    private void Awake() => _meshFilter = GetComponent<MeshFilter>();

    public void ChangeMesh(int meshIndex) => _meshFilter.mesh = _meshes[meshIndex];
}
