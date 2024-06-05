using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class DoorSystem : MonoBehaviour
    {
        [SerializeField] private bool redDoor = false;
        [SerializeField] private bool redKey = false;

        [SerializeField] private KeyInventory _keyIventory = null;

        private KeyDoorController doorObject;

        private void Start()
        {
            if (redDoor)
            {
                doorObject = GetComponent<KeyDoorController>();
            }
        }
        public void ObjectIteraction(){
            if (redDoor){
               doorObject.PlayAnimation();
            }
            else if(redKey){
                _keyIventory.hasRedKey = true;
                gameObject.SetActive(false);
            }
        }
    }
}
