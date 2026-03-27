import UserFetch from "../../../utils/fetch_post.js"
import key from "../../../utils/safe_key.js"
const userEmail = document.getElementById("userEmail")
const userPassword = document.getElementById("userPassword")
const inputSubmit = document.getElementById("login-btn")
const messageToUser = document.getElementById("user-message")

async function logUser(user, url) {
    const request = await fetch(url, {
        method: "post",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(user)
    });

    const res = await request.json()

    return res
} 

inputSubmit.addEventListener("click", async (e) => {

    e.preventDefault()

    const userData = {
        Email: userEmail.value,
        Password: userPassword.value
    }

    messageToUser.innerText = "Carregando..."

    const res = await UserFetch(userData, "https://localhost:7120/api/Users/Login")

    messageToUser.innerText = ""

    if(res.id){
        // chave para saber se usuário está logado.
        const keyUser = key + res.id
        localStorage.setItem("key", keyUser)
        window.location.assign(`/site/UserPage/index.html?id=${res.id}`)
    }
    else{
        messageToUser.innerText = res
    }
   

})