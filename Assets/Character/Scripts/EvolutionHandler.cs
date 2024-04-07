using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolutionHandler : MonoBehaviour
{
    public GameObject[] hatsList;
    public Material[] face;
    private PlayerMovement playerMovement;
    public SkinnedMeshRenderer slimeFace;
    public int evolutionStage;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    [ContextMenu("SetEvolution")]
    public void SetEvolution(int evolutionStage)
    {
        switch (evolutionStage)
        {
            case 0:
                transform.localScale = Vector3.one;
                foreach(GameObject hat in hatsList)
                {
                    hat.SetActive(false);
                }
                slimeFace.materials[1] = face[0];
                playerMovement.SetJumpMultiplier(1f);
                playerMovement.SetSpeedMultiplier(1f);
                break;
            case 1:
                transform.localScale = new Vector3(2, 2, 2);
                foreach (GameObject hat in hatsList)
                {
                    hat.SetActive(false);
                }
                hatsList[0].SetActive(true);
                if (slimeFace != null)
                {
                    Debug.Log(slimeFace.materials[1].name);
                    slimeFace.sharedMaterials[1] = face[1];
                    Debug.Log("Cara cambiada" + face[1].name);
                }
                else
                    Debug.Log("no se cambio la cara");
                playerMovement.SetJumpMultiplier(1.3f);
                playerMovement.SetSpeedMultiplier(1.2f);
                break;
            case 2:
                transform.localScale = new Vector3(3, 3, 3);
                foreach (GameObject hat in hatsList)
                {
                    hat.SetActive(false);
                }
                hatsList[1].SetActive(true);
                slimeFace.materials[1] = face[2];
                playerMovement.SetJumpMultiplier(1.45f);
                playerMovement.SetSpeedMultiplier(1.2f);
                break;
            case 3:
                transform.localScale = new Vector3(4, 4, 4);
                foreach (GameObject hat in hatsList)
                {
                    hat.SetActive(false);
                }
                hatsList[2].SetActive(true);
                slimeFace.materials[1] = face[3];
                playerMovement.SetJumpMultiplier(1.6f);
                playerMovement.SetSpeedMultiplier(1.4f);
                break;
        }

        AudioManager.Instance.Play("SFX_Evolution");
    }
}
