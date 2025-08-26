using System.IO.Pipes;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class PillarSpawner : MonoBehaviour
{
    [SerializeField] float pillarSpeed = 6f;
    public GameObject prefab;
    public float minHeight = -1.25f;
    public float maxHeight = 1.25f;
    public float speedIncreasePerFrame = 6f;


    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), 0, 1);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Update()
    {
        speedIncreasePerFrame += 0.0001f * Time.deltaTime;
        pillarSpeed -= 0.0001f * Time.deltaTime;
    }
    private void Spawn()
    {
        // GameObject Pillars = Instantiate(prefab, transform.position, Quaternion.identity);
        GameObject Pillars = ObjectPool.instance.GetPooledObject();
        if (Pillars != null)
        {
            Pillars.transform.position = Vector3.up * Random.Range(minHeight, maxHeight);
            Pillars.transform.position = new Vector3(11, Pillars.transform.position.y, Pillars.transform.position.z);

            Pillars.SetActive(true);
            PillarController pillarController = Pillars.GetComponent<PillarController>();
            pillarController.SetSpeed(pillarSpeed);

        }
    }


}

