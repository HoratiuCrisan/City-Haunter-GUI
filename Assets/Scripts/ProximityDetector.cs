using UnityEngine;

public class ProximityDetector : MonoBehaviour
{
    public GameObject player; // Referință la caracterul principal
    public GameObject questionMarkPrefab; // Prefab-ul cu semnul întrebării
    public GameObject replacementPrefab; // Prefab-ul care înlocuiește semnul întrebării
    public float detectionRange = 5f; // Distanța la care se schimbă prefab-urile

    private GameObject currentPrefabInstance;
    private bool isReplaced = false;



    void Start()
    {
        currentPrefabInstance = Instantiate(questionMarkPrefab, transform.position, Quaternion.identity);
    }

    void Update()
    {
        if (player == null || questionMarkPrefab == null || replacementPrefab == null)
        {
            Debug.LogWarning("Asigură-te că toate referințele sunt setate în Inspector.");
            return;
        }

        // Calculăm distanța dintre jucător și acest obiect
        float distance = Vector3.Distance(player.transform.position, transform.position);

        // Verificăm dacă jucătorul este suficient de aproape și dacă nu am făcut deja înlocuirea
        if (distance <= detectionRange && !isReplaced)
        {
            // Distrugem prefab-ul cu semnul întrebării existent
            if (currentPrefabInstance != null)
            {
                Destroy(currentPrefabInstance);
            }
            // Instanțiem prefab-ul care înlocuiește semnul întrebării
            currentPrefabInstance = Instantiate(replacementPrefab, transform.position, Quaternion.identity);
            isReplaced = true; // Marcam că înlocuirea a avut loc
        }
    }
}
