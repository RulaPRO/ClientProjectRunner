using UnityEngine;

public class CameraBrain : MonoBehaviour
{
    [SerializeField] private float distance = 10f;
    [SerializeField] private float height = 5f;

    private GameObject target;
    private float currentRotation;
        
    void Update()
    {
        if (target == null)
        {
            return;
        }
            
        var targetPosition = target.transform.position;
        var position = targetPosition - (Vector3.forward * distance);
        position.y = targetPosition.y + height;
        transform.position = position;
        transform.LookAt(targetPosition);
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
}