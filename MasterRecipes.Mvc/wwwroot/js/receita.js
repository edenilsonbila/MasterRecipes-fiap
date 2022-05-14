$(document).on('click', '#removeRow', function () {
    var rowCount = parseInt($("#totalLans").val());
    rowCount--;
    $("#totalLans").val(rowCount);
    $(this).closest('#inputFormRow').remove();
});

async function AJAXSubmit(oFormElement) {
    var resultElement = oFormElement.elements.namedItem("result");
    const formData = new FormData(oFormElement);

    try {
        const response = await fetch(oFormElement.action, {
            method: 'POST',
            body: formData
        });

        if (response.ok) {
            window.location.href = '/';
        }

        resultElement.value = 'Result: ' + response.status + ' ' +
            response.statusText;
    } catch (error) {
        console.error('Error:', error);
    }
}


$(document).ready(function () {
    // Write your JavaScript code.

    $("div[name=recipe-item]").click(function () {
        window.location.href = 'receita/visualizar/' + $(this).attr("data-id");
    });

    $("#addImagem").click(function () {
        var rowCount = parseInt($("#totalImages").val());
        rowCount++;
        $("#totalImages").val(rowCount);
        var html = '';
        html += '<div name="imagem" style="display:contents;">';
        html += '<div class="col-lg-6">';
        html += '    <label style="display:flex !important" class="">Arquivo</label>';
        html += '    <input type="file" name="imagem[' + rowCount + ']" class="form-control"/>';
        html += '</div>';
        html += '<div class="col-lg-2">';
        html += '    <label style="display:flex !important" class="">Principal?</label>';
        html += '    <select name="principal" class="form-control"><option value="S">Sim</option><option value="N">NÃO</option></select>';
        html += '</div>';
        html += '<div class="col-lg-1">';
        html += '<button id="removeImage" type="button" class="btn btn-danger" style="margin-right: 5px; margin-top:31px;">X</button>';
        html += '</div>';
        html += '</div>';

        $('#inputImageRow').append(html);
    });

    $("#addIgrediente").click(function () {

        var rowCount = parseInt($("#totalLans").val());
        rowCount++;
        $("#totalLans").val(rowCount);
        var html = '';
        html += '<div name="igrediente" style="display:contents;">';
        html += '<div class="col-lg-6">';
        html += '    <label style="display:flex !important" class="">DESCRIÇÃO</label>';
        html += '    <input type="text" name="titulo" class="form-control" placeholder="Titulo" />';
        html += '</div>';
        html += '<div class="col-lg-2">';
        html += '    <label style="display:flex !important" class="">QUANTIDADE</label>';
        html += '    <input type="text" name="quantidade" class="form-control" placeholder="Quantidade" />';
        html += '</div>';
        html += '<div class="col-lg-3">';
        html += '    <label style="display:flex !important" class="">UNIDADE MEDIDA</label>';
        html += '    <input type="text" name="unidademedida" class="form-control" placeholder="Unidade Medida" />';
        html += '</div>';
        html += '<div class="col-lg-1">';
        html += '<button id="removeRow" type="button" class="btn btn-danger" style="margin-right: 5px; margin-top:31px;">X</button>';
        html += '</div>';
        html += '</div>';

        $('#newRow').append(html);

    });

    $("#createButton").click(function () {
        var inputData = $('form').serializeArray();

        var igredientes = new Array;
        $("div[name='igrediente']").each(function () {
            var item = $(this);
            igredientes.push({
                Descricao: item.find("input[name='titulo']").val(),
                Quantidade: item.find("input[name='quantidade']").val(),
                UnidadeMedida: item.find("input[name='unidademedida']").val(),
            });
        });

        inputData.push({ name: "Igredientes", value: JSON.stringify(igredientes) });
        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "/receita/nova", // Controller/View
                data: inputData,
                success: function (response) {
                    window.location.href = '/receita/imagens/' + response;
                }
            });

    });
});