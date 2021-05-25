using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToCollider : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Snappable")
		{
			Snappable snappable = other.GetComponent<Snappable>();

			if (!snappable.isSnapped)
			{
				other.GetComponent<OffsetGrab>().DetachObject();
				
				other.attachedRigidbody.isKinematic = true;
				snappable.isSnapped = true;
				other.transform.position = transform.position;
				other.transform.rotation = Quaternion.identity;
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Snappable")
		{
			Snappable snappable = other.GetComponent<Snappable>();

			if (snappable.isSnapped)
			{
				other.attachedRigidbody.isKinematic = false;
				snappable.isSnapped = false;
			}
		}
	}
}
