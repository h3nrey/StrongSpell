using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[ExecuteInEditMode]
public class PlayerConfig : MonoBehaviour
{
    [SerializeField] private Player playerData;

    [SerializeField]  private PlayerBehaviour _componentsContainer;

    [Button("SetupPlayer")]
    public void SetupPlayer() {
        _componentsContainer.spriteRenderer.sprite = playerData.sprite;
        _componentsContainer.anim.runtimeAnimatorController = playerData.animatorController;
    }
}
