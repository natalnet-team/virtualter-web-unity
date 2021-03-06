using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialItem : MonoBehaviour {

    public SpecialHUD HUD;
    public int itemId;
    public GameObject SpecialItemSpawnerObject;
    private AudioSource gotCoinSound;

    void Start(){
        
    }

    void OnTriggerEnter(Collider other)
    {
        gotCoinSound = GetComponent<AudioSource>();

        if (other.CompareTag("Hand"))
        {
            SpecialItemSpawnerObject.GetComponent<SpecialItemSpawner>().DecreaseItems();
            HUD.UpdateSpecialItensHUD(itemId);
            PlayerScore.SpecialItensGathering(itemId);
            StartCoroutine(DelayNextItem(SpecialItemSpawnerObject));
            gameObject.GetComponent<SphereCollider>().enabled = false;
            gameObject.GetComponent<Renderer>().enabled = false;

            gotCoinSound.Play();
        }

    }

    public void InitializeItem (int ID, SpecialHUD hud, GameObject obj)
    {
        itemId = ID;
        HUD = hud;
        SpecialItemSpawnerObject = obj;
    }
        
    IEnumerator DelayNextItem(GameObject obj)
    {
        yield return new WaitForSeconds(1f);
        obj.GetComponent<SpecialItemSpawner>().SpawnNextItem();
        Destroy(this.gameObject);
    }
}
