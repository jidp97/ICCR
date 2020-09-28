using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;


namespace LaugamaCorp.Client.Helpers
{

    public static class IJSExtensions
    {

        public static ValueTask<object> GuardarComoAsync(
            this IJSRuntime js,
            string filename,
            byte[] bytesBase64)
        {
            return js.InvokeAsync<object>("saveAsFile", filename, Convert.ToBase64String(bytesBase64));
        }

        public static async Task<object> MostrarMensajeAsync(this IJSRuntime js, string mensaje)
        {
            return await js.InvokeAsync<object>("Swal.fire", mensaje);
        }
        public static async Task<object> MostrarMensajeAsync(this IJSRuntime js, string titulo, string mensaje, TipoMensajeSweetAlert TipoMensaje)
        {
            return await js.InvokeAsync<object>("Swal.fire", titulo, mensaje, TipoMensaje.ToString());
        }

        public static async Task<bool> ConfirmAsync(this IJSRuntime js, string titulo, string mensaje, TipoMensajeSweetAlert tipoMensaje)
        {
            return await js.InvokeAsync<bool>("CustomConfirm", titulo, mensaje, tipoMensaje.ToString());
        }
        public static async Task<object> CargarAsync(this IJSRuntime js)
        {
            return await js.InvokeAsync<object>("loadPage");
        }
        public static async Task<object> RemoveAsync(this IJSRuntime js)
        {
            return await js.InvokeAsync<object>("remove");
        }
        public static async Task<object> EmptyDbNotifyAsync(this IJSRuntime js)
        {
            return await js.InvokeAsync<object>("EmptyDbNotify");
        }
        public static async Task<object> WelcomeAsync(this IJSRuntime js)
        {
            return await js.InvokeAsync<object>("Welcome");
        }
        public static async Task<object> RegistroEditadoAsync(this IJSRuntime js)
        {
            return await js.InvokeAsync<object>("RegistroEditado");
        }
        public static async Task<object> RegistroAgregadoAsync(this IJSRuntime js)
        {
            return await js.InvokeAsync<object>("RegistroAgregado");
        }
        public static async Task<object> NotiflixSuccessAsync(this IJSRuntime js, string mensaje)
        {
            return await js.InvokeAsync<object>("NotiflixSuccess", mensaje);
        }
    }

    public enum TipoMensajeSweetAlert
    {
        question, warning, error, success, info
    }

}
