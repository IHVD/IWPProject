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

				if (other.name == "ThinVial")
				{
					other.GetComponent<BoxCollider>().isTrigger = true;
					foreach(SphereCollider coll in other.GetComponentsInChildren<SphereCollider>())
					{
						coll.gameObject.SetActive(false);
					}
				}

				snappable.isSnapped = true;
				other.transform.position = transform.position;
				other.transform.rotation = Quaternion.identity;

				if(other.name == "ThinVial" && tag == "Stand")
				{
					//GameController.gameCont.ToggleBeakerPlaced(true);
					if(!GameController.gameCont.placedOnStand)
						ClickOnRay.clickRay.TriggerObject("2_placeBeaker");
				}
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
