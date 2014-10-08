using UnityEngine;

public class DeleteParticleSystem : MonoBehaviour
{

    private ParticleSystem ps;

    void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (ps)
        {
            if (!ps.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }
}