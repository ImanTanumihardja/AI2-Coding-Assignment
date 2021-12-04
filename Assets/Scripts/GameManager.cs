using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform trashPool = null;

    private int score = 0;
    private int maxTrash = 10;
    private Queue<GameObject> deactiveTrash = new Queue<GameObject>();
    private HashSet<GameObject> activeTrash = new HashSet<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform trash in trashPool)
        {
            deactiveTrash.Enqueue(trash.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        while (activeTrash.Count < maxTrash && deactiveTrash.Count > 0)
        {
            activeTrash.Add(deactiveTrash.Dequeue());
        }  
    }

    public void TrashCollected(GameObject go)
    {
        if (activeTrash.Contains(go))
        {
            DeactivateTrash(go);

            score++;
            Debug.LogFormat(this, "Score: {0}", score);
        }
    }

    private void DeactivateTrash(GameObject go)
    {
        activeTrash.Remove(go);
        deactiveTrash.Enqueue(go);
    }
}
