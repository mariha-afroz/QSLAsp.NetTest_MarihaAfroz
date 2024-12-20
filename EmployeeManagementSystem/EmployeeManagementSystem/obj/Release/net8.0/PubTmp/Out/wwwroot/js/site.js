KendoLicensing.setScriptKey('141j044b041h541j4i1d542e582i511k0b1i111c1224191j0h1e152503295533142h572b5i30571g532k5i2g5g230f1e0i1g0j201522101i1921072d513718305b27612h5b1c4k214g1k5g2b571f4d34564a504b4i424c45523j4j3c5i1h0a3i5a2e5k295e2e541f591i4e31534951484h414f464k3i4g395f1g093j571g53236024541d572b122h0a2j0b28022a0d3006291a255925031c135i3c5g3d1j1a1k04270630091f0g5a0g1f09524a524b590k1c381g0j59315e341h111e01230f352j4200331e52195f095h0c424j2236254g4922472k460a2f0b3j563e0g');

function SideBarToggle() {
    if (document.getElementById('menu-side').clientWidth == 200) {
        SetToMin();
    } else {
        SetToMax();
    }
}

function changeSignature(name, sign) {
    document.getElementById(sign).value = document.getElementById(name).value
}

function CreateCookie(name, value, days) {
    var expires = "";
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toUTCString();
    }
    document.cookie = name + "=" + value + expires + "; path=/";
}

function GetCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

function SetMenuPosition() {
    var cName = "SideMenu";
    var cValue = GetCookie(cName);

    if (cValue == null) {
        CreateCookie(cName, "Max", 7);
    }

    if (cValue == "Max") {
        SetToMax();
    }
    else if (cValue == "Min") {
        SetToMin();
    }
}

function SetToMax() {
    document.getElementById("menu-side").style.width = "200px";
    document.getElementById("menu-head").style.width = "200px";
    var sideItems = document.getElementsByClassName('side-item'), i;
    for (var i = 0; i < sideItems.length; i++) {
        sideItems[i].style.display = 'inline-block';
    }
    document.getElementById('menu-side-icon').classList.add('glyphicon-chevron-right');
    document.getElementById('menu-side-icon').classList.remove('glyphicon-align-justify');
    CreateCookie("SideMenu", "Max", 7);
}

function SetToMin() {
    document.getElementById("menu-side").style.width = "50px";
    document.getElementById("menu-head").style.width = "50px";
    var sideItems = document.getElementsByClassName('side-item'), i;
    for (var i = 0; i < sideItems.length; i++) {
        sideItems[i].style.display = 'none';
    }
    document.getElementById('menu-side-icon').classList.remove('glyphicon-chevron-right');
    document.getElementById('menu-side-icon').classList.add('glyphicon-align-justify');
    CreateCookie("SideMenu", "Min", 7);
}

function FloatingSaveUpdateCancel(){
    var saveCancel = $('#floating-save-cancel');
    var formContainer = saveCancel.closest('form'); // Selects the closest form parent

    if (formContainer.length) {
        $(window).scroll(function () {
            var formBottom = formContainer.offset().top + formContainer.height() - saveCancel.height();
            var windowBottom = $(window).scrollTop() + $(window).height();

            if (windowBottom < formBottom) {
                saveCancel.addClass('save-cancel-floating');

                function adjustSaveCancelPosition() {
                    var formOffset = formContainer.offset();
                    var formWidth = formContainer.outerWidth();
                    var saveCancelWidth = saveCancel.outerWidth();
                }

                adjustSaveCancelPosition();
                $(window).resize(adjustSaveCancelPosition);
            } else {
                saveCancel.removeClass('save-cancel-floating');
            }
        });
    }
}

