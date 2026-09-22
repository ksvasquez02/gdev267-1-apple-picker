using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    [SerializeField]
    private GameObject applePrefab;
    [SerializeField]
    private GameObject poisonApplePrefab;
    [SerializeField]
    private GameObject goldenApplePrefab;
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float bounds = 10f;
    [SerializeField]
    private float changeDirChance = 0.1f;
    [SerializeField]
    private float dropDelay = 1f;
    [SerializeField]
    private float poisonDropChance = 0.01f;
    [SerializeField]
    private float goldenDropChance = 0.01f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke(nameof(DropApple), dropDelay);
    }

    void DropApple()
    {
        GameObject nextPrefab = applePrefab;
        if (Random.value < poisonDropChance)
        {
            nextPrefab = poisonApplePrefab;
        }
        else if (Random.value < goldenDropChance)
        {
            nextPrefab = goldenApplePrefab;
        }

        GameObject apple = Instantiate<GameObject>(nextPrefab);
        apple.transform.position = transform.position;
        Invoke(nameof(DropApple), dropDelay);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -bounds)
        {
            speed = Mathf.Abs(speed); // To Right
        }
        else if (pos.x > bounds)
        {
            speed = -Mathf.Abs(speed); // To Left
        }
    }

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        if (pos.x >= -bounds && pos.x <= bounds && Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }
}
