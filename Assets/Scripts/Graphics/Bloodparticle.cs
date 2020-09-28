using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodparticle : MonoBehaviour
{
    public float lifetime;
    public float sizeX;
    public float sizeY;
    public Sprite mySprite;
    public List<ParticleCollisionEvent> collisionEvents;
    private ParticleSystem part;
    // Start is called before the first frame update
    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        for (int i = 0; i < numCollisionEvents; i++)
        {
            //Debug.unityLogger.Log("Some tag", collisionEvents[i].intersection);
            GameObject bloodSplash = new GameObject("bloodSplash");
            SpriteRenderer sr = bloodSplash.AddComponent<SpriteRenderer>() as SpriteRenderer;

            sr.transform.localScale = new Vector3(sizeX, sizeY, 0.0f);
            sr.transform.position = collisionEvents[i].intersection;
            sr.sprite = mySprite;
            Destroy(bloodSplash, lifetime);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
