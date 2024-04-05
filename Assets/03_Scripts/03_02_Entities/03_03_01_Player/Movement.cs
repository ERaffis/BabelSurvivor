using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Localization.Plugins.XLIFF.V12;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerControls playerControls;
    
    [Space]
    [SerializeField] private Transform playerVisualTransform;
    [SerializeField] private Transform playerTransform;
    [Space] [SerializeField] private Player playerScript;
    
    [Space] [SerializeField] private Vector2 inputVector;
    
    private void Awake()
    {
        playerScript = GetComponentInParent<Player>();
        
        playerInput = GetComponent<PlayerInput>();
        
        
        playerControls = new PlayerControls();
        playerControls.Player.Enable();
        playerControls.Player.Dash.performed += Dash;
        playerControls.Player.Move.canceled += Rotate;
    }

    private void Update()
    {
        Move();
    }

    //Méthode pour faire le déplacement du joueur
    private void Move()
    { 
        inputVector = playerControls.Player.Move.ReadValue<Vector2>();
        transform.parent.transform.Translate(new Vector3(inputVector.x,0,inputVector.y) * (playerScript.movementSpeed * Time.deltaTime));    
    }

    public void Rotate(InputAction.CallbackContext context)
    {
        //Stock la direction de déplacement du joueur
        inputVector = context.ReadValue<Vector2>();

        //Garde la rotation du joueur même si il arrête de tourner (Fonctionne avec clavier et controller)
        if (inputVector == Vector2.zero) return;
       
        //Calcule l'angle entre la direction et le devant pour changer la rotation du joueur
        float rotation = Vector2.Angle(inputVector, Vector2.up) * AngleDir(Vector3.forward,new Vector3(inputVector.x,0,inputVector.y), Vector3.up);
        
        //Fait en sorte qu'avec clavier souris le joueur est capable de regarder vers le bas (C'est nécessaire parce que la direction est égal à 0, le joueur reste toujours vers le haut sinon)
        if (rotation == 0)  if (Math.Abs(inputVector.y - (-1)) < 0.05f) rotation = 180;
        
        //Applique la rotation au joueur
        var eulerAngles = playerVisualTransform.eulerAngles;
        eulerAngles = new Vector3(eulerAngles.x, rotation, eulerAngles.z);
        playerVisualTransform.eulerAngles = eulerAngles;
    }

    //Méthode pour un dash si on en fait un.
    public void Dash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //Insérer le code si on fait un dash ici.
            Debug.Log(("Player Dash"));
        }

    }
    
    float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up) {
        Vector3 perp = Vector3.Cross(fwd, targetDir);
        float dir = Vector3.Dot(perp, up);
		
        if (dir > 0f) {
            return 1f;
        } else if (dir < 0f) {
            return -1f;
        } else {
            return 0f;
        }
    }

}
