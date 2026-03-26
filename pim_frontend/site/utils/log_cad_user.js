
export default async function UserFetch(user, url) {
    try {
        const request = await fetch(url, {
            method: "post",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(user)
        });
            
        const res = await request.json()
        
        return res
    } catch (error) {
        return error
    }
} 

