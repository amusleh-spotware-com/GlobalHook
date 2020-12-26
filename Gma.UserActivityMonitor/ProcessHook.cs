using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Gma.UserActivityMonitor
{
    public class ProcessHook
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        private struct WINDOWPLACEMENT {
            public int length;
            public int flags;
            public int showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }

        private readonly Process _process;

        public ProcessHook(Process process)
        {
            _process = process;

            var windowPlacement = GetProcessWindowPlacement();

            if (windowPlacement != null && windowPlacement.Value.showCmd == 3)
            {
                IsMouseOverWindow = true;
            }
        }

        public bool? IsMouseOverWindow { get; private set; }

        private event MouseEventHandler s_MouseEnter;

        public event MouseEventHandler MouseEnter
        {
            add
            {
                SubscribeToGlobalHookMouseMoveEvent();

                s_MouseEnter += value;
            }

            remove
            {
                s_MouseEnter -= value;

                UnsubscribeFromGlobalHookMouseMoveEvent();
            }
        }

        private event MouseEventHandler s_MouseLeave;

        public event MouseEventHandler MouseLeave
        {
            add
            {
                SubscribeToGlobalHookMouseMoveEvent();

                s_MouseLeave += value;
            }

            remove
            {
                s_MouseLeave -= value;

                UnsubscribeFromGlobalHookMouseMoveEvent();
            }
        }

        private void SubscribeToGlobalHookMouseMoveEvent()
        {
            if (s_MouseEnter == null && s_MouseLeave == null)
            {
                HookManager.MouseMove += HookManager_MouseMove;
            }
        }

        private void UnsubscribeFromGlobalHookMouseMoveEvent()
        {
            if (s_MouseEnter == null && s_MouseLeave == null)
            {
                HookManager.MouseMove -= HookManager_MouseMove;
            }
        }

        private void HookManager_MouseMove(object sender, MouseEventArgs e)
        {
            var windowPlacement = GetProcessWindowPlacement();

            if (windowPlacement == null || windowPlacement.Value.showCmd == 2)
            {
                return;
            }

            if (windowPlacement.Value.showCmd == 3)
            {
                if (!IsMouseOverWindow.HasValue || !IsMouseOverWindow.Value)
                {
                    IsMouseOverWindow = true;

                    s_MouseEnter?.Invoke(this, e);
                }

                return;
            }

            var firstX = windowPlacement.Value.rcNormalPosition.X;
            var secondX = windowPlacement.Value.rcNormalPosition.Width;

            var firstY = windowPlacement.Value.rcNormalPosition.Y;
            var secondY = windowPlacement.Value.rcNormalPosition.Height;

            if (e.X >= firstX && e.X <= secondX && e.Y >= firstY && e.Y <= secondY)
            {
                if (!IsMouseOverWindow.HasValue || !IsMouseOverWindow.Value)
                {
                    IsMouseOverWindow = true;

                    s_MouseEnter?.Invoke(this, e);
                }
            }
            else if (!IsMouseOverWindow.HasValue || IsMouseOverWindow.Value)
            {
                IsMouseOverWindow = false;

                s_MouseLeave?.Invoke(this, e);
            }
        }


        private WINDOWPLACEMENT? GetProcessWindowPlacement()
        {
            var windowPlacement = new WINDOWPLACEMENT();

            return GetWindowPlacement(_process.MainWindowHandle, ref windowPlacement)
                ? (WINDOWPLACEMENT?)windowPlacement
                : null;
        }
    }
}