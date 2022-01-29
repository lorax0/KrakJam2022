using System;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine;

namespace KrakJam2022
{
    public static class InputActionManager
    {
        public static void WasPressedButtonThisFrame(InputAction inputAction, Action callback)
        {
            if (WasPressedButtonThisFrame(inputAction))
            {
                callback();
            }
        }

        public static bool WasPressedButtonThisFrame(InputAction inputAction)
        {
            if (inputAction != null)
            {
                var buttonControl = inputAction.activeControl as ButtonControl;
                if (buttonControl != null)
                {
                    if (buttonControl.wasPressedThisFrame)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool IsPressedButton(InputAction inputAction)
        {
            if (inputAction != null)
            {
                var buttonControl = inputAction.activeControl as ButtonControl;
                if (buttonControl != null)
                {
                    if (buttonControl.isPressed)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
