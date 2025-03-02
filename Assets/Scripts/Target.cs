using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    //private SpawnManager spawnManager;
    private CutSoundEfects soundEffects;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 2;
    private float xRange = 4;
    private float ySpawnPos = -2;
    public int pointsValue;
    public ParticleSystem explosionParticle;
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        soundEffects = FindObjectOfType<CutSoundEfects>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }
    private void OnMouseDown()
    {
        if (GameManager.Instance.CurrentState == GameManager.GameState.Playing)
        {
             if (CompareTag("Bad"))
            {
                soundEffects.CutBad();
            }
            else
            {
                soundEffects.CutGood();
            }
            
            Destroy(gameObject);
            ScoreManager.Instance.AddScore(pointsValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            ScoreManager.Instance.AddScore(-20);
        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
