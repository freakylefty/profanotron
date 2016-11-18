using System;
using System.Diagnostics;
using System.Windows.Forms;
using Tweetinvi;
using Tweetinvi.Models;

namespace Shitposter {
    public partial class LoginPanel : Form {

        private static Registry registry;

        private IAuthenticationContext authenticationContext;

        public static bool Login() {
            if (Auth.Credentials != null)
                return true;

            registry = new Registry();

            string consumerSecret = registry.Read("consumerSecret");
            string accessSecret = registry.Read("accessSecret");

            if (!string.IsNullOrEmpty(consumerSecret) && !string.IsNullOrEmpty(accessSecret)) {
                Auth.SetUserCredentials("R4OCY4qm2RJPisvX9rlXhF7mc", consumerSecret, "797867980356980736-zoF6SWbU1tzSEtRzEMr46noMooYcOXM", accessSecret);
                return true;
            }

            LoginPanel loginPanel = new LoginPanel();
            DialogResult result = loginPanel.ShowDialog();
            return (result == DialogResult.OK);
        }

        public LoginPanel() {
            InitializeComponent();
            textPin.Enabled = false;
        }

        private void textPin_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                continueLogin();
            }
        }

        private void setKey() {
            var appCredentials = new TwitterCredentials("R4OCY4qm2RJPisvX9rlXhF7mc", textKey.Text);
            authenticationContext = AuthFlow.InitAuthentication(appCredentials);
            Process.Start(authenticationContext.AuthorizationURL);
            textPin.Enabled = true;
        }

        private void continueLogin() {
            var userCredentials = AuthFlow.CreateCredentialsFromVerifierCode(textPin.Text, authenticationContext);
            Auth.SetCredentials(userCredentials);
            registry.Write("consumerSecret", userCredentials.ConsumerSecret);
            registry.Write("accessSecret", userCredentials.AccessTokenSecret);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textKey_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                setKey();
            }
        }
    }
}
