

import key from "../../utils/safe_key.js"
import get_func from "../../utils/get_function.js"
import UserFetch from "../../utils/fetch_post.js"

const eventsContainer = document.querySelector(".events-container")

async function loadEventsInTheScreen() {
    const events = await get_func("https://localhost:7120/api/Events/getEvents")

    events.map((events) => {
        const div = document.createElement("div")
        const pMessageToUser = document.createElement("p")
        const h2Title = document.createElement("h2")
        const pDesc = document.createElement("p")
        const pData = document.createElement("p")
        const subscribeBtn = document.createElement("button")
        const goToComments = document.createElement("button")
       
        const date = new Date(events.date)

        h2Title.textContent = events.title 
        pDesc.textContent = events.description
        pData.textContent = date.toLocaleDateString("en-GB")
        subscribeBtn.textContent = "Inscreva-se"
        goToComments.textContent = "Ir para os comentários"

        div.classList.add("event-container")

        div.appendChild(pMessageToUser)
        div.appendChild(h2Title)
        div.appendChild(pDesc)
        div.appendChild(pData)
        div.appendChild(subscribeBtn)
        div.appendChild(goToComments)

        eventsContainer.appendChild(div)

        subscribeBtn.addEventListener("click", async () => {
            const keyLocal = localStorage.getItem("key")

            if(!keyLocal) pMessageToUser.textContent = "Precisa estar logado para se inscrever ao evento."

            const keyNumber = keyLocal.split("T")[0] + "T" // pega o valor o da key junto com o T
            const userId = keyLocal.split("T")[1] // pega apenas o id

            if(keyNumber != key) pMessageToUser.textContent = "Precisa estar logado para se inscrever ao evento."

            const data = {
                userId: userId,
                eventId: events.id
            }

            const registerToEvent = await UserFetch(data, "https://localhost:7120/api/Site/registerToEvent")

            pMessageToUser.textContent = registerToEvent === true ? "Inscrito com sucesso." : "Ocorreu um erro, tente novamente mais tarde."

            setTimeout(() => {
                pMessageToUser.textContent = ""
            }, 2000)
        })

        goToComments.addEventListener("click", async () => {
            window.location.assign(`/site/EventPage/comments.html?id=${events.id}`)
        })
    })

}

loadEventsInTheScreen()