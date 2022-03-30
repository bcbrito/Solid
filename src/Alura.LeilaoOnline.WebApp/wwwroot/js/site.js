function anexaEventoNoCliqueBotoesRemoveLeilao() {
    let botoesRemocaoLeilao = document.querySelectorAll('.btnRemoveLeilao');
    botoesRemocaoLeilao.forEach(btn => $(btn).on('click', () => {
        let leilao = $(btn).data();
        if (window.confirm(`Confirma a exclusão do leilão ${leilao.titulo}?`)) {
            jQuery.ajax({
                url: `/Leilao/Remove/${leilao.id}`,
                method: 'post',
                success: () => $(`.row-leilao-${leilao.id}`).hide('slow'),
                error: () => window.alert('Houve um erro ao excluir')
            });
        }
    }));
}

$(document).ready(function () {

    anexaEventoNoCliqueBotoesRemoveLeilao();

    
});