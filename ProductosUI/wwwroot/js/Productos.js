jsProductos ={
    variables: {},
    controles: {
        tblProductos: "#tblProductos",
        tbodyProductos: "#tbodyProductos",
        btnBuscarProducto: "#btnBuscarProducto",
        txtNombreCategoriaBuscar: "#txtNombreCategoriaBuscar"
    },
    funciones: {
        crearDatosInformativos: function (idCategoria = 0) {
            
            $.ajax({
                type: "POST",
                url: '../../Productos/ObtenerProducto',
                data: { idCategoria },
                success: function (objeto) {
                    if (!objeto.HayError) {
                        jsProductos.funciones.llenarTabla(objeto.objetoRespuesta);

                    }
                },
                error: function (ajaxContext) {
                    
                }
            });
        }, llenarTabla: function (listaProductos) {

            $(jsProductos.controles.tbodyProductos).empty();
            var html = ``;
            listaProductos.forEach(function (producto) {
                html +=
                    `
                    <tr>
                        <td>${producto.nIdProduct}</td>
                        <td>${producto.cNombProdu}</td>
                        <td>${producto.nPrecioProd}</td>
                        <td>${producto.cNombCateg}</td>
                    </tr>
                `         
            })
            $(jsProductos.controles.tbodyProductos).append(html);
            $(jsProductos.controles.tblProductos).DataTable();
        }
    }, Eventos: {
        General: function () {
            
            $(jsProductos.controles.btnBuscarProducto).click(function () {
                
                var categoriaBuscar = $(jsProductos.controles.txtNombreCategoriaBuscar).val();
                jsProductos.funciones.crearDatosInformativos(categoriaBuscar);

            });
        }
    },

}

$(document).ready(function () {
    jsProductos.funciones.crearDatosInformativos();
    jsProductos.Eventos.General();


});