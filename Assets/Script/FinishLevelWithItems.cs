using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine;

public class FinishLevelWithItems : FinishLevel
{
    [MMInspectorGroup("Item", true, 28)]

    [SerializeField] string necessaryItem;
    [SerializeField] int quantity = 1;

    bool isDone;

    protected override void OnTriggerEnter2D(Collider2D collidingObject)
    {
        if (isDone || !collidingObject.CompareTag("Player"))
        {
            return;
        }

        var inventory = collidingObject.GetComponent<CharacterInventory>();
        if (inventory.MainInventory.GetQuantity(necessaryItem) >= quantity)
        {
            isDone = true;
            StartCoroutine(GoToNextLevelCoroutine());
        }
    }

    protected override void OnTriggerExit2D(Collider2D collidingObject) { }

    protected override void OnTriggerStay2D(Collider2D collidingObject) { }
}
