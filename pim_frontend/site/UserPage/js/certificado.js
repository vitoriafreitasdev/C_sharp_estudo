import UserFetch from "../../utils/fetch_post.js"

const key = document.getElementById("keyPass")
const certificateBtn = document.getElementById("certificateBtn")

const url = window.location.href.split("?id=")
const userId = url[1]

async function baixarImagemComDadosAPI(dados) {
    try {
        // Criar canvas
        const canvas = document.createElement('canvas');
        canvas.width = 600;
        canvas.height = 400;
        const ctx = canvas.getContext('2d');
        // Desenhar conteúdo
        ctx.fillStyle = '#2b2a2a';
        ctx.fillRect(0, 0, canvas.width, canvas.height);

        ctx.fillStyle = '#f8f8f8';
        ctx.font = 'bold 20px Arial';
        ctx.fillText(dados.eventTitle, 20, 50);
        
        const date = new Date(dados.date)

        ctx.font = '16px Arial';
        ctx.fillText(`Nome: ${dados.userName}`, 20, 100);
        ctx.fillText(`Data: ${date.toLocaleDateString("en-GB")}`, 20, 140);
        ctx.fillText(`Descrição: ${dados.description}`, 20, 180);

        // Baixar como PNG
        canvas.toBlob((blob) => {
            const anchor = document.createElement('a');
            const url = URL.createObjectURL(blob);
            anchor.href = url;
            anchor.download = 'certificado.png';
            anchor.click();
            URL.revokeObjectURL(url);
        }, 'image/png');
        
    } catch (erro) {
        console.error('Erro:', erro);
    }
}

certificateBtn.addEventListener("click", async () => {

    const data = {
        userId: userId,
        key: key.value
    }
    const res = await UserFetch(data, "https://localhost:7120/api/Events/GetCertificateData")
    console.log(res)
    if(res) baixarImagemComDadosAPI(res)
})