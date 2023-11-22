using Cainos.PixelArtTopDown_Basic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementArrow : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public enum ArrowId {Down, Up, Right, Left};
    public ArrowId arrowId;
    
    private TopDownCharacterController _topDownCharacterController;
    private int _pointerCount;

    private void Start()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer && !Application.isMobilePlatform)
        {
            gameObject.SetActive(false);
        }
        _topDownCharacterController = FindObjectOfType<TopDownCharacterController>();
    }

    public void OnPointerDown(PointerEventData data)
    {
        _pointerCount++;
        switch (arrowId)
        {
            case ArrowId.Down:
                _topDownCharacterController.verticalPlayerMovement = -1;
                break;
            case ArrowId.Up:
                _topDownCharacterController.verticalPlayerMovement = 1;
                break;
            case ArrowId.Left:
                _topDownCharacterController.horizontalPlayerMovement = -1;
                break;
            case ArrowId.Right:
                _topDownCharacterController.horizontalPlayerMovement = 1;
                break;
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        if (--_pointerCount == 0)
        {
            switch (arrowId)
            {
                case ArrowId.Down:
                case ArrowId.Up:
                    _topDownCharacterController.verticalPlayerMovement = 0;
                    break;
                case ArrowId.Left:
                case ArrowId.Right:
                    _topDownCharacterController.horizontalPlayerMovement = 0;
                    break;
            }
        }
    }
}