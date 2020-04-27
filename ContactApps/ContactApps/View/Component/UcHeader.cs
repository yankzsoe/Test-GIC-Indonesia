using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactApps.Controller;
using ContactApps.ViewModel;

namespace ContactApps.View.Component {
    public partial class UcHeader : UserControl {
        ContactController ContactCtrl = null;
        public event EventHandler<List<ContactViewModel>> SearchData;
        public UcHeader() {
            InitializeComponent();
            ContactCtrl = new ContactController();
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(txtName.Text)) return;
            try {
                var result = ContactCtrl.Get(txtName.Text);
                SearchData(sender, result);
            } catch (Exception es) {
                MessageBox.Show(es.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
