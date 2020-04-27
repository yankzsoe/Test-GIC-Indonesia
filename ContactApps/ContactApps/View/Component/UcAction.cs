using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactApps.View.Component {
    public partial class UcAction : UserControl {
        public UcAction() {
            InitializeComponent();
        }

        private void btnList_Click(object sender, EventArgs e) {
            pnlStatus.Top = btnList.Top;
            pnlStatus.Height = btnList.Height;
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            pnlStatus.Top = btnAdd.Top;
            pnlStatus.Height = btnAdd.Height;
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            pnlStatus.Top = btnEdit.Top;
            pnlStatus.Height = btnEdit.Height;
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            pnlStatus.Top = btnDelete.Top;
            pnlStatus.Height = btnDelete.Height;
        }

        private void btnSettings_Click(object sender, EventArgs e) {
            MessageBox.Show("Coming soon..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExit_Click(object sender, EventArgs e) {
            try {
                DialogResult dialog = MessageBox.Show("Are you sure?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK) {
                    Application.Exit();
                }
            } catch (Exception es) {
                MessageBox.Show(es.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
