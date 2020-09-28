using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ShadowEffect : MonoBehaviour
{
    public Vector3 offset = new Vector3(-0.1f, -0.1f);
    public Material material;

    GameObject _shadow;
    // Start is called before the first frame update
    void Start()
    {
        _shadow = new GameObject("Shadow");
        _shadow.transform.parent = transform;

        _shadow.transform.localPosition = offset;
        _shadow.transform.localRotation = Quaternion.identity;

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        SpriteRenderer sr = _shadow.AddComponent<SpriteRenderer>();
        sr.sprite = renderer.sprite;
        sr.material = material;

        sr.sortingLayerName = renderer.sortingLayerName;
        sr.sortingOrder = renderer.sortingOrder - 1;

    }

    void LateUpdate()
    {
        _shadow.transform.localPosition = offset;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
