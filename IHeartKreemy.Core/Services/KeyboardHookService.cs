using Gma.System.MouseKeyHook;
using System;
using System.Windows.Forms;

namespace IHeartKreemy.Core.Services
{
    public class KeyboardHookService: IDisposable
    {
        private IKeyboardMouseEvents _globalHook;
        public event EventHandler KeyPressed;

        public void Start()
        {
            // This connects to the Windows Global Hook
            _globalHook = Hook.GlobalEvents();

            // Subscribe to the KeyDown event
            _globalHook.KeyDown += OnKeyDown;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            // Trigger our custom event whenever a key is hit
            KeyPressed?.Invoke(this, EventArgs.Empty);
        }

        // This method is called to clean up memory and remove the hook
        public void Dispose()
        {
            // 1. Unsubscribe the event listener to prevent memory leaks
            if (_globalHook != null)
            {
                _globalHook.KeyDown -= OnKeyDown;

                // 2. Destroy the hook
                _globalHook.Dispose();
                _globalHook = null;
            }
        }
    }

}
