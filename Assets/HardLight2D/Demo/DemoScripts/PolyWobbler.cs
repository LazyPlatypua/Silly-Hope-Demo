using UnityEngine;

[RequireComponent (typeof (LineRenderer))]
[RequireComponent (typeof (PolygonCollider2D))]
public class PolyWobbler : MonoBehaviour
{
    PolygonCollider2D poly;
    LineRenderer lineRend;
    public float wobbles = 1;
    Vector2[] points;

    private void Start ()
    {
        poly = GetComponent<PolygonCollider2D> ();
        lineRend = GetComponent<LineRenderer> ();
    }

    void Update ()
    {
        points = poly.GetPath (0);
        lineRend.positionCount = points.Length;
        for (int i = 0; i < points.Length; i++)
        {
            points[i] += Random.insideUnitCircle * Time.deltaTime * wobbles;
            lineRend.SetPosition (i, points[i]);
        }
        poly.SetPath (0, points);
        HardLight2DManager.RefreshColliderReference (poly);
    }
}