using ContactApps.Helper;
using ContactApps.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace ContactApps.Controller {
    public class ContactController {

        public List<ContactViewModel> Get() {
            var rest = new List<ContactViewModel>();
            try {
                var url = ContactHelper.ReadSettings("BaseAddress");
                WebRequest request = WebRequest.Create(url);
                request.Method = "GET";
                HttpWebResponse response = null;
                response = (HttpWebResponse)request.GetResponse();
                string result = string.Empty;
                using (var stream = response.GetResponseStream()) {
                    using (var reader = new StreamReader(stream)) {
                        result = reader.ReadToEnd();
                    }
                }
                var serializer = new JavaScriptSerializer();
                rest = (List<ContactViewModel>)serializer.Deserialize(result, typeof(List<ContactViewModel>));
            } catch (Exception es) {
                MessageBox.Show(es.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return rest;
        }

        public List<ContactViewModel> Get(string name) {
            try {
                var url = ContactHelper.ReadSettings("BaseAddress");
                url = $"{url}/search/{name}";
                WebRequest request = WebRequest.Create(url);
                request.Method = "GET";

                HttpWebResponse response = null;
                response = (HttpWebResponse)request.GetResponse();
                string result = string.Empty;
                using (var stream = response.GetResponseStream()) {
                    using (var reader = new StreamReader(stream)) {
                        result = reader.ReadToEnd();
                    }
                }
                var serializer = new JavaScriptSerializer();
                return (List<ContactViewModel>)serializer.Deserialize(result, typeof(List<ContactViewModel>));                
            } catch (Exception es) {
                throw es;
            }
        }

        public void Post(ContactViewModel contact) {
            try {
                var url = ContactHelper.ReadSettings("BaseAddress");
                WebRequest request = WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                string JsonString = new JavaScriptSerializer().Serialize(contact);
                using (var writer = new StreamWriter(request.GetRequestStream())) {
                    writer.Write(JsonString);
                    writer.Flush();
                    writer.Close();
                    var httpResponse = (HttpWebResponse)request.GetResponse();
                    //using (var reader = new StreamReader(httpResponse.GetResponseStream())) {
                    //    var result = reader.ReadToEnd();
                    //}
                }
            } catch (Exception es) {
                throw es;
            }
        }

        public void Put(ContactViewModel contact) {
            try {
                var url = ContactHelper.ReadSettings("BaseAddress");
                url = $"{url}/{contact.Id}";
                WebRequest request = WebRequest.Create(url);
                request.Method = "PUT";
                request.ContentType = "application/json";
                string JsonString = new JavaScriptSerializer().Serialize(contact);
                using (var writer = new StreamWriter(request.GetRequestStream())) {
                    writer.Write(JsonString);
                    writer.Flush();
                    writer.Close();
                    var httpResponse = (HttpWebResponse)request.GetResponse();
                    //using (var reader = new StreamReader(httpResponse.GetResponseStream())) {
                    //    var result = reader.ReadToEnd();
                    //}
                }
            } catch (Exception es) {
                throw es;
            }
        }

        public void Delete(int ContactId) {
            try {
                var url = ContactHelper.ReadSettings("BaseAddress");
                url = $"{url}/{ContactId}";
                WebRequest request = WebRequest.Create(url);
                request.Method = "DELETE";
                request.ContentType = "application/json";
                var httpResponse = (HttpWebResponse)request.GetResponse();
            } catch (Exception es) {
                throw es;
            }
        }

    }
}
