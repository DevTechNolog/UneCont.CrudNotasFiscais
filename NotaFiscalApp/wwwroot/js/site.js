$(function () {
    function carregarNotas() {
        $.get("api/notas/ListarNotasFiscais")
            .done(function (data) {
                $("#tabelaNotas").html(data); 
            })
            .fail(function () {
                alert('Erro ao carregar notas do servidor.');
            });
    }
    
    $('#notaForm').on('submit', function (e) {
        e.preventDefault();


        const dto = {
            numero: $('#numero').val().trim(),
            cliente: $('#cliente').val().trim(),
            valor: parseFloat($('#valor').val()),
            dataEmissao: $('#dataEmissao').val()
        };

        // validações
        if (!dto.numero || !dto.cliente || !dto.valor || !dto.dataEmissao) {
            showMessage('Preencha todos os campos obrigatórios.', true);
            return;
        }     

        dto.dataEmissao = new Date(dto.dataEmissao).toISOString();

        $.ajax({
            url: "api/notas",
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(dto)
        })
            .done(function () {
                showMessage('Nota cadastrada com sucesso.');
                $('#notaForm')[0].reset();
                carregarNotas();
            })
            .fail(function (xhr) {
                const msg = xhr.responseJSON?.message || 'Erro ao cadastrar';
                showMessage(msg, true);
            });

    })

    function showMessage(text, isError) {
        const el = $('#formMessage');
        el.text(text).css('color', isError ? 'red' : 'green');
        setTimeout(() => el.text(''), 4000);
    }
})