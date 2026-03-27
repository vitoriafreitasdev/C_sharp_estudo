import get_func from "../../utils/get_function.js"
import UserFetch from "../../utils/fetch_post.js"
import key from "../../utils/safe_key.js"

const commentsSection = document.querySelector(".comments-section")
const url = window.location.href.split("?id=")
const eventId = url[1]

async function showComments() {
    
    const comments = await get_func(`https://localhost:7120/api/Site/comments/${eventId}`)

    comments.map((comment) => {

        const div = document.createElement("div")
        const h3 = document.createElement("h3")
        const p = document.createElement("p")
     
        async function getUsers() {
           const data = await get_func(`https://localhost:7120/api/Users/${comment.userId}`)
           return data
        }

        getUsers().then((data) => {
            h3.textContent = data.name
            p.textContent = comment.commentary
            
            div.appendChild(h3)
            div.appendChild(p)

            commentsSection.appendChild(div)
        })
        
    })
}

showComments()

const comment = document.getElementById("comment")
const commentBtn = document.getElementById("commentBtn")
const userMessage = document.getElementById("user-message")

commentBtn.addEventListener("click", async () => {
    const keyLocal = localStorage.getItem("key")

    if(!keyLocal) userMessage.textContent = "Precisa estar logado para adicionar comentários no evento."

    const keyNumber = keyLocal.split("T")[0] + "T" // pega o valor o da key junto com o T
    const userId = keyLocal.split("T")[1] // pega apenas o id

    if(keyNumber != key) userMessage.textContent = "Precisa estar logado para adicionar comentários no evento."

    const data = {
        eventId: eventId,
        userId: userId,
        comment: comment.value
    }

   
    const postComment = await UserFetch(data, "https://localhost:7120/api/Site/addComment")

    if(postComment != true) {
        userMessage.textContent = "Ocorreu um erro."
        console.log(postComment)
    }
    else
    {
        window.location.reload()
    }
})