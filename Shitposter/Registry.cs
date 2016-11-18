using System;
using System.Collections.Generic;
using System.Security;
using System.Windows.Forms;

namespace Shitposter {
    class Registry {
        private bool canRead;
        private bool canWrite;
        private List<string> names;

        public Registry() {
            canRead = true;
            canWrite = true;
            try {
                string[] keyNames = Application.UserAppDataRegistry.GetValueNames();
                names = new List<string>(keyNames);
            } catch (SecurityException) {
                canRead = false;
                names = new List<string>();
            } catch (UnauthorizedAccessException) {
                canRead = false;
                names = new List<string>();
            }
            try {
                Application.UserAppDataRegistry.SetValue("Last Accessed", (new DateTime()).ToString());
            } catch (SecurityException) {
                canWrite = false;
            } catch (UnauthorizedAccessException) {
                canWrite = false;
            }
        }

        public string Read(string name) {
            if (!canRead) return null;
            if (!names.Contains(name))
                return null;
            try {
                return (string)Application.UserAppDataRegistry.GetValue(name);
            } catch (InvalidCastException) {
                return null;
            } catch (NullReferenceException) {
                return null;
            }
        }

        public void Write(string name, object value) {
            if (!canWrite) return;
            if (string.IsNullOrEmpty(name)) {
                return;
            }
            if (!(value is string)) {
                return;
            }
            try {
                Application.UserAppDataRegistry.SetValue(name, value);
            } catch (SecurityException) {
                canWrite = false;
            } catch (UnauthorizedAccessException) {
                canWrite = false;
            }
        }
    }
}
