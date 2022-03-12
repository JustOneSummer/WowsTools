using System.Windows.Forms;

namespace WowsTools
{
    public partial class Author : Form
    {
        public Author()
        {
            InitializeComponent();
        }

        private void linkLabelQQ_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelQQ.LinkVisited = true;
            System.Diagnostics.Process.Start("http://www.microsoft.com");
        }
    }
}
