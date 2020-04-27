using ContactApps.Controller;
using ContactApps.Enums;
using ContactApps.Helper;
using ContactApps.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactApps.View.Component {
    public partial class UcContactForm : UserControl {
        public static event EventHandler GotoList;
        internal EnumState enumState;
        internal int ContactId { get; set; }
        ContactController ContactCtrl = null;

        public UcContactForm() {
            InitializeComponent();
            ContactCtrl = new ContactController();
        }

        internal void SetState(EnumState enumState) {
            this.enumState = enumState;
            switch (enumState) {
                case EnumState.Create:
                    btnSave.Text = "Save";
                    TextReadOnly(false);
                    break;
                case EnumState.Update:
                    btnSave.Text = "Update";
                    TextReadOnly(false);
                    break;
                case EnumState.Delete:
                    btnSave.Text = "Delete";
                    TextReadOnly(true);
                    break;
                default:
                    this.Enabled = false;
                    break;
            }
        }

        internal void SetData(ContactViewModel contact) {
            ContactId = contact.Id;
            txtName.Text = contact.Name;
            txtPhoneNumber.Text = contact.PhoneNumber;
            txtAddress.Text = contact.Address;
        }

        private void Clear() {
            foreach (var item in this.Controls) {
                if (item is TextBox) {
                    var txt = item as TextBox;
                    txt.Text = string.Empty;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            try {
                if (!ContactHelper.Validation(txtName.Text, txtPhoneNumber.Text)) {
                    MessageBox.Show("The field Name and Address is required!");
                } else {
                    if (enumState == EnumState.Create) {
                        var Contact = new ContactViewModel() {
                            Name = txtName.Text,
                            PhoneNumber = txtPhoneNumber.Text,
                            Address = txtAddress.Text
                        };
                        ContactCtrl.Post(Contact);
                    } else if (enumState == EnumState.Update) {
                        var Contact = new ContactViewModel() {
                            Id = ContactId,
                            Name = txtName.Text,
                            PhoneNumber = txtPhoneNumber.Text,
                            Address = txtAddress.Text
                        };
                        ContactCtrl.Put(Contact);
                    } else if (enumState == EnumState.Delete) {
                        ContactCtrl.Delete(ContactId);
                    }
                    Clear();
                    GotoList(sender, e);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e) {
            GotoList(sender, e);
        }

        private void TextReadOnly(bool value) {
            foreach (var item in this.Controls) {
                if (item is TextBox) {
                    var txt = item as TextBox;
                    txt.ReadOnly = value;
                }
            }
        }
    }
}
