using UnityEngine;
using UnityEngine.AI;

public class CustomerAI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private NavMeshAgent agent;
    private Animator anim;
    private bool IsWalking = false;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

   public void MoveTo(Vector3 target)
{
    if (agent == null)
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("❌ NavMeshAgent not found on " + gameObject.name);
            return;
        }
    }

    if (anim == null)
    {
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.LogError("❌ Animator not found on " + gameObject.name);
            return;
        }
    }

    agent.SetDestination(target);
    anim.SetBool("IsStand", false);
    IsWalking = true;
}


   void Update()
   {
    if (IsWalking && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
    {
        anim.SetBool("IsStand", true);
        IsWalking = false;
    }
   }
}