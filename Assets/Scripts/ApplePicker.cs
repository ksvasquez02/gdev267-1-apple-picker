using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    [SerializeField]
    private GameObject basketPrefab;
    [SerializeField]
    private int numBaskets = 3;
    [SerializeField]
    private float basketBottomY = -14f;
    [SerializeField]
    private float basketSpacingY = 2f;
    [SerializeField]
    private List<GameObject> baskets;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        baskets = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject basketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (i * basketSpacingY);
            basketGO.transform.position = pos;
            baskets.Add(basketGO);
        }
    }

    public void AppleMissed()
    {
        GameObject[] applesGOs = GameObject.FindGameObjectsWithTag("Apple");
        foreach(GameObject appleGO in applesGOs)
        {
            Destroy(appleGO);
        }

        int basketIndex = baskets.Count - 1;
        GameObject basketGO = baskets[basketIndex];
        baskets.RemoveAt(basketIndex);
        Destroy(basketGO);

        if (baskets.Count == 0)
        {
            SceneManager.LoadScene("_Scene_GameOver");
        }
    }
}
