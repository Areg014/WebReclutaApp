function formEnable(n1, n2, n3, n4, n5, n6, n7, n8) {
    if (document.getElementById("inputField1") != null) {
        if (n1 == 1) {
            document.getElementById("inputField1").disabled = false;
            document.getElementById("inputField1").style.transition = "background 0.5s";    
            document.getElementById("inputField1").style.background = "#fff";
            document.getElementById("inputField1").style.cursor = "auto";
        }
        else {
            document.getElementById("inputField1").disabled = true;
            document.getElementById("inputField1").style.transition = "background 0.5s";
            document.getElementById("inputField1").style.background = "#c9c9c9";
            document.getElementById("inputField1").style.cursor = "not-allowed";
        }
    }
    if (document.getElementById("inputField2") != null) {
        if (n2 == 1) {
            document.getElementById("inputField2").disabled = false;
            document.getElementById("inputField2").style.transition = "background 0.5s";
            document.getElementById("inputField2").style.background = "#fff";
            document.getElementById("inputField2").style.cursor = "auto";
        }
        else {
            document.getElementById("inputField2").disabled = true;
            document.getElementById("inputField2").style.transition = "background 0.5s";
            document.getElementById("inputField2").style.background = "#c9c9c9";
            document.getElementById("inputField2").style.cursor = "not-allowed";
        }
    }
    if (document.getElementById("inputField3") != null) {
        if (n3 == 1) {
            document.getElementById("inputField3").disabled = false;
            document.getElementById("inputField3").style.transition = "background 0.5s";
            document.getElementById("inputField3").style.background = "#fff";
            document.getElementById("inputField3").style.cursor = "auto";
        }
        else {
            document.getElementById("inputField3").disabled = true;
            document.getElementById("inputField3").style.transition = "background 0.5s";
            document.getElementById("inputField3").style.background = "#c9c9c9";
            document.getElementById("inputField3").style.cursor = "not-allowed";
        }
    }
    if (document.getElementById("inputField4") != null) {
        if (n4 == 1) {
            document.getElementById("inputField4").disabled = false;
            document.getElementById("inputField4").style.transition = "background 0.5s";
            document.getElementById("inputField4").style.background = "#fff";
            document.getElementById("inputField4").style.cursor = "auto";
        }
        else {
            document.getElementById("inputField4").disabled = true;
            document.getElementById("inputField4").style.transition = "background 0.5s";
            document.getElementById("inputField4").style.background = "#c9c9c9";
            document.getElementById("inputField4").style.cursor = "not-allowed";
        }
    }
    if (document.getElementById("inputField5") != null) {
        if (n5 == 1) {
            document.getElementById("inputField5").disabled = false;
            document.getElementById("inputField5").style.transition = "background 0.5s";
            document.getElementById("inputField5").style.background = "#fff";
            document.getElementById("inputField5").style.cursor = "auto";
        }
        else {
            document.getElementById("inputField5").disabled = true;
            document.getElementById("inputField5").style.transition = "background 0.5s";
            document.getElementById("inputField5").style.background = "#c9c9c9";
            document.getElementById("inputField5").style.cursor = "not-allowed";
        }
    }
    if (document.getElementById("inputField6") != null) {
        if (n6 == 1) {
            document.getElementById("inputField6").disabled = false;
            document.getElementById("inputField6").style.transition = "background 0.5s";
            document.getElementById("inputField6").style.background = "#fff";
            document.getElementById("inputField6").style.cursor = "auto";
        }
        else {
            document.getElementById("inputField6").disabled = true;
            document.getElementById("inputField6").style.transition = "background 0.5s";
            document.getElementById("inputField6").style.background = "#c9c9c9";
            document.getElementById("inputField6").style.cursor = "not-allowed";
        }
    }
    if (document.getElementById("inputField7") != null) {
        if (n7 == 1) {
            document.getElementById("inputField7").disabled = false;
            document.getElementById("inputField7").style.transition = "background 0.5s";
            document.getElementById("inputField7").style.background = "#fff";
            document.getElementById("inputField7").style.cursor = "auto";
        }
        else {
            document.getElementById("inputField7").disabled = true;
            document.getElementById("inputField7").style.transition = "background 0.5s";
            document.getElementById("inputField7").style.background = "#c9c9c9";
            document.getElementById("inputField7").style.cursor = "not-allowed";
        }
    }
    if (document.getElementById("inputField8") != null) {
        if (n8 == 1) {
            document.getElementById("inputField8").disabled = false;
            document.getElementById("inputField8").style.transition = "background 0.5s";
            document.getElementById("inputField8").style.background = "#fff";
            document.getElementById("inputField8").style.cursor = "auto";
        }
        else {
            document.getElementById("inputField8").disabled = true;
            document.getElementById("inputField8").style.transition = "background 0.5s";
            document.getElementById("inputField8").style.background = "#c9c9c9";
            document.getElementById("inputField8").style.cursor = "not-allowed";
        }
    }
}
function buttonsEnable(n1, n2, n3, n4, n5, n6) {
    if (document.getElementById("boton1") != null) {
        if (n1 == 1) {
            document.getElementById("boton1").disabled = false;
            document.getElementById("boton1").style.transition = "background 1s";
            document.getElementById("boton1").style.transition = "color 1s";
            document.getElementById("boton1").style.setProperty('--menu-background-color', '#17b8ff');
            document.getElementById("boton1").style.setProperty('--boton-hover-color', '#fff');
            document.getElementById("boton1").style.setProperty('--iconos-color', '#fff');
            document.getElementById("boton1").style.setProperty('--iconos-hover-color', '#17b8ff');
            document.getElementById("boton1").style.cursor = "pointer";
        }
        else {
            document.getElementById("boton1").disabled = true;
            document.getElementById("boton1").style.transition = "background 1s";
            document.getElementById("boton1").style.transition = "color 1s";
            document.getElementById("boton1").style.setProperty('--menu-background-color', '#1861ac');
            document.getElementById("boton1").style.setProperty('--boton-hover-color', '#1861ac');
            document.getElementById("boton1").style.setProperty('--iconos-color', '#092643');
            document.getElementById("boton1").style.setProperty('--iconos-hover-color', '#092643');
            document.getElementById("boton1").style.cursor = "not-allowed";
        }
    }
    if (document.getElementById("boton2") != null) {
        if (n2 == 1) {
            document.getElementById("boton2").disabled = false;
            document.getElementById("boton2").style.transition = "background 1s";
            document.getElementById("boton2").style.transition = "color 1s";
            document.getElementById("boton2").style.setProperty('--menu-background-color', '#17b8ff');
            document.getElementById("boton2").style.setProperty('--boton-hover-color', '#fff');
            document.getElementById("boton2").style.setProperty('--iconos-color', '#fff');
            document.getElementById("boton2").style.setProperty('--iconos-hover-color', '#17b8ff');
            document.getElementById("boton2").style.cursor = "pointer";
        }
        else {
            document.getElementById("boton2").disabled = true;
            document.getElementById("boton2").style.transition = "background 1s";
            document.getElementById("boton2").style.transition = "color 1s";
            document.getElementById("boton2").style.setProperty('--menu-background-color', '#1861ac');
            document.getElementById("boton2").style.setProperty('--boton-hover-color', '#1861ac');
            document.getElementById("boton2").style.setProperty('--iconos-color', '#092643');
            document.getElementById("boton2").style.setProperty('--iconos-hover-color', '#092643');
            document.getElementById("boton2").style.cursor = "not-allowed";
        }
    }
    if (document.getElementById("boton3") != null) {
        if (n3 == 1) {
            document.getElementById("boton3").disabled = false;
            document.getElementById("boton3").style.transition = "background 1s";
            document.getElementById("boton3").style.transition = "color 1s";
            document.getElementById("boton3").style.setProperty('--menu-background-color', '#17b8ff');
            document.getElementById("boton3").style.setProperty('--boton-hover-color', '#fff');
            document.getElementById("boton3").style.setProperty('--iconos-color', '#fff');
            document.getElementById("boton3").style.setProperty('--iconos-hover-color', '#17b8ff');
            document.getElementById("boton3").style.cursor = "pointer";
        }
        else {
            document.getElementById("boton3").disabled = true;
            document.getElementById("boton3").style.transition = "background 1s";
            document.getElementById("boton3").style.transition = "color 1s";
            document.getElementById("boton3").style.setProperty('--menu-background-color', '#1861ac');
            document.getElementById("boton3").style.setProperty('--boton-hover-color', '#1861ac');
            document.getElementById("boton3").style.setProperty('--iconos-color', '#092643');
            document.getElementById("boton3").style.setProperty('--iconos-hover-color', '#092643');
            document.getElementById("boton3").style.cursor = "not-allowed";
        }
    }
    if (document.getElementById("boton4") != null) {
        if (n4 == 1) {
            document.getElementById("boton4").disabled = false;
            document.getElementById("boton4").style.transition = "background 1s";
            document.getElementById("boton4").style.transition = "color 1s";
            document.getElementById("boton4").style.setProperty('--menu-background-color', '#17b8ff');
            document.getElementById("boton4").style.setProperty('--boton-hover-color', '#fff');
            document.getElementById("boton4").style.setProperty('--iconos-color', '#fff');
            document.getElementById("boton4").style.setProperty('--iconos-hover-color', '#17b8ff');
            document.getElementById("boton4").style.cursor = "pointer";
        }
        else {
            document.getElementById("boton4").disabled = true;
            document.getElementById("boton4").style.transition = "background 1s";
            document.getElementById("boton4").style.transition = "color 1s";
            document.getElementById("boton4").style.setProperty('--menu-background-color', '#1861ac');
            document.getElementById("boton4").style.setProperty('--boton-hover-color', '#1861ac');
            document.getElementById("boton4").style.setProperty('--iconos-color', '#092643');
            document.getElementById("boton4").style.setProperty('--iconos-hover-color', '#092643');
            document.getElementById("boton4").style.cursor = "not-allowed";
        }
    }
    if (document.getElementById("boton5") != null) {
        if (n5 == 1) {
            document.getElementById("boton5").disabled = false;
            document.getElementById("boton5").style.transition = "background 1s";
            document.getElementById("boton5").style.transition = "color 1s";
            document.getElementById("boton5").style.setProperty('--menu-background-color', '#17b8ff');
            document.getElementById("boton5").style.setProperty('--boton-hover-color', '#fff');
            document.getElementById("boton5").style.setProperty('--iconos-color', '#fff');
            document.getElementById("boton5").style.setProperty('--iconos-hover-color', '#17b8ff');
            document.getElementById("boton5").style.cursor = "pointer";
        }
        else {
            document.getElementById("boton5").disabled = true;
            document.getElementById("boton5").style.transition = "background 1s";
            document.getElementById("boton5").style.transition = "color 1s";
            document.getElementById("boton5").style.setProperty('--menu-background-color', '#1861ac');
            document.getElementById("boton5").style.setProperty('--boton-hover-color', '#1861ac');
            document.getElementById("boton5").style.setProperty('--iconos-color', '#092643');
            document.getElementById("boton5").style.setProperty('--iconos-hover-color', '#092643');
            document.getElementById("boton5").style.cursor = "not-allowed";
        }
    }
    if (document.getElementById("boton6") != null) {
        if (n6 == 1) {
            document.getElementById("boton6").disabled = false;
            document.getElementById("boton6").style.transition = "background 1s";
            document.getElementById("boton6").style.transition = "color 1s";
            document.getElementById("boton6").style.setProperty('--menu-background-color', '#17b8ff');
            document.getElementById("boton6").style.setProperty('--boton-hover-color', '#fff');
            document.getElementById("boton6").style.setProperty('--iconos-color', '#fff');
            document.getElementById("boton6").style.setProperty('--iconos-hover-color', '#17b8ff');
            document.getElementById("boton6").style.cursor = "pointer";
        }
        else {
            document.getElementById("boton6").disabled = true;
            document.getElementById("boton6").style.transition = "background 1s";
            document.getElementById("boton6").style.transition = "color 1s";
            document.getElementById("boton6").style.setProperty('--menu-background-color', '#1861ac');
            document.getElementById("boton6").style.setProperty('--boton-hover-color', '#1861ac');
            document.getElementById("boton6").style.setProperty('--iconos-color', '#092643');
            document.getElementById("boton6").style.setProperty('--iconos-hover-color', '#092643');
            document.getElementById("boton6").style.cursor = "not-allowed";
        }
    }
}

function modifyReturn(n) {
    if (n == 0) {
        document.getElementById("boton1").style.setProperty('--menu-background-color', '#fff');
        updateEstatusText(1);
        document.getElementById("boton1").style.setProperty('--boton-hover-color', '#fff');
        document.getElementById("boton1").style.setProperty('--iconos-color', '#17b8ff');
        document.getElementById("boton1").style.setProperty('--iconos-hover-color', '#17b8ff');
        document.getElementById("boton1").setAttribute("title", "Cancelar");
        document.getElementById("boton1").setAttribute("onclick", "formEnable(0, 0, 0, 0, 0, 0, 0, 0); buttonsEnable(1, 0, 0, 1, 1, 1); modifyReturn(1)");
    }
    else {
        document.getElementById("screenForm").reset();
        updateEstatusText(3);
        document.getElementById("boton1").style.setProperty('--menu-background-color', '#17b8ff');
        document.getElementById("boton1").style.setProperty('--boton-hover-color', '#fff');
        document.getElementById("boton1").style.setProperty('--iconos-color', '#fff');
        document.getElementById("boton1").style.setProperty('--iconos-hover-color', '#17b8ff');
        document.getElementById("boton1").setAttribute("title", "Nuevo"); 
        document.getElementById("boton1").setAttribute("onclick", "formEnable(1, 1, 1, 1, 1, 1, 1, 1); buttonsEnable(1, 0, 1, 0, 0, 1); modifyReturn(0)");
    }
}

function modifyMagGlass(n) {
    if (n == 0) {
        updateEstatusText(2);
        document.getElementById("boton4").style.setProperty('--menu-background-color', "#fff");
        document.getElementById("boton4").style.setProperty('--boton-hover-color', '#fff');
        document.getElementById("boton4").style.setProperty('--iconos-color', '#17b8ff');
        document.getElementById("boton4").style.setProperty('--iconos-hover-color', '#17b8ff'); 
        document.getElementById("boton4").setAttribute("onclick", "formEnable(0, 0, 0, 0, 0, 0, 0, 0); buttonsEnable(1, 0, 0, 1, 1, 1); modifyMagGlass(1)");
        document.getElementById("boton4").setAttribute("title", "Cancelar");
    }
    else {
        updateEstatusText(3);
        document.getElementById("inputField1").removeAttribute("readonly");
        document.getElementById("screenForm").reset();
        document.getElementById("boton4").style.setProperty('--menu-background-color', '#17b8ff');
        document.getElementById("boton4").style.setProperty('--boton-hover-color', '#fff');
        document.getElementById("boton4").style.setProperty('--iconos-color', '#fff');
        document.getElementById("boton4").style.setProperty('--iconos-hover-color', '#17b8ff');
        document.getElementById("boton4").setAttribute("title", "Buscar");
        document.getElementById("boton4").setAttribute("onclick", "displayList(); filterTable()");
    }
}

var specialElementHandlers = {
    '.no-export': function (element, rendered) {
        return true;
    }
}
function exportPDF() {
    var w = document.getElementById("tablaPDF").offsetWidth;
    var h = document.getElementById("tablaPDF").offsetHeight;
    html2canvas(document.getElementById("tablaPDF"), {
        dpi: 300, // Set to 300 DPI
        scale: 3, // Adjusts your resolution
        onrendered: function (canvas) {
            var img = canvas.toDataURL("image/jpeg", 1);
            var doc = new jsPDF('L', 'px', [w, h]);
            doc.addImage(img, 'JPEG', 0, 0, w, h);
            doc.save('ReportePantallasProgramas.pdf');
        }
    });
}

function displayList() {
    var modal = document.getElementById("listModal");
    modal.style.display = "block";
    var closeBtn = document.getElementById("closeButton");
    closeBtn.onclick = function () {
        modal.style.display = "none";
    }
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }
}

//Excel
function tableToCSV() {

    var csv_data = [];
    csv_data.push(
    `IntegraCorp & H Consulting S.A. C.V.,
   Listado ${document.title},
     `)

    var rows = document.getElementsByTagName('tr');
    for (var i = 0; i < rows.length; i++) {

        var cols = rows[i].querySelectorAll('td,th');   

        var csvrow = [];
        for (var j = 0; j < cols.length; j++) {
            if (cols[j].innerHTML.charAt(0) == '$') {
                var valor = cols[j].innerHTML.substring(1).replaceAll(",", "");
                console.log(valor);
            }
            else {
                var valor = cols[j].innerHTML;
            }
            csvrow.push(valor);
        }
        csv_data.push(csvrow.join(","));
    }

    csv_data = csv_data.join('\n');

    downloadCSVFile(csv_data);

}
function downloadCSVFile(csv_data) {

    CSVFile = new Blob([csv_data], {
        type: "text/csv"
    });

    var temp_link = document.createElement('a');

    temp_link.download = document.title + ".csv";
    var url = window.URL.createObjectURL(CSVFile);
    temp_link.href = url;

    temp_link.style.display = "none";
    document.body.appendChild(temp_link);

    temp_link.click();
    document.body.removeChild(temp_link);
}

var table = document.getElementById("tablaPantallas");
if (document.getElementById("searchBar") != null) {
    var input = document.getElementById("searchBar");
    input.addEventListener('keyup', function (event) {
        filterTable();
    });
}
if (document.getElementById("selectFiltro") != null) {
    var filtroSelect = document.getElementById("selectFiltro");
    filtroSelect.addEventListener('change', function (event) {
        filterTable();
    });
}
var formulario = document.getElementById("screenForm");

let usuarioPermisos = "";
let nombrePermisos = "";

function pasarFila(row) {
    if (document.title = "Requisiciones Talento") {
        formEnable(1, 1, 1, 1, 1, 1, 1, 1);
        buttonsEnable(0, 1, 1, 1, 1, 1);
        modifyMagGlass(0);
        let i = 0;
        let cells = row.getElementsByTagName("TD");
        for (let cell of cells) {
            i++;
            if (i > 1) {
                if (i == 3) {
                    var emp = cell.textContent;
                }
                if (i == 5) {
                    $.getJSON("/GestionTalentos/ListadoOficinas", { cid: emp }, function (e) {
                        var row = "";
                        $("#inputField5").empty();
                        row += '<option value="">Seleccione Oficina</option>';
                        $.each(e, function (i, v) {
                            if (v.value == cell.textContent)
                                row += "<option selected=\"true\" value=" + v.value + ">" + v.text + "</option>";
                            else
                                row += "<option value=" + v.value + ">" + v.text + "</option>";
                        });
                        cont = 1;
                        $("#inputField5").html(row);
                    });
                }
                document.getElementById("inputField" + i).value = cell.textContent;
            }
        }
        var modal = document.getElementById("listModal");
        modal.style.display = "none";
        document.getElementById("estatusInput").setAttribute("value", "2");
    }
    else if (document.title != "Permisos") {
        formEnable(1, 1, 1, 1, 1, 1, 1, 1);
        buttonsEnable(0, 1, 1, 1, 1, 1);
        modifyMagGlass(0);
        let i = 0;
        let cells = row.getElementsByTagName("TD");
        for (let cell of cells) {
            i++;
            document.getElementById("inputField" + i).value = cell.textContent;
        }
        var modal = document.getElementById("listModal");
        modal.style.display = "none";
        document.getElementById("estatusInput").setAttribute("value", "2");
        document.getElementById("inputField1").setAttribute("readonly", "");
        document.getElementById("inputField1").style.transition = "background 0.5s";
        document.getElementById("inputField1").style.background = "#c9c9c9";
        document.getElementById("inputField1").style.cursor = "not-allowed";
        console.log(document.getElementById("estatusInput").value);
    }
    else {
        let i = 0;
        let cells = row.getElementsByTagName("TD");
        for (let cell of cells) {
            i++;
            if (i <= 2) {
                document.getElementById("inputField" + i).setAttribute("value", cell.textContent);
            }
        }
        var usuarioPermisos = document.getElementById("inputField1").value;
        var nombrePermisos = document.getElementById("inputField2").value;
        console.log(usuarioPermisos + " " + nombrePermisos);
        formulario.submit();
    }
}
function filterTable() {
    let filter = input.value.toUpperCase();
    rows = table.getElementsByTagName("TR");
    let flag = false;
    for (let row of rows) {
        if (row.getAttribute("id") != "encabezados")
            row.setAttribute("ondblclick", "pasarFila(this)");
        let cells = row.getElementsByTagName("TD");
        for (let cell of cells) {
            if ((cell.textContent.toUpperCase().indexOf(filter) > -1) && (cell.getAttribute("id") == filtroSelect.value)) {
                flag = true;
                break;
            }
        }

        if (flag) {
            row.style.display = "";
        } else {
            if(row.getAttribute("id")!="encabezados")
               row.style.display = "none";
        }

        flag = false;
    }
}

function deleteSubmit() {
    document.getElementById("estatusInput").setAttribute("value", "3");
    console.log(document.getElementById("estatusInput").value);
    formulario.submit();
    alert("Registro eliminado.");
}

let passwordMatching = true;
function checkForValidity(key) {
    if (document.title == "Usuarios") {
        if ((document.getElementById('inputField4') != null) && (document.getElementById('inputField5') != null)) {
            if (document.getElementById('inputField4').value != document.getElementById('inputField5').value) {
                passwordMatching = false;
                return false;
            }
        }
    }
    if (document.getElementById("estatusInput").value == "1") {
        rows = table.getElementsByTagName("TR");
        for (let row of rows) {
            let cells = row.getElementsByTagName("TD");
            for (let cell of cells) {
                if (cell.getAttribute("id") == "claveTabla") {
                    if (cell.textContent == key)
                        return false;
                }
            }
        }
    }
    else {
        return true;
    }
    return true;
}

function approveSubmit() {
    var key = formulario.clave.value;
    var result = checkForValidity(key);
    if (result) {
        updateEstatusText(3);
        formulario.submit();
        if (document.getElementById("estatusInput").value == 1)
            alert("Registro añadido.");
        else if (document.getElementById("estatusInput").value == 2)
            alert("Registro modificado.");
    }
    else {
        if (passwordMatching)
            alert("Error: Esta clave ya está registrada.");
        else {
            alert("Error: Las contraseñas no son iguales.")
            formulario.contrasena.value="";
            formulario.verificarContrasena.value="";
        }
    }
}

function updateEstatusText(n) {
    var texto = document.getElementById('accionEstatus');
    if (n == 1)
        texto.textContent = "Nuevo";
    else if (n == 2)
        texto.textContent = "Modificando";       
    else if (n == 3)
        texto.textContent = "";
}

function checkUncheck(box) {
    console.log(box.name);
    if (box.hasAttribute("checked")) {
        box.setAttribute("value", "0");
        box.removeAttribute("checked");
        box.setAttribute("unchecked", "");
    }
    else {
        box.setAttribute("value", "1");
        box.removeAttribute("unchecked");
        box.setAttribute("checked", "");
    }
}

function sendCheckBoxes() {
    var tablaCheck = document.getElementById('tablaCheck');
    for (let i = 1; i <= 6; i++) {
        var campos = document.getElementsByClassName("field" + i);
        for (let campo of campos) {
            if (campo.hasAttribute("unchecked")) {
                campo.removeAttribute("unchecked");
                campo.setAttribute("checked", "");
                campo.setAttribute("value", "0");
            }
            else {
                campo.setAttribute("value", "1");
            }
        }
    }
    document.getElementById('screenForm').submit();
}

//function subirArchivos() {
//    var totalFiles = document.getElementById('archivos').files.length;
//    console.log(totalFiles);
//    var formData = new FormData();
//    console.log("CALLS.");
//    var esValido = true;
//    if (totalFiles == 0) {
//        esValido = false;
//    }

//    if (esValido == true) {

//        for (var i = 0; i < totalFiles; i++) {
//            formData.append("archivos", document.getElementById('archivos').files[i]);
//        }
//        console.log([...formData.entries()]);
//        $.ajax({
//            type: "POST",
//            url: "/GestionTalentos/InsertarArchivos",
//            data: formData,
//            contentType: false,
//            processData: false,
//            cache: false,
//            beforeSend: function () {
//                $('#loaderArchivos').html(`<p>SUBIENDO ARCHIVOS...</p>`);
//            },
//            success: function (response) {
//                var respuesta = response;
//                console.log(respuesta);
//                $('#loaderArchivos').html(`<p>${respuesta.mensaje_Respuesta}</p>`);
//            },
//            error: function (jqXHR, textStatus, errorThrown) {
//                console.log(jqXHR);
//                console.log(textStatus);
//                console.log(errorThrown);
//                alert("Ocurrió un error al subir los archivos: " + jqXHR);
//            }
//        });

//    }

//}