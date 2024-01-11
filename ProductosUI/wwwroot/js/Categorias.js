jsCategorias = {
    variables: {},
    controles: {
        btnInsertarCategoria: "#btnInsertarCategoria",
        txtNombreCategoria: "#txtNombreCategoria",
        checkEstado: "#checkEstado",
        pValidacion: "#pValidacion",
        divMensajeExitoso: "#divMensajeExitoso",
        tblCategoria: "#tblCategoria",
        tbodyCategoria: "#tbodyCategoria",
        txtIdCategoria: "#txtIdCategoria",
        btnEditarCategoria: "#btnEditarCategoria",
        btnCancelarEditarCategoria: "#btnCancelarEditarCategoria",
        txtIdCategoria: "#txtIdCategoria",
        pMensajeExitoso: "#pMensajeExitoso"
    },
    funciones: {
        crearDatosInformativos: function (idCategoria = 0) {

            $.ajax({
                type: "GET",
                url: '../../Categoria/ObtenerCategoria',
                success: function (objeto) {
                    if (!objeto.HayError) {
                        
                        jsCategorias.funciones.llenarTabla(objeto.objetoRespuesta);

                    }
                },
                error: function (ajaxContext) {

                }
            });
        }, llenarTabla: function (listaCategorias) {
            
            $(jsCategorias.controles.tbodyCategoria).empty();
            var html = ``;
            listaCategorias.forEach(function (categoria) {
                html +=
                    `
                    <tr>
                        <td>${categoria.nIdCategori}</td>
                        <td>${categoria.cNombCateg}</td>
                        <td>${categoria.cEsActiva==true?"Activo":"Inactivo"}</td>
                        <td><button type="button" class="btn btn-warning" onclick="pintarDatosEditar('${categoria.nIdCategori}','${categoria.cNombCateg}','${categoria.cEsActiva}')">Editar</button></td>
                        <td><button type="button" class="btn btn-danger" onclick="editarEliminarCategoria('Eliminar',${categoria.nIdCategori})">Eliminar</button></td>
                    </tr>
                `
            })
            $(jsCategorias.controles.tbodyCategoria).append(html);
            $(jsCategorias.controles.tblCategoria).DataTable();
        },
        insertarCategoria: function (idCategoria = 0) {

            if (jsCategorias.funciones.validarFormularioCategorias()) {

                var nombreCategoria = $(jsCategorias.controles.txtNombreCategoria).val();
                var estado = $(jsCategorias.controles.checkEstado).prop('checked');

                $.ajax({
                    type: "POST",
                    url: '../../Categoria/InsertarCategoria',
                    data: { nombreCategoria, estado },
                    success: function (objeto) {
                        if (!objeto.objetoRespuesta.hayError) {
                            $(jsCategorias.controles.pValidacion).attr("hidden", true);
                            jsCategorias.funciones.llamarMensajeExitoso("Insertar");
                        }

                    },
                    error: function (ajaxContext) {

                    }
                });
            } else {
                $(jsCategorias.controles.pValidacion).removeAttr('hidden');
            }
        }, validarFormularioCategorias: function () {

            $(jsCategorias.controles.pValidacion).attr("hidden", true);

            var nombreCategoria = $(jsCategorias.controles.txtNombreCategoria).val();
            return nombreCategoria != "" ? true : false

        }, llamarMensajeExitoso: function (accion) {

            $(jsCategorias.controles.pMensajeExitoso).empty();
            if (accion == "Insertar") {
                $(jsCategorias.controles.pMensajeExitoso).append(" La categoría fue insertada exitosamentes");
            } else if (accion == "Editar") {
                $(jsCategorias.controles.pMensajeExitoso).append(" La categoría fue editada exitosamentes");
            } else {
                $(jsCategorias.controles.pMensajeExitoso).append(" La categoría fue eliminada exitosamentes");
            }
           
            $(jsCategorias.controles.divMensajeExitoso).toggle(2000);

            setTimeout(function () {
                $(jsCategorias.controles.divMensajeExitoso).toggle(2000);
                location.reload();
            }, 4000);
        },
    },

    Eventos: {
        General: function () {

            $(jsCategorias.controles.btnCancelarEditarCategoria).click(function () {

                $(jsCategorias.controles.btnInsertarCategoria).attr("hidden", false);
                $(jsCategorias.controles.btnCancelarEditarCategoria).attr("hidden", true);
                $(jsCategorias.controles.btnEditarCategoria).attr("hidden", true);

            });

            $(jsCategorias.controles.btnEditarCategoria).click(function () {

                if (jsCategorias.funciones.validarFormularioCategorias()) {
                    editarEliminarCategoria("Editar");
                }

            });

            $(jsCategorias.controles.btnInsertarCategoria).click(function () {

                jsCategorias.funciones.insertarCategoria();

            });
        }
    },
}

function editarEliminarCategoria (accion, id) {

    var nombreCategoria = "";
    var idCategoria = "";
    var estado = "";

    if (accion == "Editar") {
        nombreCategoria = $(jsCategorias.controles.txtNombreCategoria).val();
        idCategoria = $(jsCategorias.controles.txtIdCategoria).val();
        estado = $(jsCategorias.controles.checkEstado).prop('checked');
    } else {
        idCategoria = id
    }

    $.ajax({
        type: "POST",
        url: '../../Categoria/editarEliminarCategoria',
        data: { nombreCategoria, estado, idCategoria, accion },
        success: function (objeto) {
            if (!objeto.objetoRespuesta.hayError) {
                $(jsCategorias.controles.pValidacion).attr("hidden", true);
                jsCategorias.funciones.llamarMensajeExitoso(accion);
            }

        },
        error: function (ajaxContext) {

        }
    });
}

function pintarDatosEditar(nIdCategori, cNombCateg, cEsActiva) {
    $(jsCategorias.controles.btnInsertarCategoria).attr("hidden", true);
    $(jsCategorias.controles.btnCancelarEditarCategoria).attr("hidden", false);
    $(jsCategorias.controles.btnEditarCategoria).attr("hidden", false);

    $(jsCategorias.controles.txtNombreCategoria).val(cNombCateg);
    $(jsCategorias.controles.checkEstado).prop('checked', cEsActiva);
    $(jsCategorias.controles.txtIdCategoria).val(nIdCategori);

}

$(document).ready(function () {
    jsCategorias.Eventos.General();
    jsCategorias.funciones.crearDatosInformativos();

});