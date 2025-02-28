using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    //private SpawnManager spawnManager;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 2;
    private float xRange = 4;
    private float ySpawnPos = -2;
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        //spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }
    private void OnMouseDown()
    {
        Destroy(gameObject);
        ScoreManager.Instance.AddScore(5);
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
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
