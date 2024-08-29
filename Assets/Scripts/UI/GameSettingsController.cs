using Cinemachine;
using Input;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameSettingsController : MonoBehaviour
    {
        public Slider cameraRotationSlider;
        public TextMeshProUGUI cameraRotationText;

        public Slider orthoSizeSlider;
        public TextMeshProUGUI orthoSizeText;

        public Slider playerRotationSpeedSlider;
        public TextMeshProUGUI playerRotationSpeedText;

        public Slider playerSpeedSlider;
        public TextMeshProUGUI playerSpeedText;

        public CinemachineVirtualCamera cinemachineCamera;
        public PlayerMovement playerMovement;
    
        private void Start()
        {
            // Setting up slider ranges
            cameraRotationSlider.minValue = -360;
            cameraRotationSlider.maxValue = 360;
            orthoSizeSlider.minValue = 0;
            orthoSizeSlider.maxValue = 100;
            playerRotationSpeedSlider.minValue = 100;
            playerRotationSpeedSlider.maxValue = 1000;
            playerSpeedSlider.minValue = 0;
            playerSpeedSlider.maxValue = 100;
            
            orthoSizeSlider.value = cinemachineCamera.m_Lens.OrthographicSize;
            //playerRotationSpeedSlider.value = playerMovement.rotationSpeed;
            //playerSpeedSlider.value = playerMovement.moveSpeed;

            // Add listeners to sliders
            cameraRotationSlider.onValueChanged.AddListener(OnCameraRotationChanged);
            orthoSizeSlider.onValueChanged.AddListener(OnOrthoSizeChanged);
            playerRotationSpeedSlider.onValueChanged.AddListener(OnPlayerRotationSpeedChanged);
            playerSpeedSlider.onValueChanged.AddListener(OnPlayerSpeedChanged);

            // Initialize text fields with current values
            UpdateCameraRotationText(cameraRotationSlider.value);
            UpdateOrthoSizeText(orthoSizeSlider.value);
            UpdatePlayerRotationSpeedText(playerRotationSpeedSlider.value);
            UpdatePlayerSpeedText(playerSpeedSlider.value);
        }

        private void OnCameraRotationChanged(float value)
        {
            cinemachineCamera.transform.rotation = Quaternion.Euler(30, value, 0);
            UpdateCameraRotationText(value);
        }

        private void OnOrthoSizeChanged(float value)
        {
            cinemachineCamera.m_Lens.OrthographicSize = value;
            UpdateOrthoSizeText(value);
        }

        private void OnPlayerRotationSpeedChanged(float value)
        {
           // playerMovement.rotationSpeed = value;
            UpdatePlayerRotationSpeedText(value);
        }

        private void OnPlayerSpeedChanged(float value)
        {
            //playerMovement.moveSpeed = value;
            UpdatePlayerSpeedText(value);
        }

        private void UpdateCameraRotationText(float value)
        {
            cameraRotationText.text = $"Camera Rotation: {value:F2}";
        }

        private void UpdateOrthoSizeText(float value)
        {
            orthoSizeText.text = $"Ortho Size: {value:F2}";
        }

        private void UpdatePlayerRotationSpeedText(float value)
        {
            playerRotationSpeedText.text = $"Player Rotation Speed: {value:F2}";
        }

        private void UpdatePlayerSpeedText(float value)
        {
            playerSpeedText.text = $"Player Speed: {value:F2}";
        }
    }
}

