using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using PlayerSettings = Player.PlayerSettings;

namespace UI
{
    public class GameSettingsController : MonoBehaviour
    {
        private const string PLAYER_SETTINGS_PATH = "Data/PlayerSettings";
        public Slider cameraRotationSlider;
        public TextMeshProUGUI cameraRotationText;

        public Slider orthoSizeSlider;
        public TextMeshProUGUI orthoSizeText;

        public Slider playerRotationSpeedSlider;
        public TextMeshProUGUI playerRotationSpeedText;

        public Slider playerSpeedSlider;
        public TextMeshProUGUI playerSpeedText;

        public CinemachineVirtualCamera cinemachineCamera;
        public PlayerSettings playerSettings;

        private void Awake()
        {
            playerSettings = Resources.Load<PlayerSettings>(PLAYER_SETTINGS_PATH);
        }

        private void Start()
        {
            cameraRotationSlider.minValue = -360;
            cameraRotationSlider.maxValue = 360;
            orthoSizeSlider.minValue = 0;
            orthoSizeSlider.maxValue = 100;
            playerRotationSpeedSlider.minValue = 100;
            playerRotationSpeedSlider.maxValue = 1000;
            playerSpeedSlider.minValue = 0;
            playerSpeedSlider.maxValue = 100;
            
            orthoSizeSlider.value = cinemachineCamera.m_Lens.OrthographicSize;
            playerRotationSpeedSlider.value = playerSettings.RotationSpeed;
            playerSpeedSlider.value = playerSettings.MoveSpeed;

            cameraRotationSlider.onValueChanged.AddListener(OnCameraRotationChanged);
            orthoSizeSlider.onValueChanged.AddListener(OnOrthoSizeChanged);
            playerRotationSpeedSlider.onValueChanged.AddListener(OnPlayerRotationSpeedChanged);
            playerSpeedSlider.onValueChanged.AddListener(OnPlayerSpeedChanged);

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
            playerSettings.RotationSpeed = value;
            UpdatePlayerRotationSpeedText(value);
        }

        private void OnPlayerSpeedChanged(float value)
        {
            playerSettings.MoveSpeed = value;
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

