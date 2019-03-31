using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExecutableAction
{
    void ExecuteAction();
}

public class Timer : MonoBehaviour
{
    public float waitTime = 3f;
    MonoBehaviour[] monoBehaviours;

    // Start is called before the first frame update
    void Start()
    {
        monoBehaviours = gameObject.GetComponents<MonoBehaviour>();
        StartCoroutine(TimerCoroutine());
    }

    IEnumerator TimerCoroutine()
    {
        float elapsedTime = 0;

        while (elapsedTime <= waitTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        CheckExecutableActions();
    }

    private void CheckExecutableActions()
    {
        foreach (MonoBehaviour monoBehaviour in monoBehaviours)
        {
            if (monoBehaviour is IExecutableAction)
            {
                IExecutableAction actionableObject = (IExecutableAction)monoBehaviour;
                actionableObject.ExecuteAction();
            }
        }
    }
}
