#region System References
using System;
using System.Threading.Tasks;
#endregion
#region BlazorApp Reference
using BlazorApp.Pages.Modal;
using Blazored.Modal;
using Blazored.Modal.Services;
#endregion
#region Microsoft References
using Microsoft.AspNetCore.Components;
#endregion
namespace BlazorApp.Pages.Components
{
    public partial class ConfirmationCheckBox
    {
        #region Parameter
        // Parameter for div that wraps the input checkbox
        [Parameter] public string Class {get;set;}
        // Parameter for Checkbox name
        [Parameter] public string Name {get;set;}
        // Parameter to defined message on popup when checkbox is checked
        [Parameter] public string PopupMessageForTrue {get;set;}
        // Parameter to defined message on popup when checkbox is unchecked
        [Parameter] public string PopupMessageForFalse {get;set;}
        // Parameter to defined event call back on Popup button action
        [Parameter] public EventCallback<bool> OnPopupClicked {get;set;}
        // Parameter to make the checkbox readonly
         [Parameter] public bool ReadOnly {get;set;}
        // Parameter to define id of the checkbox
        [Parameter] public string Id {get;set;}
        // Parameter to bind the value of checkbox
        [Parameter] public bool? Value{
            get=>_value;
            set{
                if(_value==value) return;

                _value=value;
                ValueChanged.InvokeAsync(value);
            }
        }
        // Parameter to handle two way binding
        [Parameter] public EventCallback<bool?> ValueChanged {get;set;}
        #endregion
        #region Inject
        [Inject] IModalService Modal {get;set;}
        #endregion
        bool? _value;
        string Message;
        #region  Protected Method
        protected override void OnInitialized(){
            Class=string.IsNullOrEmpty(Class)?"checkbox":Class; 
        }
        #endregion
        #region  Private Method
        /// <summary>
        /// Method to change the Check box change event
        /// </summary>
        /// <param name="args">ChangeEventArgs</param>
        /// <returns></returns>
        private async Task OnChecked(ChangeEventArgs args){
            bool argsValue=Convert.ToBoolean(args.Value);

            Message= !argsValue ? PopupMessageForTrue : PopupMessageForFalse;
            Message = string.IsNullOrEmpty(Message) ? "Are you sure ?" : Message;

            var options= new ModalOptions() {DisableBackgroundCancel=true,HideCloseButton=true};
            ModalParameters parameter = new ModalParameters();
            parameter.Add("Body", Message);

            var formModal = Modal.Show<ConfirmationModal>("Confirm", parameter,options);
            var result= await formModal.Result;

            if(!result.Cancelled){
                if(Convert.ToBoolean(result.Data))
                    await ValueChanged.InvokeAsync(argsValue);
                else
                    await ValueChanged.InvokeAsync(!argsValue);
                await OnPopupClicked.InvokeAsync(Convert.ToBoolean(result.Data));
            }
            StateHasChanged();
        }
        #endregion
    }
}