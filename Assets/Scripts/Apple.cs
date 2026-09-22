using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;

    public bool isPoison = false;
    public int score = 100;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(gameObject);

            if (!isPoison)
            {
                ApplePicker applePicker = Camera.main.GetComponent<ApplePicker>();
                applePicker.AppleMissed();
            }
        }
    }
}
