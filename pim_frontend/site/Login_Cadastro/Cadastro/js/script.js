
import UserFetch from "../../../utils/fetch_post.js"
import key from "../../../utils/safe_key.js"

const userName = document.getElementById("userName")
const userAge = document.getElementById("userAge")
const userEmail = document.getElementById("userEmail")
const userPassword = document.getElementById("userPassword")
const cadastroBtn = document.getElementById("cadastro-btn")
const messageToUser = document.getElementById("user-message")

cadastroBtn.addEventListener("click", async (e) => {
    e.preventDefault()
    
    const user = {
        Name: userName.value,
        Age: userAge.value,
        Email: userEmail.value,
        Password: userPassword.value
    }

    messageToUser.innerText = "Carregando..."

    const res = await UserFetch(user, "https://localhost:7120/api/Users/Register")

    messageToUser.innerText = ""

    if(res.id){
        // chave para saber se usuário esta logado.
        const keyUser = key + res.id
        localStorage.setItem("key", keyUser)
        window.location.assign(`/site/UserPage/index.html?id=${res.id}`)
    }
    else{
        messageToUser.innerText = res
    }
   
})