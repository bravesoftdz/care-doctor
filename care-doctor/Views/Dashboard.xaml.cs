using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace caredoctor.Views
{
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            try
            {
                txtCareId.Text = (Application.Current.Properties["care_id"].ToString());
                txtEmail.Text = (Application.Current.Properties["email"].ToString());
                txtToken.Text = (Application.Current.Properties["token"].ToString());
                txtExpireKey.Text = (Application.Current.Properties["expire_key"].ToString());
            }
            catch(Exception e){
                Console.WriteLine(e.ToString());
            }
        }
    }
}
