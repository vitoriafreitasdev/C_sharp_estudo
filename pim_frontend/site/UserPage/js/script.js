import UserFetch from "../../utils/fetch_post.js"
import get_func from "../../utils/get_function.js"

const title = document.getElementById("title")
const description = document.getElementById("description")
const date = document.getElementById("date")
const key = document.getElementById("key")
const titleEdit = document.getElementById("titleEdit")
const descriptionEdit = document.getElementById("descriptionEdit")
const dateEdit = document.getElementById("dateEdit")
const keyEdit = document.getElementById("keyEdit")
const addEventBtn = document.getElementById("addEventBtn")
const EditEventBtn = document.getElementById("EditEventBtn")
const certificateBtn = document.getElementById("certificateBtn")
const userMessage = document.getElementById("userMessage")
const userEventsContainer = document.querySelector(".user-events-container")
const eventEdit = document.querySelector(".event-edit")
const url = window.location.href.split("?id=")
const userId = url[1]
let eventId = null;

async function loadUsers(idEvent, container){
    const users = await get_func(`https://localhost:7120/api/Site/registeredUsersInEvent/${idEvent}`)
    if(users){
        users.map((user) => {
        const name = document.createElement("p")
        const age = document.createElement("p")
        const email = document.createElement("p")
        name.textContent = user.name
        age.textContent = user.age
        email.textContent = user.email
        container.appendChild(name)
        container.appendChild(age)
        container.appendChild(email)
        })
    } else 
    {
        userMessage.textContent = "Erro ao pegar os usuários."
    }
}

async function loadUserEvents(){
    const events = await get_func(`https://localhost:7120/api/Events/getEventByUser/${userId}`)
    events.map((events) => {
        const div = document.createElement("div")
        const h3Title = document.createElement("h3")
        const pDesc = document.createElement("p")
        const pData = document.createElement("p")
        const pKey = document.createElement("p")
        const buttonEdit = document.createElement("button")
        const buttonDelete = document.createElement("button")
        const buttonShowUsers = document.createElement("button")
        const date = new Date(events.date)

        h3Title.textContent = `Título: ${events.title }`
        pDesc.textContent = `Descrição: ${events.description}`
        pData.textContent = `Data: ${date.toLocaleDateString("en-GB")}`
        pKey.textContent = `Key: ${events.key}`
        buttonEdit.textContent = "Editar" 
        buttonDelete.textContent = "Deletar"
        buttonShowUsers.textContent = "Mostrar usuários inscritos"
        div.classList.add("events-user-container")

        div.appendChild(h3Title)
        div.appendChild(pDesc)
        div.appendChild(pData)
        div.appendChild(pKey)
        div.appendChild(buttonEdit)
        div.appendChild(buttonDelete)
        div.appendChild(buttonShowUsers)

        div.classList.add("event-user-container")
        userEventsContainer.appendChild(div)
        // edição de dados
        buttonEdit.addEventListener("click", async (e) => {
            e.preventDefault()
            eventEdit.style.display = "flex"
            eventId = events.id
        })
        buttonDelete.addEventListener("click", async (e) => {
            e.preventDefault()
            const data = {
                eventId: events.id,
                userId: userId
            }
            const res = await UserFetch(data, "https://localhost:7120/api/Events/DeleteEvent", "delete")
            userMessage.textContent = res !== null ? "Deletado com sucesso" : "Aconteceu um erro, tente novamente."
            window.location.reload()
        })
        buttonShowUsers.addEventListener("click", async (e) => {
            e.preventDefault()
            await loadUsers(events.id, div)
        })
    })  
}
addEventBtn.addEventListener("click", async (e) => {
    e.preventDefault()
    const data = {
        title: title.value,
        description: description.value,
        date: date.value,
        key: key.value,
        user_Id: userId
    }
    userMessage.textContent = "Carregando..."
    const res = await UserFetch(data, "https://localhost:7120/api/Events/AddEvent")
    userMessage.textContent = res !== null ? "Adicionado com sucesso" : "Aconteceu um erro, tente novamente."
    window.location.reload()
})
EditEventBtn.addEventListener("click", async (e) => {
    e.preventDefault()
    const data = {
        id: eventId,
        title: titleEdit.value,
        description: descriptionEdit.value,
        date: dateEdit.value,
        key: keyEdit.value,
        user_Id: userId
    }
    const res = await UserFetch(data, "https://localhost:7120/api/Events/EditEvent", "put")
    userMessage.textContent = res !== null ? "Atualizado com sucesso" : "Aconteceu um erro, tente novamente."
    window.location.reload()
})
certificateBtn.addEventListener("click", () => {
    window.location.assign(`/site/UserPage/certificado.html?id=${userId}`)
})
loadUserEvents()