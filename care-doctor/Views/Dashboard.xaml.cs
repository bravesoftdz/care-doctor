using System;
using System.Collections.Generic;
using System.Linq;
using Couchbase.Lite;
using Couchbase.Lite.Query;
using Couchbase.Lite.Sync;
using Xamarin.Forms;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using caredoctor.Models;
using caredoctor.Services;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

namespace caredoctor.Views
{
    public partial class Dashboard : ContentPage
    {
        PatientModel _patient_model;
        LoginModel _login_model;
        PatientService _patient_service;

        public Dashboard()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            _patient_model = new PatientModel();
            _login_model = new LoginModel();
            _patient_service = new PatientService();
            //try
            //{
            //    txtCareId.Text = (Application.Current.Properties["care_id"].ToString());
            //    txtEmail.Text = (Application.Current.Properties["email"].ToString());
            //    txtToken.Text = (Application.Current.Properties["token"].ToString());
            //    txtExpireKey.Text = (Application.Current.Properties["expire_key"].ToString());
            //}
            //catch(Exception e){
            //    Console.WriteLine(e.ToString());
            //}
        }

        //public async void btnNewPatientView(object sender, EventArgs e)
        //{
        //    await Navigation.PushPopupAsync(_createPatientView);
        //}

        private void showAddModal(object sender, EventArgs e)
        {
            addDetailModal.IsVisible = true;
        }

        private void closeAddModal(object sender, EventArgs e)
        {
            addDetailModal.IsVisible = false;
        }

        private void showAddPatientForm(object sender, EventArgs e)
        {
            addPatForm.IsVisible = true;
        }

        //public async void btnPatientSave(object sender, EventArgs e)
        //{
        //    _patient_model.name = txtPatName.Text.ToString();
        //    _patient_model.mobile = txtPatMobile.Text.ToString();
        //    _patient_model.dob = txtDob.Date.ToShortDateString();
        //    _patient_model.gender = (string)genderPicker.ItemsSource[genderPicker.SelectedIndex];

        //    _login_model.patients_list.Add(_patient_model.mobile);
        //    _login_model.email = (Application.Current.Properties["email"].ToString());

        //    _patient_service.CreatePatient(_patient_model);

        //    HttpResponseMessage login_response;
        //    login_response = await Task.Run(async () => await _patient_service.AddPatientListToDoctorAsync(_login_model));
        //    Console.WriteLine(login_response.StatusCode);
        //    if (login_response.StatusCode == HttpStatusCode.OK)
        //    {
        //        var response = (login_response.Content.ReadAsStringAsync().Result);
        //        Console.WriteLine(response);
        //    }
        //    _patient_service.GetAllPatients(_patient_model);
        //}

        public void btnPatientSave(object sender, EventArgs e)
        {
            _patient_service.GetAllPatients(_patient_model);
            //_patient_service.CreatePatient(_patient_model);
        }

        private void closeAddPatientForm(object sender, EventArgs e)
        {
            addPatForm.IsVisible = false;
        }
    }
}
