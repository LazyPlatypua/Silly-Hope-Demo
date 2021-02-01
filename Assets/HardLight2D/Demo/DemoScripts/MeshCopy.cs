using UnityEngine;

[ExecuteInEditMode]
[RequireComponent (typeof (MeshFilter))]
[RequireComponent (typeof (MeshRenderer))]
public class MeshCopy : MonoBehaviour
{
    public MeshFilter originalMesh;
    [ColorUsage (false)] public Color color = Color.white;
    public float intensity = 1;

    MeshFilter meshFilter;
    Renderer rend;
    Color oldColor = Color.black;
    float oldIntensity = -1;
    MaterialPropertyBlock propBlock;
    string colorProp = "_Color";

    void Update ()
    {
        CheckReferences ();
        if (originalMesh && originalMesh.sharedMesh)
            meshFilter.sharedMesh = originalMesh.sharedMesh;
        else meshFilter.sharedMesh = null;
        UpdateColor ();
    }
    void CheckReferences ()
    {
        if (!meshFilter) meshFilter = GetComponent<MeshFilter> ();
        if (!rend) rend = GetComponent<Renderer> ();
        if (propBlock == null) propBlock = new MaterialPropertyBlock ();
    }
    void UpdateColor ()
    {
        if (oldColor != color || oldIntensity != intensity)
        {
            oldColor = color;
            oldIntensity = intensity;
            rend.GetPropertyBlock (propBlock);
            propBlock.SetColor (colorProp, color * intensity);
            rend.SetPropertyBlock (propBlock);
        }
    }
}