//$(document).ready(function () {
//    $("#agregararchivo").on("change", function () {
//        var file = $(this).val().replace(/C:\\fakepath\\/i, '');
//        $("#uploadFile").val(file);
//    });
//});


jQuery(document).ready(function () {

    $.validator.addMethod('validatenew', function () {
        return ($('#codigoProductoOld').val() != $('#codigoProductoNew').val())
    }, "El código de producto antiguo no puede ser el mismo que el nuevo.");

    //VALIDACIONES $.VALIDATE
    $.extend($.validator.messages, {
        required: "Este campo es obligatorio.",
        remote: "Por favor, rellena este campo.",
        email: "Por favor, escribe una dirección de correo válida",
        url: "Por favor, escribe una URL válida.",
        date: "Por favor, escribe una fecha válida.",
        dateISO: "Por favor, escribe una fecha (ISO) válida.",
        number: "Por favor, escribe un número entero válido.",
        digits: "Por favor, escribe sólo dígitos.",
        creditcard: "Por favor, escribe un número de tarjeta válido.",
        equalTo: "Por favor, escribe el mismo valor de nuevo.",
        accept: "Ingrese una imagen, pdf o word",
        maxlength: $.validator.format("Por favor, no escribas más de {0} caracteres."),
        minlength: $.validator.format("Por favor, no escribas menos de {0} caracteres."),
        rangelength: $.validator.format("Por favor, escribe un valor entre {0} y {1} caracteres."),
        range: $.validator.format("Por favor, escribe un valor entre {0} y {1}."),
        max: $.validator.format("Por favor, escribe un valor menor o igual a {0}."),
        min: $.validator.format("Por favor, escribe un valor mayor o igual a {0}.")
    });

    jQuery(document).off("click");
    jQuery(document).on("click", "#btnAgregar", function (e) {


        $.validator.setDefaults({
            debug: true,
            success: "valid"
        });

        $form = $("#FormAgregarProducto");

        $form.validate({
            submitHandler: function ($form) {
                $("error").addClass("alert alert-primary");
                $form.submit();
            },
            rules: {
                codigo: {
                    required: true,
                    min: 10,
                    max: 99999
                },
                nombre: {
                    required: true,
                    minlength: 3,
                    maxlength: 80,
                    alphanumeric: true
                },
                fechaInicio: {
                    required:true
                },
                isapre: {
                    required: true
                },
                valor: {
                    required: true,
                    min: 0,
                    max: 999999
                },
                beneficiario: {
                    required: true
                }
            },
            messages: {
                codigo: {
                    required: "Debe ingresar el código del producto",
                    min: "El largo del código del producto debe ser mayor a 2 caracteres",
                    max: "El largo del código del producto debe ser menor a 5 caracteres"
                },
                nombre: {
                    required: "Debe ingresar el nombre del producto",
                    minlength: "El nombre del producto debe ser mayor a {0} caracteres",
                    maxlength: "El nombre del producto debe ser menor a {0} caracteres",
                    alphanumeric: "Solamente puedes escribir letras y números"
                },
                fechaInicio: {
                    required: "Debe ingresar la fecha de inicio"
                },
                isapre: {
                    required: "Debe ingresar la isapre correspondiente"
                },
                valor: {
                    required: "Debe ingresar el valor del producto",
                    min: "El largo del código del producto debe ser mayor a {0}",
                    max: "El largo del valor del producto debe ser menor a {0}"
                },
                beneficiario: {
                    required: "Debe ingresar el beneficiario"
                }
            },
            errorElement: 'div',
            errorLabelContainer: '.errorTxt'
        });
    });


    jQuery(document).off("click");
    jQuery(document).on("click", "#btnBuscar", function (e) {


        $.validator.setDefaults({
            debug: true,
            success: "valid"
        });

        $form = $("#FormBuscarProducto");

        $form.validate({
            submitHandler: function ($form) {
                //$("body").addClass("loading");
                $form.submit();
            },
            rules: {
                codigo: {
                    required: true,
                    min: 10,
                    max: 99999
                }
            },
            messages: {
                codigo: {
                    required: "Debe ingresar el código del producto",
                    min: "El largo del código del producto debe ser mayor o igual a {0}",
                    max: "El largo del código del producto debe ser menor a {0}"
                }
                
            },
            errorElement: 'div',
            errorLabelContainer: '.errorTxt'
        });
    });

    jQuery(document).off("click");
    jQuery(document).on("click", "#btnEditar", function (e) {


        $.validator.setDefaults({
            debug: true,
            success: "valid"
        });

        $form = $("#editarProducto");

        $form.validate({
            submitHandler: function ($form) {
                //$("body").addClass("loading");
                $form.submit();
            },
            rules: {
                nombre: {
                    required: true
                },
                estado: {
                    required: true
                },
                valor: {
                    required: true,
                    min: 0,
                    max: 999999
                },
                beneficiario: {
                    required: true
                }
            },
            messages: {
                nombre: {
                    required: "Debe ingresar el nombre del producto"
                },
                estado: {
                    required: "Debe ingresar el estado del producto"
                },
                valor: {
                    required: "Debe ingresar el valor del producto",
                    min: "El largo del código del producto debe ser mayor a {0}",
                    max: "El largo del valor del producto debe ser menor a {0}"
                },
                beneficiario: {
                    required: "Debe ingresar el beneficiario del producto"
                }

            },
            errorElement: 'div',
            errorLabelContainer: '.errorTxt'
        });
    });

    jQuery(document).off("click");
    jQuery(document).on("click", "#btnBuscar", function (e) {


        $.validator.setDefaults({
            debug: true,
            success: "valid"
        });

        $form = $("#FormBuscarProducto2");

        $form.validate({
            submitHandler: function ($form) {
                //$("body").addClass("loading");
                $form.submit();
            },
            rules: {
                rutAfiliado: {
                    required: true
                }
            },
            messages: {
                rutAfiliado: {
                    required: "Debe ingresar el rut del afiliado"
                }

            },
            errorElement: 'div',
            errorLabelContainer: '.errorTxt'
        });
    });

    jQuery(document).off("click");
    jQuery(document).on("click", "#btnCambiar", function (e) {


        $.validator.setDefaults({
            debug: true,
            validatenew: false,
            success: "valid"
        });

        $form = $("#FormCambiarProducto");

        $form.validate({
            submitHandler: function ($form) {
                //$("body").addClass("loading");
                $form.submit();
            },
            rules: {
                isapre: {
                    required: true
                },
                codigoProductoOld: {
                    required: true,
                    min: 1
                },
                codigoProductoNew: {
                    required: true,
                    min: 1,
                    validatenew: true
                }
            },
            messages: {
                isapre: {
                    required: "Debe seleccionar la isapre"
                },
                codigoProductoOld: {
                    required: "Debe seleccionar el código del producto",
                    min: "Debe seleccionar un código del producto"
                },
                codigoProductoNew: {
                    required: "Debe seleccionar el nuevo código del producto",
                    min: "Debe seleccionar un nuevo código del producto",
                    validatenew: "El nuevo código no puede ser igual al antiguo código de producto"
                }

            },
            errorElement: 'div',
            errorLabelContainer: '.errorTxt'
        });
    });
});