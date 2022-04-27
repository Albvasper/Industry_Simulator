using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OfficeIntro : MonoBehaviour {

    [SerializeField] private GameObject elevatorDoorA;
    [SerializeField] private GameObject elevatorDoorB;
    private AudioClip officeIntroAudioClip;

    private void Start() {
        // *PLay Sound*
    }

    private void Update() {
        // Wait until elevator reaches floor
        // *ding sound*
        elevatorDoorA.transform.localPosition = Vector3.Slerp(elevatorDoorA.transform.localPosition, new Vector3(-1450, 0, 0), .0001f);
        elevatorDoorB.transform.localPosition = Vector3.Slerp(elevatorDoorB.transform.localPosition, new Vector3(1450, 0, 0), .0001f);
        // Self destroy
        Destroy(gameObject);
    }
}
