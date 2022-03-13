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
            System.Diagnostics.Process.Start("https://qm.qq.com/cgi-bin/qm/qr?k=i1WjrkcEog-TC7C9bJ2CQi-zjVC33CoP&jump_from=webapi");
        }

        private void Author_Load(object sender, System.EventArgs e)
        {

        }
    }
}
