﻿using System;
using System.Collections.Generic;
//using System.CodeDom.Compiler;
using System.Diagnostics;
using Xamarin.Forms;

namespace MyShop
{
	public partial class FeedbackPage : ContentPage
	{
		FeedbackViewModel viewModel;
		public FeedbackPage()
		{
			InitializeComponent();
			BindingContext = viewModel = new FeedbackViewModel(this);


			//PickerRating.SelectedIndex = 10;
			PickerServiceType.SelectedIndex = 0;

			ButtonSelectLocation.Clicked += async (sender, e) =>
			{

				//var feedback = new Feedback();
				var selectpos = new SelectPositionPage(viewModel);
				//selectpos.BindingContext = feedback;
				await Navigation.PushAsync(selectpos);
				//var a=Navigation.NavigationStack[0];


			};
			/*
			PickerStore.SelectedIndexChanged += (sender, e) => 
			{
				viewModel.StoreName = PickerStore.Items[PickerStore.SelectedIndex];
			};
*/
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			var showAlert = false;
			try
			{
				var stores = await viewModel.GetStoreAsync();
				//foreach(var store in stores)
				//PickerStore.Items.Add(store.Name);
			}
			catch (Exception ex)
			{

				showAlert = true;
			}
			if (showAlert)
				await DisplayAlert("Uh oh :(", "Unable to get locations, don't worry you can still submit feedback.", "OK");


		}
	}
}

