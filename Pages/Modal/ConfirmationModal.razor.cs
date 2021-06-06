using System.Threading.Tasks;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Pages.Modal
{
    public partial class ConfirmationModal
    {
        #region Parameter
        [CascadingParameter] BlazoredModalInstance BlazoredModal {get;set;}
        [Parameter] public string Body {get;set;}
        #endregion
        private async Task Close(bool response){
            await BlazoredModal.CloseAsync(ModalResult.Ok(response));
        }
    }
}