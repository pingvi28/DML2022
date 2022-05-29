using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject image_in_slot;
    public int id;

    //получаем компонент инвентарь от игрока
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // при взаимодействии
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    //создаем объект в слоте - что именно и где
                    Instantiate(image_in_slot, inventory.slots[i].transform);
                    //удаляем с локации
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
