using ContactApps.Enums;
using ContactApps.Helper;
using ContactApps.View.Component;
using ContactApps.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace ContactApps {
    public partial class MainForm : Form {
        private bool IsCollapse = false;
        private UcGrid GridContact = null;
        private UcContactForm ContactForm = null;

        public MainForm() {
            InitializeComponent();
            GridContact = new UcGrid();
            ContactForm = new UcContactForm();
            UcContactForm.GotoList += ContactForm_GotoList;
            ucHeader.btnCollapse.Click += BtnCollapse_Click;
            ucHeader.SearchData += UcHeader_SearchData;
            ucAction.btnList.Click += BtnList_Click;
            ucAction.btnAdd.Click += BtnAdd_Click;
            ucAction.btnEdit.Click += BtnEdit_Click;
            ucAction.btnDelete.Click += BtnDelete_Click;
            SetControl(GridContact);
            UpdateHeaderStatus("Contact List");
        }

        private void UcHeader_SearchData(object sender, List<ContactViewModel> e) {
            GridContact.dtGrid.DataSource = e;
            GridContact.dtGrid.Refresh();
        }

        private void ContactForm_GotoList(object sender, EventArgs e) {
            BtnList_Click(sender,e);
        }

        private void BtnDelete_Click(object sender, EventArgs e) {
            if (pnlContent.Controls.ContainsKey("UcContactForm") &&
                ContactForm.enumState == EnumState.Delete)
                return;

            if (UcGrid.ContactData == null) {
                MessageBox.Show("Please select at least one data in List", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DefaultNavPosition();
            } else {
                ContactForm = new UcContactForm();
                ContactForm.SetData(UcGrid.ContactData);
                ContactForm.SetState(EnumState.Delete);
                SetControl(ContactForm);
                UpdateHeaderStatus("Delete Contact");
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e) {
            if (pnlContent.Controls.ContainsKey("UcContactForm") &&
                ContactForm.enumState == EnumState.Update)
                return;

            if (UcGrid.ContactData == null) {
                MessageBox.Show("Please select at least one data in List","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                DefaultNavPosition();
            } else {
                ContactForm = new UcContactForm();
                ContactForm.SetData(UcGrid.ContactData);
                ContactForm.SetState(EnumState.Update);
                SetControl(ContactForm);
                UpdateHeaderStatus("Edit Contact");
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e) {
            if (pnlContent.Controls.ContainsKey("UcContactForm") &&
                ContactForm.enumState == EnumState.Create)
                return;

            ContactForm = new UcContactForm();
            ContactForm.SetState(EnumState.Create);
            SetControl(ContactForm);
            UpdateHeaderStatus("Add New Contact");
        }

        private void BtnList_Click(object sender, EventArgs e) {
            if (pnlContent.Controls.ContainsKey("UcGrid"))
                return;
            SetControl(GridContact);
            GridContact.btnRefresh_Click(sender, e);
            UcGrid.ContactData = null;
            DefaultNavPosition();
            UpdateHeaderStatus("Contact List");
        }

        private void BtnCollapse_Click(object sender, EventArgs e) {
            if (IsCollapse) {
                ucHeader.btnCollapse.Image = Properties.Resources.collapse_left;
                splitContainer1.Panel1Collapsed = false;
                IsCollapse = false;
            } else {
                ucHeader.btnCollapse.Image = Properties.Resources.collapse_right;
                splitContainer1.Panel1Collapsed = true;
                IsCollapse = true;
            }
        }

        public void SetControl(Control control) {
            pnlContent.Controls.Clear();
            if (control != null) {
                control.Width = pnlContent.Width;
                control.Height = control.Height;
                control.Dock = DockStyle.Fill;
                pnlContent.Controls.Add(control);
            }
        }

        private void DefaultNavPosition() {
            ucAction.pnlStatus.Top = ucAction.btnList.Top;
            ucAction.pnlStatus.Height = ucAction.btnList.Height;
        }

        private void UpdateHeaderStatus(string status) {
            ucHeader.lblStatus.Text = status;
        }
    }
}
