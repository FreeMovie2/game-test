using UnityEngine;
using System.Collections;

public class CustomerSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject customerPrefab;
    public Transform CustomerSpawnPoint;
    public Transform WaitingPoint;
    void Start()
    {
        StartCoroutine(SpawnWithDelay());
    }

    IEnumerator SpawnWithDelay()
    {
        yield return new WaitForSeconds(2f);
        SpawnCustomer();
    }

    void SpawnCustomer()
    {
        GameObject customer = Instantiate(customerPrefab, CustomerSpawnPoint.position, Quaternion.identity);

        CustomerAI ai = customer.GetComponent<CustomerAI>();
        ai.MoveTo(WaitingPoint.position);
    }
    
}
