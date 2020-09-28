function CustomConfirm(titulo, mensaje, tipo) {
    return new Promise((resolve) => {
        Swal.fire({
            title: titulo,
            text: mensaje,
            icon: tipo,
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Confirmar'
        }).then((result) => {
            if (result.value) {
                Swal.fire(
                    'Eliminado!',
                    'El registro se eliminó correctamente correctamente.',
                    'success'
                )
                resolve(true);

            } else {
              
                resolve(false);
            }
        });
    });
}

function saveAsFile(filename, bytesBase64) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + bytesBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);

}
function loadPage() { 

    Notiflix.Loading.Circle();  
}

function remove() {
   
    Notiflix.Loading.Remove(10);
}

function EmptyDbNotify() {
  
    Notiflix.Notify.Init({
        width: '280px',
        position: 'right-bottom',
        distance: '10px',
        opacity: 1,
        borderRadius: '5px',
        rtl: false,
        timeout: 3000,
        messageMaxLength: 110,
        backOverlay: false,
        backOverlayColor: 'rgba(0,0,0,0.5)',
        plainText: true,
        showOnlyTheLastOne: false,
        clickToClose: false,
        ID: 'NotiflixNotify',
        className: 'notiflix-notify',
        zindex: 4001,
        useGoogleFont: true,
        fontFamily: 'Quicksand', fontSize: '13px',
        cssAnimation: true,
        cssAnimationDuration: 400,
        cssAnimationStyle: 'fade',
        closeButton: false,
        useIcon: true,
        useFontAwesome: false,
        fontAwesomeIconStyle: 'basic',
        fontAwesomeIconSize: '34px',
        success: {
            background: '#32c682',
            textColor: '#fff',
            childClassName: 'success',
            notiflixIconColor: 'rgba(0,0,0,0.2)',
            fontAwesomeClassName: 'fas fa-check-circle',
            fontAwesomeIconColor: 'rgba(0,0,0,0.2)',
        },
        failure: {
            background: '#ff5549',
            textColor: '#fff',
            childClassName: 'failure',
            notiflixIconColor: 'rgba(0,0,0,0.2)',
            fontAwesomeClassName: 'fas fa-times-circle',
            fontAwesomeIconColor: 'rgba(0,0,0,0.2)',
        }, warning: {
            background: '#eebf31',
            textColor: '#fff',
            childClassName: 'warning',
            notiflixIconColor: 'rgba(0,0,0,0.2)',
            fontAwesomeClassName: 'fas fa-exclamation-circle',
            fontAwesomeIconColor: 'rgba(0,0,0,0.2)',
        }, info: { background: '#26c0d3', textColor: '#fff', childClassName: 'info', notiflixIconColor: 'rgba(0,0,0,0.2)', fontAwesomeClassName: 'fas fa-info-circle', fontAwesomeIconColor: 'rgba(0,0,0,0.2)', },
    }); 
    Notiflix.Notify.Failure('No se encontraron registros relacionados en la base de datos');
}

function Welcome() {
    Notiflix.Notify.Init({
        width: '280px',
        position: 'right-bottom',
        distance: '10px',
        opacity: 1,
        borderRadius: '5px',
        rtl: false,
        timeout: 3000,
        messageMaxLength: 110,
        backOverlay: false,
        backOverlayColor: 'rgba(0,0,0,0.5)',
        plainText: true,
        showOnlyTheLastOne: false,
        clickToClose: false,
        ID: 'NotiflixNotify',
        className: 'notiflix-notify',
        zindex: 4001,
        useGoogleFont: true,
        fontFamily: 'Quicksand', fontSize: '13px',
        cssAnimation: true,
        cssAnimationDuration: 400,
        cssAnimationStyle: 'fade',
        closeButton: false,
        useIcon: true,
        useFontAwesome: false,
        fontAwesomeIconStyle: 'basic',
        fontAwesomeIconSize: '34px',
        success: {
            background: '#32c682',
            textColor: '#fff',
            childClassName: 'success',
            notiflixIconColor: 'rgba(0,0,0,0.2)',
            fontAwesomeClassName: 'fas fa-check-circle',
            fontAwesomeIconColor: 'rgba(0,0,0,0.2)',
        },
        failure: {
            background: '#ff5549',
            textColor: '#fff',
            childClassName: 'failure',
            notiflixIconColor: 'rgba(0,0,0,0.2)',
            fontAwesomeClassName: 'fas fa-times-circle',
            fontAwesomeIconColor: 'rgba(0,0,0,0.2)',
        }, warning: {
            background: '#eebf31',
            textColor: '#fff',
            childClassName: 'warning',
            notiflixIconColor: 'rgba(0,0,0,0.2)',
            fontAwesomeClassName: 'fas fa-exclamation-circle',
            fontAwesomeIconColor: 'rgba(0,0,0,0.2)',
        }, info: { background: '#26c0d3', textColor: '#fff', childClassName: 'info', notiflixIconColor: 'rgba(0,0,0,0.2)', fontAwesomeClassName: 'fas fa-info-circle', fontAwesomeIconColor: 'rgba(0,0,0,0.2)', },
    });
    Notiflix.Notify.Success('Bienvenido, usted se ha autenticado correctamente!');

}

function RegistroEditado() {
    Notiflix.Notify.Init({
        width: '280px',
        position: 'right-bottom',
        distance: '10px',
        opacity: 1,
        borderRadius: '5px',
        rtl: false,
        timeout: 3000,
        messageMaxLength: 110,
        backOverlay: false,
        backOverlayColor: 'rgba(0,0,0,0.5)',
        plainText: true,
        showOnlyTheLastOne: false,
        clickToClose: false,
        ID: 'NotiflixNotify',
        className: 'notiflix-notify',
        zindex: 4001,
        useGoogleFont: true,
        fontFamily: 'Quicksand', fontSize: '13px',
        cssAnimation: true,
        cssAnimationDuration: 400,
        cssAnimationStyle: 'fade',
        closeButton: false,
        useIcon: true,
        useFontAwesome: false,
        fontAwesomeIconStyle: 'basic',
        fontAwesomeIconSize: '34px',
        success: {
            background: '#32c682',
            textColor: '#fff',
            childClassName: 'success',
            notiflixIconColor: 'rgba(0,0,0,0.2)',
            fontAwesomeClassName: 'fas fa-check-circle',
            fontAwesomeIconColor: 'rgba(0,0,0,0.2)',
        },
        failure: {
            background: '#ff5549',
            textColor: '#fff',
            childClassName: 'failure',
            notiflixIconColor: 'rgba(0,0,0,0.2)',
            fontAwesomeClassName: 'fas fa-times-circle',
            fontAwesomeIconColor: 'rgba(0,0,0,0.2)',
        }, warning: {
            background: '#eebf31',
            textColor: '#fff',
            childClassName: 'warning',
            notiflixIconColor: 'rgba(0,0,0,0.2)',
            fontAwesomeClassName: 'fas fa-exclamation-circle',
            fontAwesomeIconColor: 'rgba(0,0,0,0.2)',
        }, info: { background: '#26c0d3', textColor: '#fff', childClassName: 'info', notiflixIconColor: 'rgba(0,0,0,0.2)', fontAwesomeClassName: 'fas fa-info-circle', fontAwesomeIconColor: 'rgba(0,0,0,0.2)', },
    });
    Notiflix.Notify.Info('El registro ha sido guardado correctamente');
}

function RegistroAgregado() {
    Notiflix.Notify.Init({
        width: '280px',
        position: 'right-bottom',
        distance: '10px',
        opacity: 1,
        borderRadius: '5px',
        rtl: false,
        timeout: 3000,
        messageMaxLength: 110,
        backOverlay: false,
        backOverlayColor: 'rgba(0,0,0,0.5)',
        plainText: true,
        showOnlyTheLastOne: false,
        clickToClose: false,
        ID: 'NotiflixNotify',
        className: 'notiflix-notify',
        zindex: 4001,
        useGoogleFont: true,
        fontFamily: 'Quicksand', fontSize: '13px',
        cssAnimation: true,
        cssAnimationDuration: 400,
        cssAnimationStyle: 'fade',
        closeButton: false,
        useIcon: true,
        useFontAwesome: false,
        fontAwesomeIconStyle: 'basic',
        fontAwesomeIconSize: '34px',
        success: {
            background: '#32c682',
            textColor: '#fff',
            childClassName: 'success',
            notiflixIconColor: 'rgba(0,0,0,0.2)',
            fontAwesomeClassName: 'fas fa-check-circle',
            fontAwesomeIconColor: 'rgba(0,0,0,0.2)',
        },
        failure: {
            background: '#ff5549',
            textColor: '#fff',
            childClassName: 'failure',
            notiflixIconColor: 'rgba(0,0,0,0.2)',
            fontAwesomeClassName: 'fas fa-times-circle',
            fontAwesomeIconColor: 'rgba(0,0,0,0.2)',
        }, warning: {
            background: '#eebf31',
            textColor: '#fff',
            childClassName: 'warning',
            notiflixIconColor: 'rgba(0,0,0,0.2)',
            fontAwesomeClassName: 'fas fa-exclamation-circle',
            fontAwesomeIconColor: 'rgba(0,0,0,0.2)',
        }, info: { background: '#26c0d3', textColor: '#fff', childClassName: 'info', notiflixIconColor: 'rgba(0,0,0,0.2)', fontAwesomeClassName: 'fas fa-info-circle', fontAwesomeIconColor: 'rgba(0,0,0,0.2)', },
    });
    Notiflix.Notify.Success('Se ha agregado un nuevo registro correctamente.');
}
function NotiflixSuccess(mensaje) {
    Notiflix.Notify.Init({
        width: '280px',
        position: 'right-bottom',
        distance: '10px',
        opacity: 1,
        borderRadius: '5px',
        rtl: false,
        timeout: 3000,
        messageMaxLength: 110,
        backOverlay: false,
        backOverlayColor: 'rgba(0,0,0,0.5)',
        plainText: true,
        showOnlyTheLastOne: false,
        clickToClose: false,
        ID: 'NotiflixNotify',
        className: 'notiflix-notify',
        zindex: 4001,
        useGoogleFont: true,
        fontFamily: 'Quicksand', fontSize: '13px',
        cssAnimation: true,
        cssAnimationDuration: 400,
        cssAnimationStyle: 'fade',
        closeButton: false,
        useIcon: true,
        useFontAwesome: false,
        fontAwesomeIconStyle: 'basic',
        fontAwesomeIconSize: '34px',
        success: {
            background: '#32c682',
            textColor: '#fff',
            childClassName: 'success',
            notiflixIconColor: 'rgba(0,0,0,0.2)',
            fontAwesomeClassName: 'fas fa-check-circle',
            fontAwesomeIconColor: 'rgba(0,0,0,0.2)',
        },
        failure: {
            background: '#ff5549',
            textColor: '#fff',
            childClassName: 'failure',
            notiflixIconColor: 'rgba(0,0,0,0.2)',
            fontAwesomeClassName: 'fas fa-times-circle',
            fontAwesomeIconColor: 'rgba(0,0,0,0.2)',
        }, warning: {
            background: '#eebf31',
            textColor: '#fff',
            childClassName: 'warning',
            notiflixIconColor: 'rgba(0,0,0,0.2)',
            fontAwesomeClassName: 'fas fa-exclamation-circle',
            fontAwesomeIconColor: 'rgba(0,0,0,0.2)',
        }, info: { background: '#26c0d3', textColor: '#fff', childClassName: 'info', notiflixIconColor: 'rgba(0,0,0,0.2)', fontAwesomeClassName: 'fas fa-info-circle', fontAwesomeIconColor: 'rgba(0,0,0,0.2)', },
    });
    Notiflix.Notify.Success(mensaje);
}

