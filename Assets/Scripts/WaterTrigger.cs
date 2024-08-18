using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public float buoyancyForce = 9.8f;
    public float dragInWater = 3f;
    public float smoothFactor = 0.1f;
    private bool isInWater = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInWater = true;
            StartCoroutine(AdjustPhysics(other.GetComponent<Rigidbody>(), true));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInWater = false;
            StartCoroutine(AdjustPhysics(other.GetComponent<Rigidbody>(), false));
        }
    }

    private IEnumerator AdjustPhysics(Rigidbody rb, bool enteringWater)
    {
        float targetDrag = enteringWater ? dragInWater : 0f;
        float targetBuoyancy = enteringWater ? buoyancyForce : 0f;

        while (isInWater == enteringWater && Mathf.Abs(rb.drag - targetDrag) > 0.01f)
        {
            rb.drag = Mathf.Lerp(rb.drag, targetDrag, smoothFactor);
            yield return new WaitForFixedUpdate();
        }

        while (isInWater == enteringWater && Mathf.Abs(rb.velocity.y - targetBuoyancy) > 0.01f)
        {
            rb.velocity = new Vector3(rb.velocity.x, Mathf.Lerp(rb.velocity.y, targetBuoyancy, smoothFactor), rb.velocity.z);
            yield return new WaitForFixedUpdate();
        }
    }

    private void FixedUpdate()
    {
        if (isInWater)
        {
            ApplyBuoyancy(GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>());
        }
    }

    private void ApplyBuoyancy(Rigidbody rb)
    {
        Vector3 buoyancy = Vector3.up * buoyancyForce;
        rb.AddForce(buoyancy, ForceMode.Acceleration);
    }
}
