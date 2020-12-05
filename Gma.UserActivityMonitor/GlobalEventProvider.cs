using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Gma.UserActivityMonitor
{
    /// <summary>
    /// This component monitors all mouse activities globally (also outside of the application) 
    /// and provides appropriate events.
    /// </summary>
    public class GlobalEventProvider : Component
    {
        /// <summary>
        /// This component raises events. The value is always true.
        /// </summary>
        protected override bool CanRaiseEvents
        {
            get
            {
                return true;
            }
        }

        //################################################################
        #region Mouse events

        private event MouseEventHandler s_MMouseMove;

        /// <summary>
        /// Occurs when the mouse pointer is moved. 
        /// </summary>
        public event MouseEventHandler MouseMove
        {
            add
            {
                if (s_MMouseMove == null)
                {
                    HookManager.MouseMove += HookManager_MouseMove;
                }
                s_MMouseMove += value;
            }

            remove
            {
                s_MMouseMove -= value;
                if (s_MMouseMove == null)
                {
                    HookManager.MouseMove -= HookManager_MouseMove;
                }
            }
        }

        void HookManager_MouseMove(object sender, MouseEventArgs e)
        {
            if (s_MMouseMove != null)
            {
                s_MMouseMove.Invoke(this, e);
            }
        }

        private event MouseEventHandler s_MMouseClick;
        /// <summary>
        /// Occurs when a click was performed by the mouse. 
        /// </summary>
        public event MouseEventHandler MouseClick
        {
            add
            {
                if (s_MMouseClick == null)
                {
                    HookManager.MouseClick += HookManager_MouseClick;
                }
                s_MMouseClick += value;
            }

            remove
            {
                s_MMouseClick -= value;
                if (s_MMouseClick == null)
                {
                    HookManager.MouseClick -= HookManager_MouseClick;
                }
            }
        }

        void HookManager_MouseClick(object sender, MouseEventArgs e)
        {
            if (s_MMouseClick != null)
            {
                s_MMouseClick.Invoke(this, e);
            }
        }

        private event MouseEventHandler s_MMouseDown;

        /// <summary>
        /// Occurs when the mouse a mouse button is pressed. 
        /// </summary>
        public event MouseEventHandler MouseDown
        {
            add
            {
                if (s_MMouseDown == null)
                {
                    HookManager.MouseDown += HookManager_MouseDown;
                }
                s_MMouseDown += value;
            }

            remove
            {
                s_MMouseDown -= value;
                if (s_MMouseDown == null)
                {
                    HookManager.MouseDown -= HookManager_MouseDown;
                }
            }
        }

        void HookManager_MouseDown(object sender, MouseEventArgs e)
        {
            if (s_MMouseDown != null)
            {
                s_MMouseDown.Invoke(this, e);
            }
        }


        private event MouseEventHandler s_MMouseUp;

        /// <summary>
        /// Occurs when a mouse button is released. 
        /// </summary>
        public event MouseEventHandler MouseUp
        {
            add
            {
                if (s_MMouseUp == null)
                {
                    HookManager.MouseUp += HookManager_MouseUp;
                }
                s_MMouseUp += value;
            }

            remove
            {
                s_MMouseUp -= value;
                if (s_MMouseUp == null)
                {
                    HookManager.MouseUp -= HookManager_MouseUp;
                }
            }
        }

        void HookManager_MouseUp(object sender, MouseEventArgs e)
        {
            if (s_MMouseUp != null)
            {
                s_MMouseUp.Invoke(this, e);
            }
        }

        private event MouseEventHandler s_MMouseDoubleClick;

        /// <summary>
        /// Occurs when a double clicked was performed by the mouse. 
        /// </summary>
        public event MouseEventHandler MouseDoubleClick
        {
            add
            {
                if (s_MMouseDoubleClick == null)
                {
                    HookManager.MouseDoubleClick += HookManager_MouseDoubleClick;
                }
                s_MMouseDoubleClick += value;
            }

            remove
            {
                s_MMouseDoubleClick -= value;
                if (s_MMouseDoubleClick == null)
                {
                    HookManager.MouseDoubleClick -= HookManager_MouseDoubleClick;
                }
            }
        }

        void HookManager_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (s_MMouseDoubleClick != null)
            {
                s_MMouseDoubleClick.Invoke(this, e);
            }
        }


        private event EventHandler<MouseEventExtArgs> s_MMouseMoveExt;

        /// <summary>
        /// Occurs when the mouse pointer is moved. 
        /// </summary>
        /// <remarks>
        /// This event provides extended arguments of type <see cref="MouseEventArgs"/> enabling you to 
        /// supress further processing of mouse movement in other applications.
        /// </remarks>
        public event EventHandler<MouseEventExtArgs> MouseMoveExt
        {
            add
            {
                if (s_MMouseMoveExt == null)
                {
                    HookManager.MouseMoveExt += HookManager_MouseMoveExt;
                }
                s_MMouseMoveExt += value;
            }

            remove
            {
                s_MMouseMoveExt -= value;
                if (s_MMouseMoveExt == null)
                {
                    HookManager.MouseMoveExt -= HookManager_MouseMoveExt;
                }
            }
        }

        void HookManager_MouseMoveExt(object sender, MouseEventExtArgs e)
        {
            if (s_MMouseMoveExt != null)
            {
                s_MMouseMoveExt.Invoke(this, e);
            }
        }

        private event EventHandler<MouseEventExtArgs> s_MMouseClickExt;

        /// <summary>
        /// Occurs when a click was performed by the mouse. 
        /// </summary>
        /// <remarks>
        /// This event provides extended arguments of type <see cref="MouseEventArgs"/> enabling you to 
        /// supress further processing of mouse click in other applications.
        /// </remarks>
        public event EventHandler<MouseEventExtArgs> MouseClickExt
        {
            add
            {
                if (s_MMouseClickExt == null)
                {
                    HookManager.MouseClickExt += HookManager_MouseClickExt;
                }
                s_MMouseClickExt += value;
            }

            remove
            {
                s_MMouseClickExt -= value;
                if (s_MMouseClickExt == null)
                {
                    HookManager.MouseClickExt -= HookManager_MouseClickExt;
                }
            }
        }

        void HookManager_MouseClickExt(object sender, MouseEventExtArgs e)
        {
            if (s_MMouseClickExt != null)
            {
                s_MMouseClickExt.Invoke(this, e);
            }
        }


        #endregion

        //################################################################
        #region Keyboard events

        private event KeyPressEventHandler s_MKeyPress;

        /// <summary>
        /// Occurs when a key is pressed.
        /// </summary>
        /// <remarks>
        /// Key events occur in the following order: 
        /// <list type="number">
        /// <item>KeyDown</item>
        /// <item>KeyPress</item>
        /// <item>KeyUp</item>
        /// </list>
        ///The KeyPress event is not raised by noncharacter keys; however, the noncharacter keys do raise the KeyDown and KeyUp events. 
        ///Use the KeyChar property to sample keystrokes at run time and to consume or modify a subset of common keystrokes. 
        ///To handle keyboard events only in your application and not enable other applications to receive keyboard events, 
        /// set the KeyPressEventArgs.Handled property in your form's KeyPress event-handling method to <b>true</b>. 
        /// </remarks>
        public event KeyPressEventHandler KeyPress
        {
            add
            {
                if (s_MKeyPress==null)
                {
                    HookManager.KeyPress +=HookManager_KeyPress;
                }
                s_MKeyPress += value;
            }
            remove
            {
                s_MKeyPress -= value;
                if (s_MKeyPress == null)
                {
                    HookManager.KeyPress -= HookManager_KeyPress;
                }
            }
        }

        void HookManager_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (s_MKeyPress != null)
            {
                s_MKeyPress.Invoke(this, e);
            }
        }

        private event KeyEventHandler s_MKeyUp;

        /// <summary>
        /// Occurs when a key is released. 
        /// </summary>
        public event KeyEventHandler KeyUp
        {
            add
            {
                if (s_MKeyUp == null)
                {
                    HookManager.KeyUp += HookManager_KeyUp;
                }
                s_MKeyUp += value;
            }
            remove
            {
                s_MKeyUp -= value;
                if (s_MKeyUp == null)
                {
                    HookManager.KeyUp -= HookManager_KeyUp;
                }
            }
        }

        private void HookManager_KeyUp(object sender, KeyEventArgs e)
        {
            if (s_MKeyUp != null)
            {
                s_MKeyUp.Invoke(this, e);
            }
        }

        private event KeyEventHandler s_MKeyDown;

        /// <summary>
        /// Occurs when a key is preseed. 
        /// </summary>
        public event KeyEventHandler KeyDown
        {
            add
            {
                if (s_MKeyDown == null)
                {
                    HookManager.KeyDown += HookManager_KeyDown;
                }
                s_MKeyDown += value;
            }
            remove
            {
                s_MKeyDown -= value;
                if (s_MKeyDown == null)
                {
                    HookManager.KeyDown -= HookManager_KeyDown;
                }
            }
        }

        private void HookManager_KeyDown(object sender, KeyEventArgs e)
        {
            s_MKeyDown.Invoke(this, e);
        }

        #endregion

        
    }
}
