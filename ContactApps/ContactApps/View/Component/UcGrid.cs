using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactApps.ViewModel;
using ContactApps.Helper;
using ContactApps.Controller;
using System.Diagnostics.Contracts;

namespace ContactApps.View.Component {
    public partial class UcGrid : UserControl {
        public static ContactViewModel ContactData = null;
        ContactController ContactCtrl = null;
        public UcGrid() {
            InitializeComponent();
            ContactCtrl = new ContactController();
            dtGrid.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(6, 240, 9);
            dtGrid.DataSource = ContactCtrl.Get();
        }

        private void dtGrid_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e) {
            try {
                if (e.RowIndex > -1) {
                    dtGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(128, 255, 128);
                }
            } catch (Exception es) {
                MessageBox.Show(es.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtGrid_CellMouseLeave(object sender, DataGridViewCellEventArgs e) {
            try {
                if (e.RowIndex > -1) {
                    dtGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            } catch (Exception es) {
                MessageBox.Show(es.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtGrid_CellClick(object sender, DataGridViewCellEventArgs e) {
            try {
                if (e.RowIndex > -1) {
                    ContactData = new ContactViewModel() {
                        Id = (int)dtGrid.Rows[e.RowIndex].Cells[0].Value,
                        Name = $"{dtGrid.Rows[e.RowIndex].Cells[1].Value}",
                        PhoneNumber = $"{dtGrid.Rows[e.RowIndex].Cells[2].Value}",
                        Address = $"{dtGrid.Rows[e.RowIndex].Cells[3].Value}",
                    };
                    lblName.Text = $"Name: {ContactData.Name}";
                    lblPhone.Text = $"Phone: {ContactData.PhoneNumber}";
                }
            } catch (Exception es) {
                MessageBox.Show(es.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void btnRefresh_Click(object sender, EventArgs e) {
            dtGrid.DataSource = ContactCtrl.Get();
        }
    }
}
