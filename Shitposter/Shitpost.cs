using BileFountain;
using System;
using System.Windows.Forms;
using Tweetinvi;
using Tweetinvi.Models;

namespace Shitposter {
    public partial class Shitpost : Form {

        private Profanerizer generator;

        public Shitpost() {
            InitializeComponent();
            generator = new Profanerizer();
        }

        private void Generate(object sender, EventArgs e) {
            string result = generator.Profane();
            profanity.Text = result;
        }

        private void button2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Are you sure you wish to post this to Twitter?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                twitterPost(profanity.Text);
        }

        private void twitterPost(string value) {
            if (!LoginPanel.Login()) {
                MessageBox.Show("Could not connect to Twitter account", "Shitpost", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ITweet result = Tweet.PublishTweet(value);
        }
    }
}
